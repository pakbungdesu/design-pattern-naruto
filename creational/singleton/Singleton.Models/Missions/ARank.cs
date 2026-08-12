namespace Singleton.Models.Missions
{
    // A-rank: Village/state matters, geopolitics
    public class ARank : Mission
    {
        public string TargetVillageOrState { get; set; }

        public ARank(string title, string description, double ryoReward, string targetVillageOrState)
            : base(title, description, ryoReward)
        {
            TargetVillageOrState = targetVillageOrState;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[A-Rank] {Title} | Target Region: {TargetVillageOrState} | Reward: {RyoReward} Ryō");
        }
    }
}