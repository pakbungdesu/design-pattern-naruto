using CombatGears;
using Chakras;

namespace GearMakings
{
    public abstract class GearMaking
    {
        // Factory Method
        public abstract CombatGear CreateGear(Chakra chakra);

        // Template Operation
        public CombatGear ComposeCombatGear(Chakra chakra, string modelName, double multiplier)
        {
            CombatGear gear = CreateGear(chakra);
            gear.ModelName = modelName;
            gear.Multiplier = multiplier;
            gear.PrepareMaterial();
            gear.Enchant();
            return gear;
        }
    }

    public class WeaponMaking : GearMaking
    {
        public override CombatGear CreateGear(Chakra chakra) => new Weapon(chakra);
    }

    public class DefenceMaking : GearMaking
    {
        public override CombatGear CreateGear(Chakra chakra) => new Defence(chakra);
    }

    public class OutfitMaking : GearMaking
    {
        public override CombatGear CreateGear(Chakra chakra) => new Outfit(chakra);
    }
}