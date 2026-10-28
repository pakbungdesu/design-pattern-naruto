using Ninjas;

namespace OffensiveGears
{
    using System;

    public abstract class OffensiveGear
    {
        public Ninja? Owner { get; set; }
        public int AddDamage { get; set; }

        public abstract void GetInfo();
        public abstract int Attack(Ninja target);
    }

    // Concrete Base Weapons
    public class Kunai : OffensiveGear
    {
        public int PiercingBonus { get; set; } = 5;

        public Kunai() => AddDamage = 15;

        public override void GetInfo()
        {
            Console.WriteLine($"    Kunai (+{AddDamage} DMG, Piercing: +{PiercingBonus})");
        }

        public override int Attack(Ninja target)
        {
            int totalDmg = AddDamage + PiercingBonus;
            Console.WriteLine($"  -> Attacks {target.Name}");
            GetInfo();
            Console.WriteLine($"     Total Damage: {totalDmg}");

            return totalDmg;
        }
    }

    public class Katana : OffensiveGear
    {
        public double CriticalMultiplier { get; set; } = 1.5;

        public Katana() => AddDamage = 30;

        public override void GetInfo()
        {
            Console.WriteLine($"    Katana (+{AddDamage} DMG, Crit: {CriticalMultiplier}x)");
        }

        public override int Attack(Ninja target)
        {
            int totalDmg = (int)(AddDamage * CriticalMultiplier);
            Console.WriteLine($"  -> Strikes {target.Name}");
            GetInfo();
            Console.WriteLine($"     Total Damage: {totalDmg}");
            return totalDmg;
        }
    }

    public class Shuriken : OffensiveGear
    {
        public int ProjectileCount { get; set; } = 3;

        public Shuriken() => AddDamage = 8;

        public override void GetInfo()
        {
            Console.WriteLine($"    Shuriken (x{ProjectileCount} Stars, +{AddDamage} DMG each)");
        }

        public override int Attack(Ninja target)
        {
            int totalDmg = AddDamage * ProjectileCount;
            Console.WriteLine($"  -> Throws {ProjectileCount} Shurikens at {target.Name}");
            GetInfo();
            Console.WriteLine($"     Total Damage: {totalDmg}");
            return totalDmg;
        }
    }

    public abstract class OffensiveDecorator : OffensiveGear
    {
        public OffensiveGear Gear { get; set; }

        public OffensiveDecorator(OffensiveGear g)
        {
            Gear = g;
            Owner = g.Owner;
        }

        public override void GetInfo() => Gear.GetInfo();
        public override int Attack(Ninja target)
        {
            return Gear.Attack(target);
        }
    }

    public class Poison : OffensiveDecorator
    {
        int PoisonDamage { get; set; } = 20;
        public Poison(OffensiveGear g) : base(g) { }

        public override void GetInfo()
        {
            Gear.GetInfo();
            Console.WriteLine($"    + [Poison] {PoisonDamage} Toxic Damage");
        }

        public override int Attack(Ninja target)
        {
            return base.Attack(target) + Poisoning(target);
        }

        private int Poisoning(Ninja target, int turns = 3)
        {
            target.ApplyPoison(turns);
            Console.WriteLine($"     [Poisoning] {target.Name} has been poisoned! Takes {PoisonDamage} toxic damage.");
            return PoisonDamage;
        }
    }

    public class ExplosiveTag : OffensiveDecorator
    {
        public int BlastDamage { get; set; } = 35;
        public ExplosiveTag(OffensiveGear g) : base(g) { }

        public override void GetInfo(){
            Gear.GetInfo();
            Console.WriteLine($"    + [Explosive Tag] {BlastDamage} Blast Damage");
        }

        public override int Attack(Ninja target)
        {
            return base.Attack(target) + Bomb(target);
        }

        private int Bomb(Ninja target)
        {
            Console.WriteLine($"     [Bomb] Explosive Tag detonates on {target.Name}! Takes {BlastDamage} blast damage.");
            return BlastDamage;
        }
    }
}