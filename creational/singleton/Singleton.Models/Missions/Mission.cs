using Singleton.Models.Ninjas;

namespace Singleton.Models.Missions
{
    public abstract class Mission
    {
        public string? RegNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double RyoReward { get; set; }
        public bool IsCompleted {get; set;}
        public List<Ninja> Ninjas { get; set; } = new List<Ninja>();

        protected Mission(string title, string description, double ryoReward)
        {
            Title = title;
            Description = description;
            RyoReward = ryoReward;
            IsCompleted = false;
        }

        public bool AssignNinja(Ninja ninja)
        {
            if (!ninja.CanTakeMission(this))
            {
                Console.WriteLine($"Assign failed: {ninja.Name} ({ninja.GetType().Name}) is not authorized for [{this.GetType().Name}] '{Title}'.");
                return false;
            }

            Ninjas.Add(ninja);
            Console.WriteLine($"Assigned {ninja.Name} ({ninja.GetType().Name}) to [{this.GetType().Name}] '{Title}'.");
            return true;
        }

        public abstract void DisplayMissionDetails();
    }
}