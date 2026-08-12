namespace Singleton.Models.Missions
{
    // C-rank: Little threats, but no combating with other ninjas
    public class CRank : Mission
    {
        public string ThreatType { get; set; } // e.g., "Wild Animals", "Bandits"

        public CRank(string title, string description, double ryoReward, string threatType)
            : base(title, description, ryoReward)
        {
            ThreatType = threatType;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[C-Rank] {Title} | Threat: {ThreatType} | Reward: {RyoReward} Ryō");
        }
    }
}