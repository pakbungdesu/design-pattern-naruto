
using MissionRanks;
using Ninjas;
using NinjaLicenseFactories;
using VillageManager;
using NinjaLicenses;
using Missions;

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

        Ninja naruto = new Ninja("Uzumaki Naruto", 90, 85, 1000, academyLicense);
        Ninja sasuke = new Ninja("Uchiha Sasuke", 90, 85, 1000, academyLicense);
        Ninja shikamaru = new Ninja("Nara Shikamaru", 80, 75, 800, chuninLicense);
        Ninja kakashi = new Ninja("Hatake Kakashi", 95, 90, 1500, joninLicense);   
        Ninja itachi = new Ninja("Uchiha Itachi", 98, 95, 1600, joninLicense);

        Ninja jiraiya = new Ninja("Jiraiya", 99, 95, 1800, joninDoubleLicense);           
        Ninja minato = new Ninja("Namikaze Minato", 100, 100, 2000, joninDoubleLicense);
        
        Ninja tobirama = new Ninja("Senju Tobirama", 100, 100, 2300, joninTripleLicense);
        Ninja hashirama = new Ninja("Senju Hashirama", 100, 100, 2500, kageLicense);

        Console.WriteLine("\n=== TESTING MISSION ASSIGNMENTS ===");
        Mission dRankMission = new Mission("Find missing orange cat", MissionRank.D);
        Mission cRankMission = new Mission("Capture the burglar", MissionRank.C);
        Mission bRankMission = new Mission("Rescue the kidnapped villagers", MissionRank.B);
        Mission aRankMission = new Mission("Eliminate the rogue ninja", MissionRank.A);
        Mission sRankMission = new Mission("Assassinate the target", MissionRank.S);

        dRankMission.AssignUnit(new List<Ninja> { naruto, sasuke, shikamaru });
        cRankMission.AssignUnit(new List<Ninja> { naruto, sasuke, shikamaru, kakashi });
        bRankMission.AssignUnit(new List<Ninja> { shikamaru, kakashi, itachi });
        aRankMission.AssignUnit(new List<Ninja> { kakashi, jiraiya, minato });
        sRankMission.AssignUnit(new List<Ninja> { jiraiya, minato, tobirama, hashirama });

        Mission[] missions = new Mission[] { dRankMission, cRankMission, bRankMission, aRankMission, sRankMission };
        foreach (var mission in missions)
        {
            mission.StartMission();
        }

        Console.WriteLine("\n=== TESTING FLYWEIGHT FACTORY CACHING ===");        
        NinjaLicense duplicateCheckLicense = licenseFactory.GetFlyweight("Academy Permit", "Supervised 7", MissionRank.D);
        licenseFactory.DisplayLicense();
    }
}