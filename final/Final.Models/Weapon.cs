
namespace Weapons
{
    using Enums;

    public abstract class Weapon{
        public Chakra Chakra { get; set; }
        public int BaseDamage { get; set; }
        public double Multiplier { get; set; }
        public abstract void Attack();
    }

    public class Katana : Weapon { 
        public int Penetration { get; set; } 
        public override void Attack() { } 
    }

    public class Shuriken : Weapon { 
        public int Count { get; set; } 
        public override void Attack() { } 
    }

    public class Kunai : Weapon { 
        public double PiercingBonus { get; set; } 
        public override void Attack() { } 
    }

    public abstract class Chakra{
        public ChakraType Name { get; set; }
        public Location VillageOrigin { get; set; }
        public abstract void ApplyEffect();
    }

    public class Fire : Chakra { 
        public double BurnChance { get; set; } 
        public override void ApplyEffect() { } 
    }

    public class Water : Chakra { 
        public double FlowRate { get; set; } 
        public override void ApplyEffect() { } 

    }
    public class Wind : Chakra { 
        public double CuttingPower { get; set; } 
        public override void ApplyEffect() { } 
    }

    public class Earth : Chakra { 
        public double Hardness { get; set; } 
        public override void ApplyEffect() { } 
    }

    public class Lightning : Chakra { 
        public double StunChance { get; set; } 
        public override void ApplyEffect() { } 
    }

}