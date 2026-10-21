
namespace Invokers
{
    using Commands;

    public class HandSign
    {
        private CommandMode? _Command;

        public string Name { get; set; }

        public HandSign(string name)
        {
            _Command = null;
            Name = name;
        }

        public void SetCommand(CommandMode c)
        {
            _Command = c;
        }

        public void ExecuteCommand()
        {
            Console.WriteLine($"[HandSign: {Name}] is executing command...");
            _Command?.execute();
        }
    }
}