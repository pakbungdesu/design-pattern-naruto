using MissionRanks;
using Ninjas;
using NinjaLicenseFactories;
using NinjaLicenses;
using Missions;
using VillageManager;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== INITIALIZING NINJA VILLAGE & FACTORY ===");
        NinjaLicenseFactory licenseFactory = new NinjaLicenseFactory();
        Village village = new Village();

        NinjaLicense academyLicense = licenseFactory.GetFlyweight("Academy Permit", "Supervised 7", MissionRank.D);
        NinjaLicense chuninLicense = licenseFactory.GetFlyweight("Chunin Standard", "Standard 2", MissionRank.C);
        NinjaLicense joninLicense = licenseFactory.GetFlyweight("Jonin Advanced", "Advanced 3", MissionRank.B);
        NinjaLicense joninDoubleLicense = licenseFactory.GetFlyweight("Jonin Double Advanced", "Advanced 5", MissionRank.A);
        NinjaLicense joninTripleLicense = licenseFactory.GetFlyweight("Jonin Triple Advanced", "Advanced 7", MissionRank.S);
        NinjaLicense kageLicense = licenseFactory.GetFlyweight("Kage Special", "None", MissionRank.S);

        Ninja naruto = new Ninja("Uzumaki Naruto", 90, 85, 1000, academyLicense);
        Ninja sasuke = new Ninja("Uchiha Sasuke", 90, 85, 1000, academyLicense);
        Ninja shikamaru = new Ninja("Nara Shikamaru", 80, 75, 800, chuninLicense);
        Ninja kakashi = new Ninja("Hatake Kakashi", 95, 90, 1500, joninLicense);   
        Ninja itachi = new Ninja("Uchiha Itachi", 98, 95, 0, joninLicense);

        Ninja jiraiya = new Ninja("Jiraiya", 99, 95, 0, joninDoubleLicense);          
        Ninja minato = new Ninja("Namikaze Minato", 100, 100, 2000, joninDoubleLicense);
        
        Ninja tobirama = new Ninja("Senju Tobirama", 100, 100, 2300, joninTripleLicense);
        Ninja hashirama = new Ninja("Senju Hashirama", 100, 100, 2500, kageLicense);

        village.AddNinja(naruto);
        village.AddNinja(sasuke);
        village.AddNinja(shikamaru);
        village.AddNinja(kakashi);
        village.AddNinja(itachi);
        village.AddNinja(jiraiya);
        village.AddNinja(minato);
        village.AddNinja(tobirama);
        village.AddNinja(hashirama);

        Console.WriteLine("\n=== TESTING MISSION ASSIGNMENTS ===");
        Mission dRankMission = new Mission("Find missing orange cat", MissionRank.D);
        Mission cRankMission = new Mission("Capture the burglar", MissionRank.C);
        Mission bRankMission = new Mission("Rescue the kidnapped villagers", MissionRank.B);
        Mission aRankMission = new Mission("Eliminate the rogue ninja", MissionRank.A);
        Mission sRankMission = new Mission("Assassinate the target", MissionRank.S);

        village.AddMission(dRankMission);
        village.AddMission(cRankMission);
        village.AddMission(bRankMission);
        village.AddMission(aRankMission);
        village.AddMission(sRankMission);

        dRankMission.AssignUnit([naruto, sasuke]);
        cRankMission.AssignUnit([naruto, sasuke, shikamaru, kakashi]);
        bRankMission.AssignUnit([shikamaru, kakashi, itachi]);
        aRankMission.AssignUnit([kakashi, jiraiya, minato]);
        sRankMission.AssignUnit([jiraiya, minato, tobirama, hashirama]);

        Console.WriteLine("\n=== TESTING ADD AND REMOVE ===");   
        sRankMission.AddNinja(naruto);
        aRankMission.AddNinja(itachi);
        aRankMission.RemoveNinja(minato);
        sRankMission.RemoveNinja(naruto);

        Mission[] missions = [dRankMission, cRankMission, bRankMission, aRankMission, sRankMission];
        Console.WriteLine("\n=== TESTING START MISSION ===");   
        foreach (var mission in missions)
        {
            mission.StartMission();
        }

        Console.WriteLine("\n=== TESTING VILLAGE LICENSE CHECK ===");
        village.CheckLicense(MissionRank.S);

        Console.WriteLine("\n=== TESTING VILLAGE DISPLAY ===");
        village.Display();

        Console.WriteLine("\n=== TESTING FLYWEIGHT FACTORY CACHING ===");        
        licenseFactory.GetFlyweight("Academy Permit", "Supervised 7", MissionRank.D);
        licenseFactory.DisplayLicense();
    }
}