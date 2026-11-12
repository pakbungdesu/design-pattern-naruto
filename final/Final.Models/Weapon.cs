
namespace Weapons
{
    using Enums;
    using Ninjas;

    public abstract class Weapon{
        public Chakra Chakra { get; set; }
        public int BaseDamage { get; set; }
        protected Weapon(Chakra chakra, int baseDamage){
            Chakra = chakra;
            BaseDamage = baseDamage;
        }
        public abstract void Attack(Ninja target);
        public abstract void Display();
    }

    public class Katana : Weapon { 
        public int Penetration { get; set; } 
        
        public Katana(Chakra chakra, int baseDamage, int penetration) : base(chakra, baseDamage){
            Penetration = penetration;
        }

        public override void Display()
        {
            Console.WriteLine($"Katana with base damage {BaseDamage}, penetration {Penetration}, and chakra type {Chakra.Name}");
        }

        public override void Attack(Ninja target)
        {
            int totalDamage = BaseDamage + Penetration;
            totalDamage = Chakra.ApplyEffect(totalDamage);
            Console.WriteLine($"Attacking {target.Name} with Katana, dealing {totalDamage} damage.");
            
            target.HP -= totalDamage;
        } 
    }

    public class Shuriken : Weapon { 
        public int Count { get; set; } 

        public Shuriken(Chakra chakra, int baseDamage, int count) : base(chakra, baseDamage){
            Count = count;
        }

        public override void Display()
        {
            Console.WriteLine($"Shuriken with base damage {BaseDamage}, count {Count}, and chakra type {Chakra.Name}");
        }

        public override void Attack(Ninja target)
        {
            int totalDamage = BaseDamage * Count;
            totalDamage = Chakra.ApplyEffect(totalDamage);
            Console.WriteLine($"Attacking {target.Name} with Shuriken, dealing {totalDamage} damage.");

            target.HP -= totalDamage;
        } 
    }

    public class Kunai : Weapon { 
        public double PiercingBonus { get; set; } 

        public Kunai(Chakra chakra, int baseDamage, double piercingBonus) : base(chakra, baseDamage){
            PiercingBonus = piercingBonus;
        }

        public override void Display()
        {
            Console.WriteLine($"Kunai with base damage {BaseDamage}, piercing bonus {PiercingBonus}, and chakra type {Chakra.Name}");
        }

        public override void Attack(Ninja target)
        {
            int totalDamage = BaseDamage + (int)(BaseDamage * PiercingBonus);
            totalDamage = Chakra.ApplyEffect(totalDamage);
            Console.WriteLine($"Attacking {target.Name} with Kunai, dealing {totalDamage} damage.");

            target.HP -= totalDamage;
        }
    }

    public abstract class Chakra {
        public ChakraType Name { get; set; }
        public Location VillageOrigin { get; set; }

        protected Chakra(ChakraType name, Location villageOrigin){
            Name = name;
            VillageOrigin = villageOrigin;
        }

        public abstract int ApplyEffect(int TotalDamage);
    }

    public class Fire : Chakra { 
        public double BurnChance { get; set; } 
        public Fire(ChakraType name, Location villageOrigin, double burnChance) : base(name, villageOrigin){
            BurnChance = burnChance;
        }

        public override int ApplyEffect(int TotalDamage)
        {
            Console.WriteLine($"Applying fire effect with burn chance of {BurnChance}%");

            if (new Random().NextDouble() < BurnChance / 100)
            {
                Console.WriteLine("Burn effect applied!");
                TotalDamage += 20;
            }
            return TotalDamage;
        } 
    }

    public class Water : Chakra { 
        public double FlowRate { get; set; } 
        public Water(ChakraType name, Location villageOrigin, double flowRate) : base(name, villageOrigin){
            FlowRate = flowRate;
        }
        public override int ApplyEffect(int TotalDamage)
        {
            Console.WriteLine($"Applying water effect with flow rate of {FlowRate}");

            return (int)(TotalDamage * (1 + FlowRate));
        }

    }
    public class Wind : Chakra { 
        public int CuttingPower { get; set; } 
        public Wind(ChakraType name, Location villageOrigin, int cuttingPower) : base(name, villageOrigin){
            CuttingPower = cuttingPower;
        }
        public override int ApplyEffect(int TotalDamage)
        {
            Console.WriteLine($"Applying wind effect with cutting power of {CuttingPower}");
            return TotalDamage + CuttingPower;
        }
    }

    public class Earth : Chakra { 
        public int Hardness { get; set; } 
        public Earth(ChakraType name, Location villageOrigin, int hardness) : base(name, villageOrigin){
            Hardness = hardness;
        }
        public override int ApplyEffect(int TotalDamage)
        {
            Console.WriteLine($"Applying earth effect with hardness of {Hardness}");
            return TotalDamage * Hardness;
        } 
    }

    public class Lightning : Chakra { 
        public double StunChance { get; set; } 
        public Lightning(ChakraType name, Location villageOrigin, double stunChance) : base(name, villageOrigin){
            StunChance = stunChance;
        }
        public override int ApplyEffect(int TotalDamage)
        {
            Console.WriteLine($"Applying lightning effect with stun chance of {StunChance}%");

            if (new Random().NextDouble() < StunChance / 100)
            {
                Console.WriteLine("Stun effect applied!");
                TotalDamage += 15;
            }
            return TotalDamage;
        } 
    }

}