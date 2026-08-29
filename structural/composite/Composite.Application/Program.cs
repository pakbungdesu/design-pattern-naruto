using Squads;
using Ninjas;
using Missions;
using MissionRanks;

public class Program
{
    public static void ExecuteTurn(List<Ninja> actingTeam, List<Ninja> opposingTeam)
    {
        foreach (var actor in actingTeam.Where(u => !u.IsDefeated))
        {
            if (actor is Medic medic)
            {
                var woundedAlly = actingTeam
                                    .Where(u => !u.IsDefeated && u.Chakra < 4000)
                                    .OrderBy(_ => Guid.NewGuid())
                                    .FirstOrDefault();

                if (woundedAlly != null)
                {
                    var condition = medic.HealFactors.Keys.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();

                    if (condition != null)
                    {
                        medic.healOther(woundedAlly, minutes: 5, conditionKey: condition);
                    }
                    
                    continue;
                }
            }

            var target = opposingTeam
                            .Where(u => !u.IsDefeated)
                            .OrderBy(_ => Guid.NewGuid())
                            .FirstOrDefault();

            if (target == null) break;

            var jutsuKey = actor.AttackFactors.Count > 0 
                ? actor.AttackFactors.Keys.OrderBy(_ => Guid.NewGuid()).FirstOrDefault(): null;

            if(jutsuKey != null)
            {
                Console.WriteLine($"\n🎯 {actor.Name} attacks {target.Name}!");
                int damage = actor.Attack(target, jutsuKey);

                if (damage > 0)
                {
                    target.Defend(damage);
                }
            }
        }
    }

