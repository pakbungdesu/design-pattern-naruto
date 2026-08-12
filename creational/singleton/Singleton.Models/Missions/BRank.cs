namespace Singleton.Models.Missions
{
    // B-rank: Expected ninja combat
    public class BRank : Mission
    {
        public int ExpectedEnemyNinjaCount { get; set; }

        public BRank(string title, string description, double ryoReward, int expectedEnemyNinjaCount)
            : base(title, description, ryoReward)
        {
            ExpectedEnemyNinjaCount = expectedEnemyNinjaCount;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[B-Rank] {Title} | Expected Enemies: {ExpectedEnemyNinjaCount} Ninja | Reward: {RyoReward} Ryō");
        }
    }
}