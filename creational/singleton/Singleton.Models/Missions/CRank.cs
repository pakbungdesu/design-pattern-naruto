namespace Singleton.Models.Missions
{
    // C-rank: Little threats, but no combating with other ninjas
    public class CRank : Mission
    {
        private static int id = 0;

        public string ThreatType { get; set; } // e.g., "Wild Animals", "Bandits"

        public CRank(string title, string description, double ryoReward, string threatType)
            : base(title, description, ryoReward)
        {
            ThreatType = threatType;
            id++;
            RegNumber = "C-" + id.ToString("D4");
        }

        public static int getLastId()
        {
            return id;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[C-Rank] {Title} | Threat: {ThreatType} | Reward: {RyoReward} Ryō");
        }
    }
}