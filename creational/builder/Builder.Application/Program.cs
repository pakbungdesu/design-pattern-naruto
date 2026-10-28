using Builder.Models.Builder;
using Builder.Models.Director;
using Builder.Models.Ninja;

namespace Builder.Application
{
    public class Program
    {

        static void BattleSimulation(Director director)
        {
            var anbuBuilder = new AnbuBuilder();
            var tankBuilder = new TankBuilder();
            var medicBuilder = new MedicBuilder();

            Console.WriteLine("\n==========================================");
            Console.WriteLine("       TESTING BATTLE SCENARIO        ");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n--- Building Kakashi (Anbu) ---");
            director.MakeEliteSpecialist(anbuBuilder);
            Anbu kakashi = anbuBuilder.getResult();
            kakashi.name = "Kakashi Hatake"; 
            kakashi.displayInfo();

            Console.WriteLine("\n--- Building 2 Dummies(Tank) ---");
            director.MakeStandardJonin(tankBuilder);
            TankNinja dummy1 = tankBuilder.getResult();
            dummy1.name = "Dummy 1";
            dummy1.displayInfo();

            director.MakeStandardJonin(tankBuilder);
            TankNinja dummy2 = tankBuilder.getResult();
            dummy2.name = "Dummy 2";
            dummy2.displayInfo();

            Console.WriteLine("\n--- Building Sakura (Medic) ---");
            director.MakePremiumJonin(medicBuilder);
            MedicalNinja sakura = medicBuilder.getResult();
            sakura.name = "Sakura Haruno";
            sakura.displayInfo();

            Console.WriteLine("\n--- Simulating Exhaustion Scenario ---");
            bool result = true;
            int i = 0;
            while (result)
            {
                result = kakashi.attack(dummy1, "Chidori");

                if (!result)
                {
                    Console.WriteLine($"⚠️ {kakashi.name} is cannot continue the simulation!");
                    break;
                }

                result = dummy1.attack(kakashi, "Mud Wall");

                if (!result)
                {
                    Console.WriteLine($"⚠️ {dummy1.name} is cannot continue the simulation!");
                    break;
                }

                result = dummy2.attack(kakashi, "Rock Armor");

                if (!result)
                {
                    Console.WriteLine($"⚠️ {dummy2.name} is cannot continue the simulation!");
                    break;
                }

                result = kakashi.attack(dummy2, "Silent Killing");

                if (!result)
                {
                    Console.WriteLine($"⚠️ {kakashi.name} is cannot continue the simulation!");
                    break;
                }

                result = sakura.healOther(kakashi, 1, "Mystical Palm Technique");

                if (!result)
                {
                    Console.WriteLine($"⚠️ {sakura.name} is cannot continue the simulation!");
                    break;
                }

                result = sakura.healThis(1);

                 if(kakashi.chakra == 0 || dummy1.chakra == 0 || dummy2.chakra == 0 || sakura.chakra == 0)
                {
                    if(kakashi.chakra == 0)
                    {
                        kakashi.isDefeated = true;
                        Console.WriteLine($"⚠️ {kakashi.name} is out of chakra and cannot continue the simulation!");
                    }

                    if(dummy1.chakra == 0)
                    {
                        dummy1.isDefeated = true;
                        Console.WriteLine($"⚠️ {dummy1.name} is out of chakra and cannot continue the simulation!");
                    }
                    
                    if(dummy2.chakra == 0)
                    {
                        dummy2.isDefeated = true;
                        Console.WriteLine($"⚠️ {dummy2.name} is out of chakra and cannot continue the simulation!");
                    }

                    if(sakura.chakra == 0)
                    {
                        sakura.isDefeated = true;
                        Console.WriteLine($"⚠️ {sakura.name} is out of chakra and cannot continue the simulation!");
                    }
                    break;
                }

                Console.WriteLine($"\n--- After Round {i + 1} ---");
                kakashi.displayInfo();
                dummy1.displayInfo();
                dummy2.displayInfo();
                sakura.displayInfo();
                i++;
            }
        }

        public static void Main()
        {
            Director director = new Director();
            BattleSimulation(director);

            AnbuBuilder anbuBuilder = new AnbuBuilder();
            anbuBuilder.buildBaseAttack();

            Anbu ninja = anbuBuilder.getResult();

            TankBuilder tankBuilder = new TankBuilder();
            tankBuilder.buildBody();
            tankBuilder.buildBaseHealPerMinute();

            TankNinja tankNinja = tankBuilder.getResult();

            Console.WriteLine("\nAnbu manual");
            ninja.displayInfo();

            Console.WriteLine("\nTank manual");
            tankNinja.displayInfo();
        }
    }
}