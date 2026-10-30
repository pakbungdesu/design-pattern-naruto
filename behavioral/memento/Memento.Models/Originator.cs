
namespace Originators
{
    using Mementos;
    using Enums;

    public interface IOriginator 
    {
        IMemento Save();
        void Restore(IMemento m);
    }

    // --- Concrete Originator ---
    public class Movement : IOriginator 
    {
        public Direction Direction { get; set; }
        public Act Act { get; set; }

        public Movement(Direction direction, Act act) 
        {
            Direction = direction;
            Act = act;
        }

        public IMemento Save() 
        {
            return new MovementMemento(Direction, Act);
        }

        public void Restore(IMemento m) 
        {
            if (m is MovementMemento mm) 
            {
                Direction = mm.GetDirection();
                Act = mm.GetAct();
            }
        }
    }
}