    public static void Client(Squad squad, Mission mission)
    {
        try
        {
            Console.WriteLine($"\n[Attempt] Assigning {squad.Name} to Rank A Mission...");
            mission.AssignUnit(squad);
            mission.StartMission();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"❌ {ex.Message}");
        }
    }

    public static void Main()
    {
        // Mission
        // Require 10 Anbu, 1 Medic
        Mission rankSMission = new Mission("Infiltrate & Assassinate Rogue Leader", MissionRank.S);
        // Require 10 Tank, 1 Medic
        Mission rankAMission = new Mission("Defend Border Stronghold", MissionRank.A);

        // Squad 1
        Squad squadAlpha = new Squad("Team Alpha (Shadow Operatives)");

        // Sub-squads 1 (Leaves inside Composites)
        Squad subSquad1 = new Squad("Alpha Recon Team");
        Anbu kakashi = new Anbu("Kakashi", "Hound", mask: "Dog", specialEyes: "Sharingan")
        {
            Chakra = 6000, Shield = 4000, BaseAttack = 350, ChakraCost = 0.12,
            AttackFactors = { { "Chidori", 3.0 }, { "Kamui", 4.5 } }
        };

        Medic shizune = new Medic("Shizune")
        {
            Chakra = 4000, Shield = 2500, BaseAttack = 120, BaseHealPerMinute = 4.0,
            HealFactors = { { "PoisonMistRecovery", 2 } }
        };

        subSquad1.Add(kakashi);
        subSquad1.Add(shizune);


        // Sub-squads 2 (Leaves inside Composites)
        Squad subSquad2 = new Squad("Alpha Infiltration Team");
        Anbu itachi = new Anbu("Itachi", "Weasel", mask: "Crow", specialEyes: "Mangekyo Sharingan")
        {
            Chakra = 4500, Shield = 3000, BaseAttack = 400, ChakraCost = 0.15,
            AttackFactors = { { "Amaterasu", 5.0 }, { "Tsukuyomi", 2.5 } }
        };

        subSquad2.Add(itachi);

        // Nested Composite (Squad inside a Squad)
        squadAlpha.Add(subSquad1);
        squadAlpha.Add(subSquad2);

        // Fail because there are only 2 Anbu, 1 Medic
        Console.WriteLine("\n=================== RankS Mission Test 1 =====================");
        Client(squadAlpha, rankSMission);

        for (int i = 1; i <= 8; i++)
        {
            squadAlpha.Add(new Anbu($"Anbu_Operative_{i}", $"Shadow_{i}"));
        }

        // Pass
        Console.WriteLine("\n=================== RankS Mission Test 2 =====================");
        Client(squadAlpha, rankSMission);

        // Build Squad Bravo: Needs >= 10 Tanks & >= 1 Medic for Rank A
        Squad squadBravo = new Squad("Team Bravo (Frontline Vanguard)");
        subSquad1 = new Squad("Bravo Recon Team1");

        // Composite
        for (int i = 1; i <= 5; i++)
        {
            subSquad1.Add(new Tank($"Frontline_Tank_{i}"));
        }

        squadBravo.Add(subSquad1);

        // Fail
        Console.WriteLine("\n=================== RankA Mission Test 1 =====================");
        Client(squadBravo, rankAMission);

        subSquad2 = new Squad("Bravo Recon Team2");

        for (int i = 6; i <= 10; i++)
        {
            subSquad2.Add(new Tank($"Frontline_Tank_{i}"));
        }

        squadBravo.Add(subSquad2);


        // Fail
        Console.WriteLine("\n=================== RankA Mission Test 2 =====================");
        Client(squadBravo, rankAMission);

        // Leaf
        squadBravo.Add(new Medic("Sakura")
        {
            Chakra = 7000, Shield = 3500, BaseAttack = 250, BaseHealPerMinute = 6.0,
            HealFactors = { { "StrengthOfAHundred", 3 } }
        });

        // Pass
        Console.WriteLine("\n=================== RankA Mission Test 3 =====================");
        Client(squadBravo, rankAMission);

        squadBravo.Remove(subSquad2);

         // Fail
        Console.WriteLine("\n=================== RankA Mission Test 4 =====================");
        Client(squadBravo, rankAMission);


        // Leaf
        squadBravo.Add(new Tank("Neji", specialEyes: "Byakugan")
        {
            Chakra = 5500, Shield = 7000, BaseAttack = 280, ChakraCost = 0.08,
            AttackFactors = { { "EightTrigrams64Palms", 2.8 }, { "AirPalm", 1.8 } }
        });
        squadBravo.Add(new Tank("Choji", specialEyes: "None")
        {
            Chakra = 6500, Shield = 8000, BaseAttack = 320, ChakraCost = 0.1,
            AttackFactors = { { "HumanBoulder", 2.2 }, { "ButterflyBomb", 4.0 } }
        });

        squadBravo.Add(subSquad2);

        Console.WriteLine("\n=================== RankA Mission Test 5 =====================");
        Client(squadBravo, rankAMission);

        // Squad Combat Simulation
        Console.WriteLine("\n========================================");
        Console.WriteLine($"⚔️ CLASH OF SQUADS: {squadAlpha.Name} VS {squadBravo.Name} ⚔️");
        Console.WriteLine("========================================");

        var alphaUnits = squadAlpha.Members.OfType<Ninja>().ToList();
        var bravoUnits = squadBravo.Members.OfType<Ninja>().ToList();

        int round = 1;
        while (alphaUnits.Any(u => !u.IsDefeated) && bravoUnits.Any(u => !u.IsDefeated) && round <= 5)
        {
            Console.WriteLine($"\n--- Round {round} ---");
            ExecuteTurn(alphaUnits, bravoUnits);
            if (bravoUnits.All(u => u.IsDefeated)) break;

            ExecuteTurn(bravoUnits, alphaUnits);
            round++;
        }

        Console.WriteLine("\n========================================");
        Console.WriteLine("🏆 FINAL RESULTS 🏆");
        Console.WriteLine("========================================");
        bool alphaWon = alphaUnits.Any(u => !u.IsDefeated);
        Console.WriteLine($"Victor: {(alphaWon ? squadAlpha.Name : squadBravo.Name)}");
    }
}