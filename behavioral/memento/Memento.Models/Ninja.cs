
namespace Ninjas
{
    using Enums;
    using Caretakers;
    using Originators;

    public class Ninja
    {
        public string Name { get; set; }
        public string Village { get; set; }
        
        private Caretaker _caretaker;
        private Movement _currentMovement;

        public Ninja(string name, string village)
        {
            Name = name;
            Village = village;
            _caretaker = new Caretaker();
            _currentMovement = null!;
        }

        public void Undo()
        {
            _caretaker.Undo();
            Interpret(_currentMovement);
        }

        public void GoForward(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Forward, how, step);
            _caretaker.AddHistory();
            Console.WriteLine($"{Name} goes Forward, {how}, {step} steps.");
        }

        public void GoBackward(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Backward, how, step);
            _caretaker.AddHistory();
            Console.WriteLine($"{Name} goes Backward, {how}, {step} steps.");
        }

        public void GoLeft(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Left, how, step);
            _caretaker.AddHistory();
            Console.WriteLine($"{Name} goes Left, {how}, {step} steps.");
        }

        public void GoRight(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Right, how, step);
            _caretaker.AddHistory();
            Console.WriteLine($"{Name} goes Right, {how}, {step} steps.");
        }

        private void Interpret(Movement mm)
        {
            if (mm != null)
            {
                Direction oppositeDir = Direction.Forward; 

                if (mm.Direction == Direction.Forward) { oppositeDir = Direction.Backward; }
                else if (mm.Direction == Direction.Backward) { oppositeDir = Direction.Forward; }
                else if (mm.Direction == Direction.Left) { oppositeDir = Direction.Right; }
                else { mm.Direction = Direction.Left; }

                Console.WriteLine($"Previous movement: {mm.Direction}, How: {mm.Act}, Steps: {mm.Step}");
                Console.WriteLine($"Undoing by going {oppositeDir}, How: {mm.Act}, Steps: {mm.Step}");
            }
            else
            {
                Console.WriteLine("No history left to undo.");
            }
        }
    }
}