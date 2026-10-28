
namespace Ninjas
{
    using Invokers;

    public class Ninja
    {
        public string Name { get; set; }

        public Ninja(string name)
        {
            Name = name;
        }

        public void ExecuteCommand(HandSign handsign)
        {
            handsign.ExecuteCommand();
        }
    }
}