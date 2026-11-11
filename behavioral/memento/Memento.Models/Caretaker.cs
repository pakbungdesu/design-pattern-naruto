
namespace Caretakers
{
    using Mementos;
    using Originators;

    // --- Caretaker ---
    public class Caretaker 
    {
        private readonly Stack<IMemento> _history = new Stack<IMemento>();
        private IOriginator _originator;

        public Caretaker(IOriginator originator) 
        {
            _originator = originator;
        }

        public void SetOriginator(IOriginator originator) 
        {
            _originator = originator;
        }

        public void AddHistory() 
        {
            if (_originator == null) 
            {
                throw new InvalidOperationException("Originator is not set.");
            }
            IMemento m = _originator.Save();
            _history.Push(m);
        }

        public IMemento Undo() 
        {
            if (_originator == null) 
            {
                throw new InvalidOperationException("Originator is not set.");
            }
            
            if (_history.Count == 0) 
            {
                throw new InvalidOperationException("No history left to undo.");
            }
            IMemento m = _history.Pop();
            _originator.Restore(m);
            return m;
        }
    }
}