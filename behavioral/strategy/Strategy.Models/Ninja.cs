
namespace Ninjas
{
    using System.ComponentModel.DataAnnotations;
    using Strategies;

    public class Ninja
    {
        public string Name;
        public CombatStrategy CurrentStrategy = null!;
        public int Chakra;
        public int Stamina;
        public bool IsDead => Chakra > 0 && Stamina > 0;

        public Ninja(string name)
        {
            Name = name;
        }

        public void SetStrategy(CombatStrategy strategy)
        {
            CurrentStrategy = strategy;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name} | Chakra: {Chakra} | Stamina: {Stamina} | Current Strategy: {CurrentStrategy.GetType()}");
        }

        public void PerformAttack(Ninja target)
        {
            if (CurrentStrategy == null) return;

            CurrentStrategy.ExecuteJutsu(target);
        }
    }
}