
namespace Caretakers
{
    using Mementos;
    using Originators;
    
    // --- Caretaker ---
    public class Caretaker 
    {
        private readonly Stack<IMemento> _history = new Stack<IMemento>();
        private readonly IOriginator _originator;

        public Caretaker(IOriginator originator) 
        {
            _originator = originator;
        }

        public void AddHistory() 
        {
            IMemento m = _originator.Save();
            _history.Push(m);
        }

        public void Undo() 
        {
            if (_history.Count > 0) 
            {
                IMemento m = _history.Pop();
                _originator.Restore(m);
            }
        }
    }
}