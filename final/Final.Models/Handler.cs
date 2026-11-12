
namespace Handlers
{
    using Requests;
    using Factories;
    using Enums;
    using Ninjas;

    public interface IHandler
    {
        void SetNext(IHandler handler);
        void HandleRequest(MissionRequest request);
    }

    public abstract class MissionHandler : IHandler
    {
        protected IHandler NextHandler;
        public void SetNext(IHandler handler) { NextHandler = handler; }
        public virtual void HandleRequest(MissionRequest request) { NextHandler?.HandleRequest(request); }
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
                    Ninja baseNinja = ninjaReq.BaseRank switch
                    {
                        NinjaBaseRank.Jonin => _factory.CreateJonin(),
                        NinjaBaseRank.Chunin => _factory.CreateChunin(),
                        NinjaBaseRank.Kage => _factory.CreateKage(),
                        _ => throw new Exception("Unknown rank")
                    };

                    foreach (var role in ninjaReq.Roles)
                    {
                        baseNinja = role switch
                        {
                            RoleDecorator.Tank => new Tank(baseNinja),
                            RoleDecorator.Medic => new Medic(baseNinja),
                            RoleDecorator.Anbu => new Anbu(baseNinja),
                            _ => baseNinja
                        };
                    }
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

    public class AllianceRecruitHandler : MissionHandler { /* Similar recursive logic routing to Suna/Kiri/Iwa/Kumo factories */ }
    public class WeaponHandler : MissionHandler { }
    public class DispatchHandler : MissionHandler { }
}