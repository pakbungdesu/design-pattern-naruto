using System;
using Builder.Models.Builder;
using Builder.Models.Director;
using Builder.Models.Ninja;

namespace Builder.Application
{
    public class Program
    {
        static void StandardBattleSimulation(Director director)
        {
            var anbuBuilder = new AnbuBuilder();
            var tankBuilder = new TankBuilder();
            var medicBuilder = new MedicBuilder();

            Console.WriteLine("==========================================");
            Console.WriteLine("        BUILDING COMBAT SHINOBI           ");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n--- Building Kakashi (Anbu) ---");
            director.MakeEliteSpecialist(anbuBuilder);
            Anbu kakashi = anbuBuilder.getResult();
            kakashi.profile.name = "Kakashi Hatake";
            kakashi.profile.chakra = 12000;
            kakashi.profile.baseAttack = 400;
            kakashi.profile.attackFactor = 0.25;
            kakashi.displayInfo();

            Console.WriteLine("\n--- Building Neji (Tank) ---");
            director.MakeFullyEquippedNinja(tankBuilder);
            TankNinja neji = tankBuilder.getResult();
            neji.profile.name = "Neji Hyuga";
            neji.profile.chakra = 16000;
            neji.profile.baseAttack = 420;
            neji.profile.attackFactor = 0.22;
            neji.profile.attackFactors["Palms Revolving Heaven"] = 2.5;
            neji.profile.attackFactors["Eight Trigrams Sixty-Four Palms"] = 3.2;
            neji.displayInfo();

            Console.WriteLine("\n--- Building Sakura (Medic) ---");
            director.MakeFullyEquippedNinja(medicBuilder);
            MedicalNinja sakura = medicBuilder.getResult();
            sakura.profile.name = "Sakura Haruno";
            sakura.profile.chakra = 15000;
            sakura.profile.baseHealPerMinute = 300;
            sakura.profile.healFactor = 0.15;
            sakura.displayInfo();

            Console.WriteLine("\n==========================================");
            Console.WriteLine("          BATTLE SIMULATION               ");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n--- Round 1: Kakashi Opens the Fight ---");
            kakashi.profile.attack(neji.profile, "Chidori");

            Console.WriteLine("\n--- Round 2: Neji Strikes back ---");
            neji.profile.attack(kakashi.profile, "Eight Trigrams Sixty-Four Palms");

            Console.WriteLine("\n--- Round 3: Medical Intervention ---");
            sakura.profile.heal(kakashi.profile, 3, "Mystical Palm Technique");
            sakura.profile.heal(2);

            Console.WriteLine("\n--- Round 4: Kakashi Strikes Again ---");
            kakashi.profile.attack(neji.profile, "Silent Killing");
        }

        static void TestExhaustionScenario(Director director)
        {
            var anbuBuilder = new AnbuBuilder();
            var tankBuilder = new TankBuilder();

            Console.WriteLine("\n==========================================");
            Console.WriteLine("    TEST SCENARIO: CHAKRA EXHAUSTION      ");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n--- Low-Chakra Dummy (Tank) ---");
            director.MakeFullyEquippedNinja(tankBuilder);
            TankNinja dummy = tankBuilder.getResult();
            dummy.profile.name = "Dummy";
            dummy.profile.chakra = 500;
            dummy.profile.attackFactor = 0.50;
            dummy.displayInfo();
        
            Console.WriteLine("\n--- Building Kakashi (Anbu) ---");
            director.MakeEliteSpecialist(anbuBuilder);
            Anbu kakashi = anbuBuilder.getResult();
            kakashi.profile.name = "Kakashi Hatake";
            kakashi.profile.chakra = 5000;
            kakashi.profile.baseAttack = 400;
            kakashi.profile.attackFactor = 0.50;
            kakashi.displayInfo();
            
            // First attack
            Console.WriteLine("\n--- Action 1: Heavy Jutsu Execution ---");
            dummy.profile.attack(kakashi.profile, "Mud Wall");

            // Attempting to attack while out of chakra
            Console.WriteLine("\n--- Action 2: Attempting Attack After Exhaustion ---");
            dummy.profile.attack(kakashi.profile, "Rock Armor");

            // Enemy trying to attack a defeated target
            Console.WriteLine("\n--- Action 3: Target Attacking an Already Exhausted Shinobi ---");
            kakashi.profile.attack(dummy.profile, "Chidori");

            // Attempting self-heal while exhausted
            Console.WriteLine("\n--- Action 4: Attempting Self-Heal While Exhausted ---");
            dummy.profile.heal(5);
        }

        public static void Main()
        {
            Director director = new Director();
            StandardBattleSimulation(director);
            TestExhaustionScenario(director);
        }
    }
}