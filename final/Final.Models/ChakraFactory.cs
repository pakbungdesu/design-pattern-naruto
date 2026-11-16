
namespace ChakraFactories
{
    using Enums;
    using Weapons;
    using Ninjas;
    using Requests;

    public abstract class ChakraGenerator
    {
        protected readonly WeaponRequirement _weaponReq;

        protected ChakraGenerator(WeaponRequirement weaponReq)
        {
            _weaponReq = weaponReq;
        }

        public abstract Chakra CreateChakra();
        public List<Weapon> GenerateWeaponLoadout()
        {
            Chakra missionChakra = CreateChakra();
            List<Weapon> loadout =
            [
                new Katana(missionChakra, _weaponReq.KatanaBaseDamage, _weaponReq.KatanaPenetration),
                new Shuriken(missionChakra, _weaponReq.ShurikenBaseDamage, _weaponReq.ShurikenCount),
            ];
            
            for (int i = 0; i < _weaponReq.KunaiCount; i++)
            {
                loadout.Add(new Kunai(missionChakra, _weaponReq.KunaiBaseDamage, _weaponReq.KunaiPiercingBonus));
            }

            return loadout;
        }
    }

    public class KonohaChakraGenerator : ChakraGenerator
    {
        public KonohaChakraGenerator(WeaponRequirement req) : base(req) { }
        public override Chakra CreateChakra() 
            => new Fire(ChakraType.Fire, Location.Konohagakure, _weaponReq.ChakraStats.BurnChance);
    }

    public class SunaChakraGenerator : ChakraGenerator
    {
        public SunaChakraGenerator(WeaponRequirement req) : base(req) { }
        public override Chakra CreateChakra() 
            => new Wind(ChakraType.Wind, Location.Sunagakure, _weaponReq.ChakraStats.CuttingPower);
    }

    public class KiriChakraGenerator : ChakraGenerator
    {
        public KiriChakraGenerator(WeaponRequirement req) : base(req) { }
        public override Chakra CreateChakra() 
            => new Water(ChakraType.Water, Location.Kirigakure, _weaponReq.ChakraStats.FlowRate);
    }

    public class IwaChakraGenerator : ChakraGenerator
    {
        public IwaChakraGenerator(WeaponRequirement req) : base(req) { }
        public override Chakra CreateChakra() 
            => new Earth(ChakraType.Earth, Location.Iwagakure, _weaponReq.ChakraStats.Hardness);
    }

    public class KumoChakraGenerator : ChakraGenerator
    {
        public KumoChakraGenerator(WeaponRequirement req) : base(req) { }
        public override Chakra CreateChakra() 
            => new Lightning(ChakraType.Lightning, Location.Kumogakure, _weaponReq.ChakraStats.StunChance);
    }
}