namespace Singleton.Models.Missions
{
    // D-rank: Odd jobs, no threat & no combating with other ninjas
    public class DRank : Mission
    {
        private static int id = 0;
        public string LocationType { get; set; } // e.g., "Farm", "Residential Area"

        public DRank(string title, string description, double ryoReward, string locationType)
            : base(title, description, ryoReward)
        {
            LocationType = locationType;
            id++;
            RegNumber = "D-" + id.ToString("D4");
        }

        public static int getLastId()
        {
            return id;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[D-Rank] {Title} | Location: {LocationType} | Reward: {RyoReward} Ryō");
        }
    }
}