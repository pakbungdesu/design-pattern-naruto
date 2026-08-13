namespace Singleton.Models.Missions
{
    // S-rank: Confidential state affairs
    public class SRank : Mission
    {
        private static int id = 0;
        public int SecrecyClearanceLevel { get; set; }
        public bool RequiresAnbuExecution { get; set; }

        public SRank(string title, string description, double ryoReward, int secrecyClearanceLevel, bool requiresAnbuExecution)
            : base(title, description, ryoReward)
        {
            SecrecyClearanceLevel = secrecyClearanceLevel;
            RequiresAnbuExecution = requiresAnbuExecution;
            id++;
            RegNumber = "S-" + id.ToString("D4");
        }

        public static int getLastId()
        {
            return id;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[S-Rank] {Title} | Secrecy Level: {SecrecyClearanceLevel} | Anbu Only: {RequiresAnbuExecution} | Reward: {RyoReward} Ryō");
        }
    }
}