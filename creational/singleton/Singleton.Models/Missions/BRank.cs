using Singleton.Models.Ninjas;

namespace Singleton.Models.Missions
{
    // B-rank: Expected ninja combat
    public class BRank : Mission
    {
        private static int id = 0;
        public int ExpectedEnemyNinjaCount { get; set; }

        public BRank(string title, string description, double ryoReward, int expectedEnemyNinjaCount)
            : base(title, description, ryoReward)
        {
            ExpectedEnemyNinjaCount = expectedEnemyNinjaCount;
            id++;
            RegNumber = "B-" + id.ToString("D4");
        }

        public static int getLastId()
        {
            return id;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[B-Rank] {Title} | Expected Enemies: {ExpectedEnemyNinjaCount} Ninja | Reward: {RyoReward} Ryō");
            foreach (Ninja ninja in Ninjas)
            {
                ninja.DisplayNinja();
            }
        }
    }
}