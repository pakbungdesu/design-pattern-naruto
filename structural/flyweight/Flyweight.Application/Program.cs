using MissionRanks;
using NinjaLicenseFactories;
using VillageManager;
using NinjaLicenses;
using CompositePart;
using Misssions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== INITIALIZING NINJA VILLAGE & FACTORY ===");
        NinjaLicenseFactory licenseFactory = new NinjaLicenseFactory();
        NinjaVillage village = new NinjaVillage();

        //  Create Flyweight Licenses via Factory
        NinjaLicense academyLicense = licenseFactory.GetFlyweight("Academy Permit", "Supervised", MissionRank.D);
        NinjaLicense chuninLicense = licenseFactory.GetFlyweight("Chunin Standard", "Standard", MissionRank.C);
        NinjaLicense joninLicense = licenseFactory.GetFlyweight("Jonin Commercial", "Advanced Command", MissionRank.B);
        NinjaLicense kageLicense = licenseFactory.GetFlyweight("Kage Special", "None", MissionRank.S);

        // Leaves
        Ninja naruto = new Ninja("Uzumaki Naruto", 90, 85, 1000, academyLicense);
        Ninja sakura = new Ninja("Haruno Sakura", 80, 75, 1000, academyLicense);
        Ninja shikamaru = new Ninja("Nara Shikamaru", 80, 75, 800, chuninLicense);
        Ninja kakashi = new Ninja("Hatake Kakashi", 95, 90, 1500, joninLicense);
        Ninja gai = new Ninja("Might Guy", 95, 90, 1500, joninLicense);
        Ninja tsunade = new Ninja("Senju Tsunade", 100, 100, 1700, kageLicense);

        // Composites
        var team7 = new Squad("Team 7");
        team7.Add(naruto);
        team7.Add(sakura);
        team7.Add(kakashi);

        var eliteSquad = new Squad("Elite Jonin Squad");
        eliteSquad.Add(kakashi);
        eliteSquad.Add(gai);

        // Add units to the Village
        village.Add(team7);
        village.Add(eliteSquad);
        village.Add(shikamaru);
        village.Add(tsunade);

        Console.WriteLine("\n=== DISPLAYING VILLAGE REGISTRY ===");
        village.Display();

        // Test Missions and License Eligibility Checks
        Console.WriteLine("\n=== TESTING MISSION ASSIGNMENTS ===");

        // Test 1: Assigning Academy-level Team 7 to an S-Rank Mission (Should Fail)
        Mission sRankMission = new Mission(MissionRank.S);
        Console.WriteLine($"\n--- Assigning Team 7 to {sRankMission.Rank}-Rank Mission ---");
        sRankMission.AssignUnit(team7);
        sRankMission.StartMission();

        // Test 2: Assigning Elite Squad to a B-Rank Mission (Should Pass)
        Mission bRankMission = new Mission(MissionRank.B);
        Console.WriteLine($"\n--- Assigning Elite Squad to {bRankMission.Rank}-Rank Mission ---");
        bRankMission.AssignUnit(eliteSquad);
        bRankMission.StartMission();

        // Test 3: Assigning Shikamaru to a C-Rank Mission (Should Pass)
        Mission cRankMission = new Mission(MissionRank.C);
        Console.WriteLine($"\n--- Assigning Shikamaru to {cRankMission.Rank}-Rank Mission ---");
        cRankMission.AssignUnit(shikamaru);
        cRankMission.StartMission();

        // Test 4: Assigning Tsunade to a A-Rank Mission (Should Pass)
        Mission aRankMission = new Mission(MissionRank.A);
        Console.WriteLine($"\n--- Assigning Tsunade to {aRankMission.Rank}-Rank Mission ---");
        aRankMission.AssignUnit(tsunade);
        aRankMission.StartMission();

        // 5. Test Flyweight Factory Caching
        Console.WriteLine("\n=== TESTING FLYWEIGHT FACTORY CACHING ===");
        licenseFactory.DisplayLicense();
        NinjaLicense duplicateCheckLicense = licenseFactory.GetFlyweight("Academy Permit", "Supervised", MissionRank.D);
        Console.WriteLine($"\n--- Display all licenses after duplication ---");
        licenseFactory.DisplayLicense();
    }
}
