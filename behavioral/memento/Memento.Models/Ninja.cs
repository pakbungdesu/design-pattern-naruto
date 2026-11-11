
namespace Ninjas
{
    using Enums;
    using Caretakers;
    using Originators;
    using Mementos;

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
            _caretaker = null!;
            _currentMovement = null!;
        }

        public void Display()
        {
            Console.WriteLine($"Ninja Name: {Name}, Village: {Village}");
        }

        public void Undo()
        {
            MovementMemento memento = (MovementMemento)_caretaker.Undo();
            _currentMovement.Direction = memento.GetDirection();
            _currentMovement.Act = memento.GetAct();
            _currentMovement.Step = memento.GetStep();
            
            Display();
            _currentMovement.Display();
        }

        public void GoForward(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Forward, how, step);
            if(_caretaker == null)
            {
                _caretaker = new Caretaker(_currentMovement);
            }

            _caretaker.SetOriginator(_currentMovement);
            _caretaker.AddHistory();
            Display();
            _currentMovement.Display();
        }

        public void GoBackward(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Backward, how, step);
            if(_caretaker == null)
            {
                _caretaker = new Caretaker(_currentMovement);
            }

            _caretaker.SetOriginator(_currentMovement);
            _caretaker.AddHistory();
            Display();
            _currentMovement.Display();
        }

        public void GoLeft(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Left, how, step);
            if(_caretaker == null)
            {
                _caretaker = new Caretaker(_currentMovement);
            }
            _caretaker.SetOriginator(_currentMovement);
            _caretaker.AddHistory();
            Display();
            _currentMovement.Display();
        }

        public void GoRight(Act how, int step)
        {
            _currentMovement = new Movement(Direction.Right, how, step);
            if(_caretaker == null)
            {
                _caretaker = new Caretaker(_currentMovement);
            }
            _caretaker.SetOriginator(_currentMovement);
            _caretaker.AddHistory();
            Display();
            _currentMovement.Display();
        }
    }
}