using Ninjas;

namespace DefensiveGears
{
    public abstract class DefensiveGear
    {
        public Ninja? Owner { get; set; }
        public int AbsorbDamage { get; set; }
        public abstract string GetInfo();
        public abstract int Defense(Ninja attacker);
    }

    public class Shield : DefensiveGear
    {
        public double BlockChance { get; set; } = 0.65;

        public Shield() => AbsorbDamage = 30;

        public override string GetInfo() => $"Shield (Absorb: {AbsorbDamage}, BlockChance: {BlockChance:P0})";

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
        public int CamouflageEvasion { get; set; } = 15;

        public Cloak() => AbsorbDamage = 10;

        public override string GetInfo() => $"Cloak (Absorb: {AbsorbDamage}, Evasion: +{CamouflageEvasion})";

        public override int Defense(Ninja attacker) => AbsorbDamage;
    }

    public class Vest : DefensiveGear
    {
        public int VitalDurability { get; set; } = 50;

        public Vest() => AbsorbDamage = 25;

        public override string GetInfo() => $"Vest (Absorb: {AbsorbDamage}, Durability: {VitalDurability})";

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

        public override string GetInfo() => Gear.GetInfo();
        public override int Defense(Ninja attacker) => Gear.Defense(attacker);
    }

    // Concrete Defensive Decorators
    public class AuraBarrier : DefensiveDecorator
    {
        public AuraBarrier(DefensiveGear g) : base(g) { }

        public override string GetInfo() => $"{Gear.GetInfo()} + [Barrier]";

        public override int Defense(Ninja attacker)
        {
            Protect();
            return Gear.Defense(attacker) + 30;
        }

        public void Protect()
        {
            Console.WriteLine("     [Protect] Barrier creates a glowing chakra shield!");
        }
    }

    public class Disguising : DefensiveDecorator
    {
        public Disguising(DefensiveGear g) : base(g) { }

        public override string GetInfo() => $"{Gear.GetInfo()} + [Disguising]";

        public override int Defense(Ninja attacker)
        {
            Disguise();
            return Gear.Defense(attacker) + 15;
        }

        public void Disguise()
        {
            if (Owner != null) Owner.CanBeSeen = false;
            Console.WriteLine("     [Disguise] Camouflaged into surroundings. Cannot be clearly seen!");
        }
    }
}