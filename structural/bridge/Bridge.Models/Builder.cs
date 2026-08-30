using GearMakings;
using CombatGears;
using Chakras;
using Ninjas;


namespace Builders
{
    public interface NinjaBuilder
    {
        void Reset();
        void SetName(string name);
        void BuildWeapon(Chakra chakra);
        void BuildDefence(Chakra chakra);
        void BuildUniform(Chakra chakra);
        void BuildCloak(Chakra chakra);
        void BuildJacket(Chakra chakra);
        Ninja GetResult();
    }

    public class StandardNinjaBuilder : NinjaBuilder
    {
        private Ninja _ninja = new Ninja("Anonymous Standard Ninja");
        private readonly WeaponMaking _weaponFactory = new();
        private readonly DefenceMaking _defenceFactory = new();
        private readonly OutfitMaking _outfitFactory = new();

        public void Reset() => _ninja = new Ninja("Anonymous Standard Ninja");
        public void SetName(string name) => _ninja.Name = name;

        public void BuildWeapon(Chakra chakra) =>
            _ninja.Weapons.Add((Weapon)_weaponFactory.CreateGear(chakra));

        public void BuildDefence(Chakra chakra) =>
            _ninja.Defences.Add((Defence)_defenceFactory.CreateGear(chakra));

        public void BuildUniform(Chakra chakra) =>
            _ninja.Uniform = (Outfit)_outfitFactory.CreateGear(chakra);

        public void BuildCloak(Chakra chakra) =>
            _ninja.AddOn = (Outfit)_outfitFactory.CreateGear(chakra);

        public void BuildJacket(Chakra chakra) =>
            _ninja.AddOn = (Outfit)_outfitFactory.CreateGear(chakra);

        public Ninja GetResult() => _ninja;
    }

    public class PremiumNinjaBuilder : NinjaBuilder
    {
        private Ninja _ninja = new Ninja("Anonymous Premium Ninja");
        private readonly WeaponMaking _weaponFactory = new();
        private readonly DefenceMaking _defenceFactory = new();
        private readonly OutfitMaking _outfitFactory = new();

        public void Reset() => _ninja = new Ninja("Anonymous Premium Ninja");
        public void SetName(string name) => _ninja.Name = name;

        public void BuildWeapon(Chakra chakra) =>
            _ninja.Weapons.Add((Weapon)_weaponFactory.CreateGear(chakra));

        public void BuildDefence(Chakra chakra) =>
            _ninja.Defences.Add((Defence)_defenceFactory.CreateGear(chakra));

        public void BuildUniform(Chakra chakra) =>
            _ninja.Uniform = (Outfit)_outfitFactory.CreateGear(chakra);

        public void BuildCloak(Chakra chakra) =>
            _ninja.AddOn = (Outfit)_outfitFactory.CreateGear(chakra);

        public void BuildJacket(Chakra chakra) =>
            _ninja.AddOn = (Outfit)_outfitFactory.CreateGear(chakra);

        public Ninja GetResult() => _ninja;
    }
}