namespace Singleton.Models.Missions
{
    // D-rank: Odd jobs, no threat & no combating with other ninjas
    public class DRank : Mission
    {
        public string LocationType { get; set; } // e.g., "Farm", "Residential Area"

        public DRank(string title, string description, double ryoReward, string locationType)
            : base(title, description, ryoReward)
        {
            LocationType = locationType;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[D-Rank] {Title} | Location: {LocationType} | Reward: {RyoReward} Ryō");
        }
    }
}