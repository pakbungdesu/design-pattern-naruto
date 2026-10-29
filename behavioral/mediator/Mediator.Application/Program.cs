using System;
using System.Collections.Generic;
using colleagues;
using mediators;

class Program
{
    static void Main(string[] args)
    {
        SummitMediator hqMediator = new SummitMediator();

        TankNinja tank1 = new TankNinja("Naruto Uzumaki", 100, 50, 85, "hall", hqMediator);
        TankNinja tank2 = new TankNinja("Sasuke Uchiha", 90, 60, 80, "hall", hqMediator);
        TankNinja tank3 = new TankNinja("Rock Lee", 80, 55, 90, "hall", hqMediator);
        TankNinja tank4 = new TankNinja("Choji Akimichi", 120, 45, 95, "hall", hqMediator);
        TankNinja tank5 = new TankNinja("Neji Hyuga", 85, 50, 75, "hall", hqMediator);

        hqMediator.AddTank(tank1);
        hqMediator.AddTank(tank2);
        hqMediator.AddTank(tank3);
        hqMediator.AddTank(tank4);
        hqMediator.AddTank(tank5);

        AnbuNinja anbu1 = new AnbuNinja("Kakashi Hatake", 100, 70, "hall", "Cat Mask", hqMediator);
        AnbuNinja anbu2 = new AnbuNinja("Yamato", 90, 60, "hall", "Wood Mask", hqMediator);
        AnbuNinja anbu3 = new AnbuNinja("Sai", 85, 55, "hall", "Ink Mask", hqMediator);

        hqMediator.AddAnbu(anbu1);
        hqMediator.AddAnbu(anbu2);
        hqMediator.AddAnbu(anbu3);

        MedicalNinja medic1 = new MedicalNinja("Sakura Haruno", 90, 40, hqMediator, "meeting room");
        MedicalNinja medic2 = new MedicalNinja("Tsunade Senju", 100, 60, hqMediator, "meeting room");

        hqMediator.AddMedic(medic1);
        hqMediator.AddMedic(medic2);

        List<Enemy> heavyEnemyWave = new List<Enemy>
        {
            new Enemy("Pain Path 1", 100, 95, "hall"),
            new Enemy("Pain Path 2", 100, 95, "hall"),
            new Enemy("Pain Path 3", 100, 90, "hall")
        };

        List<Enemy> EnemyWave2 = new List<Enemy>
        {
            new Enemy("Pain Path 4", 100, 95, "rooftop"),
            new Enemy("Pain Path 5", 100, 95, "rooftop"),
            new Enemy("Pain Path 6", 100, 90, "rooftop")
        };

        Console.WriteLine("==================================================");
        Console.WriteLine("    STARTING SUMMIT DEFENSE FULL SIMULATION       ");
        Console.WriteLine("==================================================");

        // --- TEST 1: Tank Invasion Detection ---
        Console.WriteLine("\n[TEST 1] Tank triggers 'invasion detected'...");
        tank1.Location = "hall";
        tank1.Notify("invasion detected");

        // --- TEST 2: Tank Combat with Low Winrate Triggering Evacuation ---
        Console.WriteLine("\n[TEST 2] Tank triggers 'tank is fighting' in Hall with low winrate...");
        tank1.Location = "hall";
        int hallWinrate = hqMediator.EvaluateCombatPower(heavyEnemyWave, "tank");
        tank1.Notify("tank is fighting", hallWinrate);

        // --- TEST 3: ANBU Perimeter Breach ---
        Console.WriteLine("\n[TEST 3] ANBU triggers 'perimeter breached'...");
        anbu1.Location = "rooftop";
        anbu1.Notify("perimeter breached");

        // --- TEST 4: ANBU Combat with Low Winrate ---
        Console.WriteLine("\n[TEST 4] ANBU triggers 'anbu is fighting' on Rooftop with low winrate...");
        anbu2.Location = "rooftop";
        int anbuWinrate = hqMediator.EvaluateCombatPower(heavyEnemyWave, "anbu");
        anbu2.Notify("anbu is fighting", anbuWinrate);

        // --- TEST 5: Tank Critical Injuries Report ---
        Console.WriteLine("\n[TEST 5] Tank reports 'tank critical injuries'...");
        tank3.Location = "dock";
        tank3.Notify("tank critical injuries");

        // --- TEST 6: ANBU Critical Injuries Report ---
        Console.WriteLine("\n[TEST 6] ANBU reports 'anbu critical injuries'...");
        anbu3.Location = "rooftop";
        anbu3.Notify("anbu critical injuries");

        // --- TEST 7: Medic Needs Covering ---
        Console.WriteLine("\n[TEST 7] Medic reports 'Medic needs covering'...");
        medic1.Location = "dock";
        medic1.Notify("Medic needs covering");

        // --- TEST 8: General Backup Request ---
        Console.WriteLine("\n[TEST 8] Tank requests backup...");
        tank4.Location = "outside gate";
        tank4.Notify("request backup");

        // --- TEST 9: Finish Simulation & Loop Heal ---
        Console.WriteLine("\n[TEST 9] Triggering 'finish' protocol ...");
        tank1.Notify("finish");

        Console.WriteLine("\n==================================================");
        Console.WriteLine("       SIMULATION COMPLETED SUCCESSFULLY          ");
        Console.WriteLine("==================================================");
    }
}