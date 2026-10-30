
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

        private readonly int _step;

        public MovementMemento(Direction direction, Act act, int step) 
        {
            _direction = direction;
            _act = act;
            _step = step;
        }

        public Direction GetDirection() => _direction;
        public Act GetAct() => _act;
        public int GetStep() => _step;
        public void Display() 
        {
            Console.WriteLine($"[Memento] Direction: {_direction}, Act: {_act}, Step: {_step}");
        }
    }
}