namespace Singleton.Models.Missions
{
    // S-rank: Confidential state affairs
    public class SRankMission : Mission
    {
        public int SecrecyClearanceLevel { get; set; }
        public bool RequiresAnbuExecution { get; set; }

        public SRankMission(string title, string description, double ryoReward, int secrecyClearanceLevel, bool requiresAnbuExecution)
            : base(title, description, ryoReward)
        {
            SecrecyClearanceLevel = secrecyClearanceLevel;
            RequiresAnbuExecution = requiresAnbuExecution;
        }

        public override void DisplayMissionDetails()
        {
            Console.WriteLine($"[S-Rank] {Title} | Secrecy Level: {SecrecyClearanceLevel} | Anbu Only: {RequiresAnbuExecution} | Reward: {RyoReward} Ryō");
        }
    }
}