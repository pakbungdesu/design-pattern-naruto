using Ninjas;

namespace DefensiveGears
{
    public abstract class DefensiveGear
    {
        public Ninja? Owner { get; set; }
        public int AbsorbDamage { get; set; }
        public abstract void GetInfo();
        public abstract int Defense(Ninja attacker);
    }

    public class Shield : DefensiveGear
    {
        public double BlockChance { get; set; } = 0.65;

        public Shield() => AbsorbDamage = 30;

        public override void GetInfo()
        {
            Console.WriteLine($"Shield (Absorb: {AbsorbDamage}, BlockChance: {BlockChance:P0})");
        }

        public override int Defense(Ninja attacker)
        {
            double percent = new Random().NextDouble();

            if(percent > BlockChance)
            {
                return (int)(AbsorbDamage * (1 + BlockChance));
            }
            return AbsorbDamage;
        }
    }

    public class Cloak : DefensiveGear
    {
        public int CamouflageEvasion { get; set; } = 50;

        public Cloak() => AbsorbDamage = 20;

        public override void GetInfo()
        {
            Console.WriteLine($"Cloak (Absorb: {AbsorbDamage}, Evasion: +{CamouflageEvasion})");
        }

        public override int Defense(Ninja attacker) => AbsorbDamage + CamouflageEvasion;
    }

    public class Vest : DefensiveGear
    {
        public int VitalDurability { get; set; } = 50;

        public Vest() => AbsorbDamage = 25;

        public override void GetInfo()
        {
            Console.WriteLine($"Vest (Absorb: {AbsorbDamage}, Durability: {VitalDurability})");
        }

        public override int Defense(Ninja attacker) => AbsorbDamage + VitalDurability;
    }

    public abstract class DefensiveDecorator : DefensiveGear
    {
        public DefensiveGear Gear { get; set; }

        public DefensiveDecorator(DefensiveGear g)
        {
            Gear = g;
            Owner = g.Owner;
        }

        public override void GetInfo()
        {
            Gear.GetInfo();
        }
        public override int Defense(Ninja attacker) => Gear.Defense(attacker);
    }

    // Concrete Defensive Decorators
    public class AuraBarrier : DefensiveDecorator
    {
        public int Aura { get; set; } = 30;
        public AuraBarrier(DefensiveGear g) : base(g) { }

        public override void GetInfo()
        {
            Gear.GetInfo();
            Console.WriteLine($"    + [Aura Barrier] (+{Aura} DMG Absorption)"); 
        }

        public override int Defense(Ninja attacker)
        {
            Protect();
            return Gear.Defense(attacker) + Aura;
        }

        public void Protect()
        {
            Console.WriteLine("     [Protect] Barrier creates a glowing chakra shield!");
        }
    }

    public class Disguising : DefensiveDecorator
    {
        public double CamouflageEffect { get; set; } = 0.2;
        public Disguising(DefensiveGear g) : base(g) { }

        public override void GetInfo()
        {
            Gear.GetInfo();
            Console.WriteLine($"    + [Disguising] (+{CamouflageEffect * 100}% Evasion)");
        }

        public override int Defense(Ninja attacker)
        {
            Disguise();
            return Gear.Defense(attacker) * (int)(1 + CamouflageEffect);
        }

        public void Disguise(int turns = 3)
        {
            if (Owner != null) Owner.ApplyInvisibility(turns);
            Console.WriteLine("     [Disguise] Camouflaged into surroundings. Cannot be clearly seen!");
        }
    }
}