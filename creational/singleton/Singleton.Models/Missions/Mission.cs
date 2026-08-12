namespace Singleton.Models.Missions
{
    public abstract class Mission
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double RyoReward { get; set; }

        public bool IsCompleted {get; set;}

        protected Mission(string title, string description, double ryoReward)
        {
            Title = title;
            Description = description;
            RyoReward = ryoReward;
            IsCompleted = false;
        }

        public abstract void DisplayMissionDetails();
    }
}