
namespace Facades
{
    using Requests;
    using VillageFactories;
    using ChakraFactories;
    using Ninjas;
    using Enums;

    public class KonohaFacade
    {
        private readonly KonohaFactory _konohaFactory;
        private AllianceFactory? _allianceFactory;
        private ChakraGenerator _weaponGenerator;
        private readonly MissionRequest _request;

        public KonohaFacade(MissionRequest request)
        {
            _request = request ?? throw new ArgumentNullException(nameof(request));
            _konohaFactory = new KonohaFactory();

            // Select the ChakraGenerator subsystem based on mission Location
            _weaponGenerator = _request.Location switch
            {
                Location.Konohagakure => new KonohaChakraGenerator(_request.WeaponBlueprint),
                Location.Sunagakure => new SunaChakraGenerator(_request.WeaponBlueprint),
                Location.Kirigakure => new KiriChakraGenerator(_request.WeaponBlueprint),
                Location.Iwagakure => new IwaChakraGenerator(_request.WeaponBlueprint),
                Location.Kumogakure => new KumoChakraGenerator(_request.WeaponBlueprint),
                _ => throw new ArgumentException($"Unsupported mission location: {_request.Location}")
            };
        }

        public (Squad? KonohaSquad, Squad? AllianceSquad) Dispatch()
        {
            Console.WriteLine($"=== Konoha Facade: Dispatching '{_request.MissionName}' ({_request.MissionRank}-Rank) to {_request.Location} ===");

            Squad? konohaSquad = null;
            Squad? allianceSquad = null;

            // 1. Build & Equip Konoha Subsystem
            if (_request.KonohaBlueprint != null)
            {
                konohaSquad = BuildSquad(_request.KonohaBlueprint, _ => _konohaFactory);
                EquipAndReadySquad(konohaSquad);
                Console.WriteLine($"[Konoha] '{konohaSquad.SquadName}' assembled and armed.");
            }

            // 2. Build & Equip Alliance Subsystem
            if (_request.AllianceBlueprint != null)
            {
                allianceSquad = BuildSquad(_request.AllianceBlueprint, SelectAllianceFactory);
                EquipAndReadySquad(allianceSquad);
                Console.WriteLine($"[Alliance] '{allianceSquad.SquadName}' assembled and armed.");
            }

            if (konohaSquad == null && allianceSquad == null)
            {
                Console.WriteLine("[Aborted] No squad blueprints provided in the request.");
            }
            else
            {
                Console.WriteLine("=== Dispatch Complete ===\n");
            }

            return (konohaSquad, allianceSquad);
        }

        private AllianceFactory SelectAllianceFactory(Location village)
        {
            _allianceFactory = village switch
            {
                Location.Sunagakure => new SunaFactory(),
                Location.Kirigakure => new KiriFactory(),
                Location.Iwagakure => new IwaFactory(),
                Location.Kumogakure => new KumoFactory(),
                _ => throw new ArgumentException($"Invalid Alliance village: {village}")
            };
            return _allianceFactory;
        }

        private Squad BuildSquad(SquadRequirement blueprint, Func<Location, VillageFactory> factorySelector)
        {
            var squad = new Squad
            {
                SquadName = blueprint.SquadName,
                Mission = _request
            };

            foreach (var ninjaReq in blueprint.RequiredNinjas)
            {
                VillageFactory factory = factorySelector(ninjaReq.Village);
                squad.Add(CreateAndDecorateNinja(ninjaReq, factory));
            }

            foreach (var subBlueprint in blueprint.SubSquads)
            {
                var subSquad = BuildSquad(subBlueprint, factorySelector);
                if (subSquad.Members.Count > 0)
                    squad.Add(subSquad);
            }

            return squad;
        }

        private Ninja CreateAndDecorateNinja(NinjaRequirement req, VillageFactory factory)
        {
            Ninja ninja = req.BaseRank switch
            {
                NinjaBaseRank.Chunin => factory.CreateChunin(req.Name, req.ChakraNature, req.Attack, req.Heal, req.HP, req.Stamina),
                NinjaBaseRank.Jonin => factory.CreateJonin(req.Name, req.ChakraNature, req.Attack, req.Heal, req.HP, req.JutsuSpecialty, req.ElementBoost),
                NinjaBaseRank.Kage => factory.CreateKage(req.Name, req.ChakraNature, req.Attack, req.Heal, req.HP, req.BijuuPool),
                _ => throw new ArgumentException("Unknown Ninja rank")
            };

            foreach (var role in req.Roles)
            {
                ninja = role switch
                {
                    TankRequirement t => new Tank(ninja, t.Endurance),
                    AnbuRequirement a => new Anbu(ninja, a.Speed),
                    MedicRequirement m => new Medic(ninja, m.HospitalCode),
                    _ => ninja
                };
            }

            return ninja;
        }

        private void EquipAndReadySquad(Squad squad)
        {
            foreach (var member in squad.Members)
            {
                if (member is Ninja ninja)
                {
                    while (ninja is Decorator decorator)
                    {
                        ninja = decorator.GetBaseNinja();
                    }

                    ninja.Weapons.AddRange(_weaponGenerator.GenerateWeaponLoadout());
                    ninja.IsReady = true;
                }
                else if (member is Squad subSquad)
                {
                    EquipAndReadySquad(subSquad);
                }
            }
        }
    }
}