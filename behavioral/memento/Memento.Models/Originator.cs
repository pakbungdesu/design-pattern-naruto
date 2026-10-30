
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
        public int Step {get; set; }

        public Movement(Direction direction, Act act, int step) 
        {
            Direction = direction;
            Act = act;
            Step = step;
        }

        public IMemento Save() 
        {
            return new MovementMemento(Direction, Act, Step);
        }

        public void Restore(IMemento m) 
        {
            if (m is MovementMemento mm) 
            {
                Direction = mm.GetDirection();
                Act = mm.GetAct();
                Step = mm.GetStep();
            }
        }

        public void Display() 
        {
            Console.WriteLine($"[Originator] Direction: {Direction}, Act: {Act}, Step: {Step}");
        }
    }
}