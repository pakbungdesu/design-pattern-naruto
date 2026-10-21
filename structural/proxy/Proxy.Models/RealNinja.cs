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

        public bool ExecuteMission(AuthContext callerContext)
        {
            Console.WriteLine($"[RealNinja] {Name} successfully executed mission: '{callerContext.Mission.Title}'.");
            callerContext.Mission.Display();
            return true;
        }
    }
}