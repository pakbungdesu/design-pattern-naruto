using Singleton.Models.Ninjas;
using Singleton.Models.Missions;

namespace Singleton.Application
{
    public class Program
    {
        public static void client()
        {
            // 1. Get Ninjas
            Genin naruto = new Genin("Naruto");
            Chunin shikamaru = new Chunin("Shikamaru");
            Jonin kakashi = new Jonin("Kakashi");
            Kage hokage = Kage.Instance;

            // 2. Create Missions
            Mission cRankMission = new CRank("Escort Tazuna", "Protect bridge builder", 50000, "Bandits");
            Mission sRankMission = new SRank("Infiltrate Akatsuki", "Gather secret intel", 1200000, 5, true);

            // 3. Test Assignment Logic
            cRankMission.AssignNinja(naruto);    // Allowed
            cRankMission.AssignNinja(kakashi);   // Failed

            sRankMission.AssignNinja(naruto);    // Failed
            sRankMission.AssignNinja(kakashi);   // Allowed
            sRankMission.AssignNinja(hokage);    // Allowed
        }

        public static void Main(string[] args)
        {
            client();
        }
    }
}