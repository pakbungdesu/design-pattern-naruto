
namespace Handlers
{
    using Requests;
    using Factories;
    using Enums;
    using Ninjas;
    using System;

    public interface IHandler
    {
        void SetNext(IHandler handler);
        void HandleRequest(MissionRequest request);
    }

    public abstract class MissionHandler : IHandler
    {
        protected IHandler? NextHandler = null;
        public void SetNext(IHandler handler) { NextHandler = handler; }
        public virtual void HandleRequest(MissionRequest request) { NextHandler?.HandleRequest(request); }

        protected Ninja HandleNinja(NinjaRequirement ninjaReq, VillageFactory factory)
        {
             Ninja baseNinja = ninjaReq.BaseRank switch
            {
                NinjaBaseRank.Jonin => factory.CreateJonin(ninjaReq.Name, ninjaReq.ChakraNature, ninjaReq.Attack, ninjaReq.Heal, ninjaReq.HP, ninjaReq.JutsuSpecialty, ninjaReq.ElementBoost),
                NinjaBaseRank.Chunin => factory.CreateChunin(ninjaReq.Name, ninjaReq.ChakraNature, ninjaReq.Attack, ninjaReq.Heal, ninjaReq.HP, ninjaReq.Stamina),
                NinjaBaseRank.Kage => factory.CreateKage(ninjaReq.Name, ninjaReq.ChakraNature, ninjaReq.Attack, ninjaReq.Heal, ninjaReq.HP, ninjaReq.BijuuPool),
                _ => throw new Exception("Unknown rank")
            };

            foreach (var roleReq in ninjaReq.Roles)
            {
                baseNinja = roleReq switch
                {
                    TankRequirement tankReq => new Tank(baseNinja, tankReq.Endurance),
                    AnbuRequirement anbuReq => new Anbu(baseNinja, anbuReq.Speed),
                    MedicRequirement medicReq => new Medic(baseNinja, medicReq.MedicalRank, medicReq.HospitalCode),
                    _ => baseNinja
                };
            }
            return baseNinja;
        }
    }

    public class KonohaRecruitHandler : MissionHandler 
    {
        private readonly KonohaFactory _factory = new KonohaFactory();

        public override void HandleRequest(MissionRequest request)
        {
            if (request.DeployedSquad == null)
                request.DeployedSquad = new Squad { SquadName = request.SquadBlueprint.SquadName };

            BuildSquad(request.SquadBlueprint, request.DeployedSquad);
            base.HandleRequest(request);
        }

        private void BuildSquad(SquadRequirement blueprint, Squad parentSquad)
        {
            foreach (var ninjaReq in blueprint.RequiredNinjas)
            {
                if (ninjaReq.Village == Location.Konohagakure)
                {
                    Ninja baseNinja = HandleNinja(ninjaReq, _factory);
                    parentSquad.Add(baseNinja);
                }
            }

            foreach (var subBlueprint in blueprint.SubSquads)
            {
                var subSquad = new Squad { SquadName = subBlueprint.SquadName };
                BuildSquad(subBlueprint, subSquad);
                if (subSquad.Members.Count > 0)
                    parentSquad.Add(subSquad);
            }
        }
    }

    public class AllianceRecruitHandler : MissionHandler
    {
        private readonly SunaFactory _sunaFactory = new SunaFactory();
        private readonly KiriFactory _kiriFactory = new KiriFactory();
        private readonly IwaFactory _iwaFactory = new IwaFactory();
        private readonly KumoFactory _kumoFactory = new KumoFactory();

        public override void HandleRequest(MissionRequest request)
        {
            if (request.DeployedSquad == null)
                request.DeployedSquad = new Squad { SquadName = request.SquadBlueprint.SquadName };

            BuildSquad(request.SquadBlueprint, request.DeployedSquad);
            base.HandleRequest(request);
        }

        private void BuildSquad(SquadRequirement blueprint, Squad parentSquad)
        {
            foreach (var ninjaReq in blueprint.RequiredNinjas)
            {
                AllianceFactory? factory = ninjaReq.Village switch
                {
                    Location.Sunagakure => _sunaFactory,
                    Location.Kirigakure => _kiriFactory,
                    Location.Iwagakure => _iwaFactory,
                    Location.Kumogakure => _kumoFactory,
                    _ => null
                };

                // If it's a Konoha ninja, ignore it (handled by KonohaRecruitHandler)
                if (factory == null) continue;
                
                Ninja baseNinja = HandleNinja(ninjaReq, factory);
                parentSquad.Add(baseNinja);
            }

            foreach (var subBlueprint in blueprint.SubSquads)
            {
                var subSquad = new Squad { SquadName = subBlueprint.SquadName };
                BuildSquad(subBlueprint, subSquad);
                
                if (subSquad.Members.Count > 0)
                    parentSquad.Add(subSquad);
            }
        }
    }

    public class WeaponHandler : MissionHandler { }
    public class DispatchHandler : MissionHandler { }
}