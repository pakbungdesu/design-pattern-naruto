using System;
using Envs;
using States;
using Contexts;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== STARTING NINJA STATE PATTERN SIMULATION ===");
        
        Ninja shinobi = new Ninja(new Stealth());
        Console.WriteLine("\n--- Test 1 ---");
        shinobi.PerformAction(enemies: 2, members: 5, overallChakraPercentage: 75f); 

        Console.WriteLine("\n--- Test 2 ---");
        shinobi.PerformAction(enemies: 8, members: 3, overallChakraPercentage: 30f); 
        // Expected: Should switch to Evacuate

        Console.WriteLine("\n--- Test 3 ---");
        shinobi.PerformAction(enemies: 1, members: 4, overallChakraPercentage: 85f); 
        // Expected: Should switch to Assault

        Console.WriteLine("\n--- Test 4 ---");
        shinobi.EnvironmentChanged(Env.Fire, overallChakraPercentage: 60f, allMembers: 10, membersEnv: 7);
        // Expected: Native members >= 60%, stays in Assault with full force

        Console.WriteLine("\n--- Test 5 ---");
        shinobi.EnvironmentChanged(Env.Water, overallChakraPercentage: 60f, allMembers: 10, membersEnv: 5);
        // Expected: Native members 40~60%, switches to Stealth

        Console.WriteLine("\n--- Test 6 ---");
        shinobi.EnvironmentChanged(Env.Earth, overallChakraPercentage: 20f, allMembers: 10, membersEnv: 2);
        // Expected: Lack of native members and low chakra, switches to Evacuate

        Console.WriteLine("\n--- Test 7 ---");
        shinobi.DisplayCurrentState();
        Console.WriteLine("\n=== SIMULATION COMPLETED ===");
    }
}
