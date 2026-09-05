using Elements;
using ChakraSources;
using Jutsus;

// Client
namespace Ninjas
{
    public class Ninja
    {
        public string Name { get; set; }
        public Element AffinityElement { get; set; }
        public int PersonalChakra { get; private set; }
        public int Health { get; set; }
        public double AttackMultiplier { get; set; }
        public List<Jutsu> Jutsus { get; set; } = new List<Jutsu>();

        public Ninja(string name, Element affinityElement, int personalChakra, int health, double attackMultiplier = 1.5)
        {
            Name = name;
            Health = health;
            AffinityElement = affinityElement;
            PersonalChakra = personalChakra;
            AttackMultiplier = attackMultiplier;
        }

        public void AddChakra(int amount) => PersonalChakra += amount;
        public bool CanAfford(int cost) => PersonalChakra >= cost;
        public void SpendChakra(int cost) => PersonalChakra -= cost;

        private double GetElementalResistance(Element defenderElem, Element attackElem)
        {
            if (IsStrongAgainst(defenderElem, attackElem)) 
                return 0.5; // Reduced damage

            if (IsStrongAgainst(attackElem, defenderElem)) 
                return 1.5; // Critical bonus damage

            // Same element clash
            if (defenderElem == attackElem) 
                return 0.75; 

            // Neutral interactions
            return 1.0; 
        }

        private bool IsStrongAgainst(Element attacker, Element defender)
        {
            return ((int)attacker + 1) % 5 == (int)defender;
        }

        public int Cast(int jutsuIndex, Ninja target, ChakraSource source)
        {
            if (jutsuIndex < 0 || jutsuIndex >= Jutsus.Count)
            {
                Console.WriteLine($"{Name} does not have a jutsu at index {jutsuIndex}.");
                return 0;
            }

            Jutsu jutsu = Jutsus[jutsuIndex];

            // Convert external natural chakra to usable chakra
            if (source != null)
            {
                int gathered = source.HarvestUsableChakra(jutsu.Cost, AffinityElement);
                AddChakra(gathered);
            }

            // Perform battle checks and execution
            if (CanAfford(jutsu.Cost))
            {
                SpendChakra(jutsu.Cost);
                return Attack(target, jutsu);
            }
            else
            {
                Console.WriteLine($"{Name} does not have enough chakra to cast {jutsu.Name}.");
            }
            return 0;
        }

        public int Attack(Ninja target, Jutsu jutsu)
        {
            Console.WriteLine($"{Name} unleashes {jutsu.Name} on {target.Name}!");
            
            return (int)(jutsu.Cost * AttackMultiplier);
        }

        public void Defend(int incomingDamage, Element attackElement)
        {
            double multiplier = GetElementalResistance(AffinityElement, attackElement);
            int finalDamage = (int)(incomingDamage * multiplier);

            Health = Math.Max(0, Health - finalDamage);

            Console.WriteLine($"{Name} takes {finalDamage} damage! Remaining HP: {Health}");
            if (Health == 0)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }
    }
}