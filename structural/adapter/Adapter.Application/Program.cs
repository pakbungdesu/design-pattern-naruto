using BattleFields;
using ChakraAdapters;
using ChakraSources;
using Elements;
using Ninjas;
using Jutsus;

class Program
{
    static void ClientTurn(Ninja attacker, int jutsuIndex, Ninja target, ChakraSource source)
    {
        Console.WriteLine($"\n--- {attacker.Name} attacks {target.Name} ---");
        
        if (jutsuIndex < 0 || jutsuIndex >= attacker.Jutsus.Count)
        {
            Console.WriteLine("Invalid jutsu selection.");
            return;
        }

        Element jutsuElement = attacker.Jutsus[jutsuIndex].Element;
        int rawDamage = attacker.Cast(jutsuIndex, target, source);

        if (rawDamage > 0)
        {
            target.Defend(rawDamage, jutsuElement);
        }
    }

    static void Main(string[] args)
    {
        BattleField mountainPeak = new BattleField(Element.Wind, naturalChakraPool: 2000);
        ChakraSource chakraAdapter = new ChakraAdapter(mountainPeak);

        Ninja naruto = new Ninja("Naruto", Element.Wind, personalChakra: 150, health: 150, attackMultiplier: 1.5);
        Ninja sasuke = new Ninja("Sasuke", Element.Lightning, personalChakra: 100, health: 150, attackMultiplier: 1.5);

        Jutsu rasengan = new Jutsu("Rasengan", Element.Wind, cost: 40);
        Jutsu chidori = new Jutsu("Chidori", Element.Lightning, cost: 30);
        naruto.Jutsus.Add(rasengan);
        sasuke.Jutsus.Add(chidori);

        Console.WriteLine("=== Initial State ===");
        Console.WriteLine($"{naruto.Name} HP: {naruto.Health}, Chakra: {naruto.PersonalChakra}");
        Console.WriteLine($"{sasuke.Name} HP: {sasuke.Health}, Chakra: {sasuke.PersonalChakra}");
        Console.WriteLine($"Field Natural Energy: {mountainPeak.NaturalChakraPool}");

        // Naruto's Turn:
        // - Gathers 40 natural chakra with 1.5x Wind affinity = +60 chakra (Pool: 2000 -> 1960)
        // - Spends 40 chakra (Chakra: 100 + 60 - 40 = 120)
        // - Attack: 40 * 1.5 = 60 base damage
        // - Defend: Wind vs Lightning defender = 1.5x -> 90 damage taken (Sasuke HP: 150 -> 60)
        ClientTurn(naruto, 0, sasuke, chakraAdapter);

        Console.WriteLine($"\n--- After Naruto's Turn ---");
        Console.WriteLine($"{naruto.Name} Chakra: {naruto.PersonalChakra} | HP: {naruto.Health}");
        Console.WriteLine($"{sasuke.Name} Chakra: {sasuke.PersonalChakra} | HP: {sasuke.Health}");
        Console.WriteLine($"Field Natural Energy: {mountainPeak.NaturalChakraPool}");

        // Sasuke's Turn:
        // - Gathers 30 natural chakra with 1.0x non-matching rate = +30 chakra (Pool: 1960 -> 1930)
        // - Spends 30 chakra (Chakra: 100 + 30 - 30 = 100)
        // - Attack: 30 * 1.5 = 45 base damage
        // - Defend: Lightning vs Wind defender = 0.5x resisted -> 22 damage taken (Naruto HP: 150 -> 128)
        ClientTurn(sasuke, 0, naruto, chakraAdapter);

        Console.WriteLine($"\n--- After Sasuke's Turn ---");
        Console.WriteLine($"{naruto.Name} Chakra: {naruto.PersonalChakra} | HP: {naruto.Health}");
        Console.WriteLine($"{sasuke.Name} Chakra: {sasuke.PersonalChakra} | HP: {sasuke.Health}");
        Console.WriteLine($"Field Natural Energy: {mountainPeak.NaturalChakraPool}");
    }
}