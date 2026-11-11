
using Ninjas;
using Strategies;

public class Program
{
    static void Client(Ninja attacker, Ninja target)
    {
        Console.WriteLine("--- Before Attacking ---");
        if (!attacker.IsAlive)
        {
            Console.WriteLine("Attacker is dead. Cannot attack.");
            return;
        }

        if (!target.IsAlive)
        {
            Console.WriteLine("Target is dead. Cannot attack.");
            return;
        }

        Console.WriteLine("Attacker 💥");
        attacker.Display();

        Console.WriteLine("Target 🎯");
        target.Display();

        attacker.PerformAttack(target);

        Console.WriteLine("--- Target After Attacking ---");
        target.Display();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("--- NARUTO vs SASUKE ---\n");

        Ninja naruto = new Ninja("Naruto Uzumaki") { Chakra = 100, Stamina = 100 };
        Ninja sasuke = new Ninja("Sasuke Uchiha") { Chakra = 100, Stamina = 100 };

        // Test Case 1: Taijutsu Strategy
        Console.WriteLine("--- Test 1: Taijutsu Strategy ---");
        naruto.SetStrategy(new TaijutsuStrategy("Leaf Hurricane", 25));
        Client(naruto, sasuke);

        // Test Case 2: Switching to Ninjutsu with Custom Costs
        Console.WriteLine("\n--- Test 2: Ninjutsu Strategy (Custom Costs) ---");
        naruto.SetStrategy(new NinjutsuStrategy("Rasengan", 45, 15));
        Client(naruto, sasuke);

        // Test Case 3: Default Constructor Ninjutsu
        Console.WriteLine("\n--- Test 3: Default Constructor (Chidori) ---");
        sasuke.SetStrategy(new NinjutsuStrategy(30, "Chidori"));
        Client(sasuke, naruto);

        // Test Case 4: Genjutsu Strategy
        Console.WriteLine("\n--- Test 4: Genjutsu Strategy ---");
        sasuke.SetStrategy(new GenjutsuStrategy("Demonic Illusion: Tree Binding Death", 30, 5));
        Client(sasuke, naruto);

        // Test Case 5: Attack with No Strategy
        Console.WriteLine("\n--- Test 5: Edge Case - Null Strategy ---");
        Ninja kakashi = new Ninja("Kakashi Hatake") { Chakra = 100, Stamina = 100 };
        Client(kakashi, sasuke);
    }
}
