
namespace Ninjas
{
    using Strategies;

    public class Ninja
    {
        public string Name;
        public CombatStrategy? CurrentStrategy;
        public int Chakra;
        public int Stamina;
        public bool IsHullucinated = false;
        public bool IsAlive => Chakra > 0 && Stamina > 0;

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
            string thisStrategy = CurrentStrategy != null ? $"{CurrentStrategy.GetType()}" : "None";

            Console.WriteLine($"Name: {Name} | Chakra: {Chakra} | Stamina: {Stamina} | Current Strategy: {thisStrategy} | Is Alive? {IsAlive}");
        }

        public void PerformAttack(Ninja target)
        {
            if (CurrentStrategy == null) return;

            CurrentStrategy.Display();
            CurrentStrategy.ExecuteJutsu(target);
        }
    }
}