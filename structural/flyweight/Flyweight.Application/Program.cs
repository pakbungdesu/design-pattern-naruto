
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

        NinjaLicense academyLicense = licenseFactory.GetFlyweight("Academy Permit", "Supervised 7", MissionRank.C);
        NinjaLicense chuninLicense = licenseFactory.GetFlyweight("Chunin Standard", "Standard 2", MissionRank.B);
        NinjaLicense joninLicense = licenseFactory.GetFlyweight("Jonin Advanced", "Advanced 3", MissionRank.A);
        NinjaLicense joninDoubleLicense = licenseFactory.GetFlyweight("Jonin Double Advanced", "Advanced 5", MissionRank.S);
        NinjaLicense joninTripleLicense = licenseFactory.GetFlyweight("Jonin Triple Advanced", "Advanced 7", MissionRank.S);
        NinjaLicense kageLicense = licenseFactory.GetFlyweight("Kage Special", "None", MissionRank.S);

        // Leaves
        Ninja naruto = new Ninja("Uzumaki Naruto", 90, 85, 1000, academyLicense);
        Ninja sasuke = new Ninja("Uchiha Sasuke", 90, 85, 1000, academyLicense);
        Ninja sakura = new Ninja("Haruno Sakura", 80, 75, 1000, academyLicense);
        Ninja shikamaru = new Ninja("Nara Shikamaru", 80, 75, 800, chuninLicense);
        Ninja choji = new Ninja("Akimichi Choji", 85, 80, 900, chuninLicense); 
        Ninja ino = new Ninja("Yamanaka Ino", 75, 70, 700, chuninLicense);
        
        Ninja kakashi = new Ninja("Hatake Kakashi", 95, 90, 1500, joninLicense); 
        Ninja gai = new Ninja("Might Guy", 95, 90, 1500, joninLicense);             
        Ninja itachi = new Ninja("Uchiha Itachi", 98, 95, 1600, joninLicense);

        Ninja jiraiya = new Ninja("Jiraiya", 99, 95, 1800, joninDoubleLicense);           
        Ninja orochimaru = new Ninja("Orochimaru", 99, 95, 1800, joninDoubleLicense);    
        Ninja minato = new Ninja("Namikaze Minato", 100, 100, 2000, joninDoubleLicense); 
        Ninja tsunade = new Ninja("Senju Tsunade", 100, 100, 1700, joninDoubleLicense);
        Ninja tobirama = new Ninja("Senju Tobirama", 100, 100, 2300, joninTripleLicense);
        Ninja hashirama = new Ninja("Senju Hashirama", 100, 100, 2500, kageLicense);

        // Composites

        // Test C-Rank: Contains Supervised members + requires at least 1 Advanced member
        var cRankSquad = new Squad("Team 7 (Mixed Supervised & Advanced)");
        cRankSquad.Add(naruto);    // Supervised
        cRankSquad.Add(sakura);    // Supervised
        cRankSquad.Add(kakashi);   // Advanced (Satisfies advancedCount >= 1)

        // Test B-Rank: Requires exactly 3 Standard members
        var bRankSquad = new Squad("Ino-Shika-Cho (Standard Squad)");
        bRankSquad.Add(shikamaru); // Standard
        bRankSquad.Add(choji);     // Standard
        bRankSquad.Add(ino);       // Standard (Total 3 Standard)

        // Test A-Rank: Requires 4 Advanced members
        var aRankSquad = new Squad("Elite Jonin Force");
        aRankSquad.Add(kakashi);    // A + Advanced
        aRankSquad.Add(gai);        // A + Advanced
        aRankSquad.Add(itachi);     // A + Advanced
        aRankSquad.Add(jiraiya);    // S + Advanced
        aRankSquad.Add(orochimaru); // S + Advanced

        // Test S-Rank: Requires at least 1 "None" restriction member AND 5 Advanced members
        var sRankSquad = new Squad("Legendary Strike Force");
        var threeLegend = new Squad("Three Legendary");
        threeLegend.Add(jiraiya);        // S + Advanced
        threeLegend.Add(orochimaru);     // S + Advanced
        threeLegend.Add(tsunade);        // S + Advanced

        sRankSquad.Add(threeLegend);
        sRankSquad.Add(minato);     // S + Advanced
        sRankSquad.Add(tobirama);   // S + Advanced
        sRankSquad.Add(hashirama);  // S, No restriction

        // Add to Village
        village.Add(cRankSquad);
        village.Add(bRankSquad);
        village.Add(aRankSquad);
        village.Add(sRankSquad);
        village.Add(sasuke);

        Console.WriteLine("\n=== DISPLAYING VILLAGE REGISTRY ===");
        village.Display();

        // Testing Mission Assignments & Squad Rule Validations
        Console.WriteLine("\n=== TESTING MISSION ASSIGNMENTS ===");

        Mission dRankMission = new Mission(MissionRank.D);
        Console.WriteLine($"\n--- Assigning Sasuke to {dRankMission.Rank}-Rank Mission ---");
        dRankMission.AssignUnit(sasuke);
        dRankMission.StartMission();

        // Test 2: C-Rank Mission with C-Rank Squad (Should Pass because Kakashi is present as Advanced)
        Mission cRankMission = new Mission(MissionRank.C);
        Console.WriteLine($"\n--- Assigning C-Rank Squad to {cRankMission.Rank}-Rank Mission ---");
        cRankMission.AssignUnit(cRankSquad);
        cRankMission.StartMission();

        // Test 3: B-Rank Mission with B-Rank Squad (Should Pass because it has 3 Standard members)
        Mission bRankMission = new Mission(MissionRank.B);
        Console.WriteLine($"\n--- Assigning Ino-Shika-Cho to {bRankMission.Rank}-Rank Mission ---");
        bRankMission.AssignUnit(bRankSquad);
        bRankMission.StartMission();

        // Test 4: A-Rank Mission with A-Rank Squad (Should Pass because it has 4 Advanced members)
        Mission aRankMission = new Mission(MissionRank.A);
        Console.WriteLine($"\n--- Assigning Elite Jonin Force to {aRankMission.Rank}-Rank Mission ---");
        aRankMission.AssignUnit(aRankSquad);
        aRankMission.StartMission();

        // Test 5: S-Rank Mission with S-Rank Squad (Should Pass: 1 None restriction + 5 Advanced members)
        Mission sRankMission = new Mission(MissionRank.S);
        Console.WriteLine($"\n--- Assigning Legendary Strike Force to {sRankMission.Rank}-Rank Mission ---");
        sRankMission.AssignUnit(sRankSquad);
        sRankMission.StartMission();

        // Flyweight Factory Caching Verification
        Console.WriteLine("\n=== TESTING FLYWEIGHT FACTORY CACHING ===");        
        NinjaLicense duplicateCheckLicense = licenseFactory.GetFlyweight("Academy Permit", "Supervised 7", MissionRank.D);
        licenseFactory.DisplayLicense();
    }
}