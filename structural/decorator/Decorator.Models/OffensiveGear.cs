using Ninjas;

namespace OffensiveGears
{
    using System;

    public abstract class OffensiveGear
    {
        public Ninja? Owner { get; set; }
        public int AddDamage { get; set; }

        public abstract string GetInfo();
        public abstract int Attack(Ninja target);
    }

    // Concrete Base Weapons
    public class Kunai : OffensiveGear
    {
        public int PiercingBonus { get; set; } = 5;

        public Kunai() => AddDamage = 15;

        public override string GetInfo() => $"Kunai (+{AddDamage} DMG, Piercing: +{PiercingBonus})";

        public override int Attack(Ninja target)
        {
            int totalDmg = AddDamage + PiercingBonus;
            Console.WriteLine($"  -> Attacks {target.Name} with {GetInfo()} dealing {totalDmg} damage.");
            return totalDmg;
        }
    }

    public class Katana : OffensiveGear
    {
        public double CriticalMultiplier { get; set; } = 1.5;

        public Katana() => AddDamage = 30;

        public override string GetInfo() => $"Katana (+{AddDamage} DMG, Crit: {CriticalMultiplier}x)";

        public override int Attack(Ninja target)
        {
            int totalDmg = (int)(AddDamage * CriticalMultiplier);
            Console.WriteLine($"  -> Strikes {target.Name} with {GetInfo()} dealing {totalDmg} critical damage.");
            return totalDmg;
        }
    }

    public class Shuriken : OffensiveGear
    {
        public int ProjectileCount { get; set; } = 3;

        public Shuriken() => AddDamage = 8;

        public override string GetInfo() => $"Shuriken (x{ProjectileCount} Stars, +{AddDamage} DMG each)";

        public override int Attack(Ninja target)
        {
            int totalDmg = AddDamage * ProjectileCount;
            Console.WriteLine($"  -> Throws {ProjectileCount} Shurikens at {target.Name} dealing {totalDmg} total damage.");
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

        public override string GetInfo() => Gear.GetInfo();
        public override int Attack(Ninja target)
        {
            return Gear.Attack(target);
        }
    }

    public class Poison : OffensiveDecorator
    {
        public Poison(OffensiveGear g) : base(g) { }

        public override string GetInfo() => $"{Gear.GetInfo()} + [Poison]";

        public override int Attack(Ninja target)
        {
            return base.Attack(target) + Poisoning(target);
        }

        public int Poisoning(Ninja target, int turns = 3)
        {
            target.ApplyPoison(turns);
            Console.WriteLine($"     [Poisoning] {target.Name} has been poisoned! Takes 20 toxic damage.");
            return 20;
        }
    }

    public class ExplosiveTag : OffensiveDecorator
    {
        public ExplosiveTag(OffensiveGear g) : base(g) { }

        public override string GetInfo() => $"{Gear.GetInfo()} + [Explosive Tag]";

        public override int Attack(Ninja target)
        {
            return base.Attack(target) + Bomb(target);
        }

        public int Bomb(Ninja target)
        {
            Console.WriteLine($"     [Bomb] Explosive Tag detonates on {target.Name}! Takes 35 blast damage.");
            return 35;
        }
    }
}