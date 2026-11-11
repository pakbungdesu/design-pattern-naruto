
using Ninjas;

namespace Strategies
{
    using Ninjas;

    public abstract class CombatStrategy
    {
        public abstract void ExecuteJutsu(Ninja target);
        public abstract void Display();
        public int StaminaCost { get; set; }

    }

    public class TaijutsuStrategy : CombatStrategy
    {
        public string StyleName = "Anonymous Taijutsu";
        public int ChakraCost = 0;
        public TaijutsuStrategy(string styleName, int staminaCost)
        {
            StyleName = styleName;
            StaminaCost = staminaCost;
        }

        public override void Display()
        {
            Console.WriteLine($"Style Name: {StyleName}, Chakra Cost: {ChakraCost}, Stamina Cost: {StaminaCost}");
        }

        public override void ExecuteJutsu(Ninja target)
        {
            Console.WriteLine($"Executing {StyleName}! Unleashing high-speed physical combos.");
            target.Stamina -= StaminaCost;
        }
    }

    public class NinjutsuStrategy : CombatStrategy
    {
        public string JutsuName = "Anonymous Ninjutsu";
        public int ChakraCost = 0;

        public NinjutsuStrategy(int chakraCost, string jutsuName)
        {
            JutsuName = jutsuName;
            ChakraCost = chakraCost;
            StaminaCost = 10;
        }

        public NinjutsuStrategy(string jutsuName, int chakraCost, int staminaCost)
        {
            JutsuName = jutsuName;
            ChakraCost = chakraCost;
            StaminaCost = staminaCost;
        }

        public override void Display()
        {
            Console.WriteLine($"Style Name: {JutsuName}, Chakra Cost: {ChakraCost}, Stamina Cost: {StaminaCost}");
        }

        public override void ExecuteJutsu(Ninja target)
        {
            Console.WriteLine($"Executing {JutsuName}! Concentrating spinning chakra for massive impact.");
            target.Chakra -= ChakraCost;
            target.Stamina -= StaminaCost;
        }
    }

    public class GenjutsuStrategy : CombatStrategy
    {
        public string IllusionType = "Anonymous Genjutsu";
        public int ChakraCost = 0;
        public GenjutsuStrategy(string it)
        {
            IllusionType = it;
            ChakraCost = 30;
            StaminaCost = 5;
        }

        public GenjutsuStrategy(string it, int chakraCost, int staminaCost)
        {
            IllusionType = it;
            ChakraCost = chakraCost;
            StaminaCost = staminaCost;
        }

        public override void Display()
        {
            Console.WriteLine($"Style Name: {IllusionType}, Chakra Cost: {ChakraCost}, Stamina Cost: {StaminaCost}");
        }

        public override void ExecuteJutsu(Ninja target)
        {
            Console.WriteLine($"Executing {IllusionType}! Disrupting opponent's chakra network.");
            target.Chakra -= ChakraCost;
            target.Stamina -= StaminaCost;
            target.IsHullucinated = true;
        }
    }
}