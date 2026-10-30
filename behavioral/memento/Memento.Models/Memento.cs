
namespace Mementos
{
    using Enums;

    // --- Interfaces ---
    public interface IMemento 
    {
        void Display();
    }

    // --- Concrete Memento ---
    public class MovementMemento : IMemento 
    {
        private readonly Direction _direction;
        private readonly Act _act;

        public MovementMemento(Direction direction, Act act) 
        {
            _direction = direction;
            _act = act;
        }

        public Direction GetDirection() => _direction;
        public Act GetAct() => _act;
        public void Display() 
        {
            Console.WriteLine($"[Memento] Direction: {_direction}, Act: {_act}");
        }
    }
}