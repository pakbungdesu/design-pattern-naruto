using Ninjas;

namespace RealNinjas
{
    public class RealNinja : Ninja
    {
        public string Name { get; }

        public RealNinja(string name)
        {
            Name = name;
        }

        public bool ExecuteMission(string missionName, AuthContext callerContext)
        {
            Console.WriteLine($"[RealNinja] {Name} successfully executed mission: '{missionName}'.");
            return true;
        }
    }
}