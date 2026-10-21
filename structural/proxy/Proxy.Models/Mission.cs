
namespace Missions
{
    using Ninjas;

    public class Mission
    {
        public string Title { get; set; } = "Anonymous Mission";
        public string Description { get; set; } = "No description provided.";
        public double Reward { get; set; } = 10.5;
        public Role RoleRequired { get; set; } = Role.Chunin;

        public Mission(string title, string description, double reward, Role roleRequired)
        {
            Title = title;
            Description = description;
            Reward = reward;
            RoleRequired = roleRequired;
        }

        public void Display()
        {
            Console.WriteLine($"Mission: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Reward: {Reward} Ryo");
            Console.WriteLine($"Role Required: {RoleRequired}");
        }
    }
}