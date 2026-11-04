
namespace Ninjas {

    using Caretakers;

    public class Ninja
    {
        public string Name { get; set; } = "Anonymous Ninja";
        public string Village { get; set; } = "Unknown Village";

        public Caretaker _caretaker = null!;

        public Ninja(string name, string village)
        {
            Name = name;
            Village = village;
        }

        public void SetCaretaker(Caretaker caretaker)
        {
            _caretaker = caretaker;
        }

        public void Display()
        {
            Console.WriteLine($"Ninja: {Name}, Village: {Village}");
        }

        public void AddHistory()
        {
            _caretaker.AddHistory();
        }

        public void Undo()
        {
            _caretaker.Undo();
        }
    }
}