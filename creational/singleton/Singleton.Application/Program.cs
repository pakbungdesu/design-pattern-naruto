using Singleton.Models.Ninjas;
using Singleton.Models.Missions;

namespace Singleton.Application
{
    public class Program
    {
        public static void client()
        {
            // Get Ninjas
            Genin naruto = new Genin("Naruto");
            Chunin shikamaru = new Chunin("Shikamaru");
            Jonin kakashi = new Jonin("Kakashi");
            Kage hokage = Kage.Instance;

            // Create Missions
            Mission dRankMission = new DRank("Farming", "Grow plants", 3000, "Residental area");
            Mission cRankMission = new CRank("Escort Tazuna", "Protect bridge builder", 50000, "Bandits");
            Mission bRankMission = new BRank("Combating ninjas", "Attack someone", 70000, 5);
            Mission aRankMission = new ARank("Attack other village", "Attack a village", 1000000, "Kirigakure");
            Mission sRankMission = new SRank("Infiltrate Akatsuki", "Gather secret intel", 1200000, 5, true);

            // Test Assignment Logic
            Console.WriteLine("----- Test D Rank Assignment -----");
            dRankMission.AssignNinja(naruto);
            dRankMission.AssignNinja(shikamaru);
            dRankMission.AssignNinja(kakashi);
            dRankMission.AssignNinja(hokage);

            Console.WriteLine("----- Test C Rank Assignment -----");
            cRankMission.AssignNinja(naruto);
            cRankMission.AssignNinja(shikamaru);
            cRankMission.AssignNinja(kakashi);
            cRankMission.AssignNinja(hokage);

            Console.WriteLine("----- Test B Rank Assignment -----");
            bRankMission.AssignNinja(naruto);
            bRankMission.AssignNinja(shikamaru);
            bRankMission.AssignNinja(kakashi);
            bRankMission.AssignNinja(hokage);

            Console.WriteLine("----- Test A Rank Assignment -----");
            aRankMission.AssignNinja(naruto);
            aRankMission.AssignNinja(shikamaru);
            aRankMission.AssignNinja(kakashi);
            aRankMission.AssignNinja(hokage);

            Console.WriteLine("----- Test S Rank Assignment -----");
            sRankMission.AssignNinja(naruto);
            sRankMission.AssignNinja(shikamaru);
            sRankMission.AssignNinja(kakashi);
            sRankMission.AssignNinja(hokage);

            MissionDatabase db = MissionDatabase.GetInstance();
            db.AddMission(dRankMission);
            db.AddMission(cRankMission);
            db.AddMission(bRankMission);
            db.AddMission(aRankMission);
            db.AddMission(sRankMission);

            Console.WriteLine("\n----- Testing DisplayAllMissions -----");
            db.DisplayAllMissions();

            Console.WriteLine("\n----- Testing GetMissionAt -----");
            Mission? found = db.GetMissionAt(1);
            if (found != null)
            {
                Console.WriteLine($"Fetched: {found.Title}");
            }

            found = db.GetMissionAt(99); // Out-of-bounds check
            if (found != null)
            {
                Console.WriteLine($"Fetched: {found.Title}");
            }

            // RemoveMissionAt (Valid and Invalid)
            Console.WriteLine("\n----- Testing RemoveMissionAt -----");
            db.RemoveMissionAt(0);  // Removes D-Rank
            db.RemoveMissionAt(5);  // Invalid index check

            // Verify Singleton Identity
            Console.WriteLine("\n----- Testing Singleton Integrity -----");
            MissionDatabase anotherDbRef = MissionDatabase.GetInstance();
            bool isSameInstance = ReferenceEquals(db, anotherDbRef);
            Console.WriteLine($"Both references point to same instance: {isSameInstance}");
        }

        public static void Main(string[] args)
        {
            client();
        }
    }
}