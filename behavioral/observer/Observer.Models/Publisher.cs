
namespace Publishers
{
    using Observers;
    using Messages;

    public interface IPublisher
    {
        void Subscribe(IAkatsuki akatsuki);
        void Unsubscribe(IAkatsuki akatsuki);
        void Notify();
    }

    public class PainPublisher : IPublisher
    {
        private static PainPublisher? _pain;
        private List<IAkatsuki> _akatsuki = new List<IAkatsuki>();
        private Message? _message;
        private PainPublisher() { }

        public static PainPublisher GetPainPublisher()
        {
            if (_pain == null)
            {
                _pain = new PainPublisher();
            }
            return _pain;
        }

        public void Subscribe(IAkatsuki akatsuki) => _akatsuki.Add(akatsuki);
        public void Unsubscribe(IAkatsuki akatsuki) => _akatsuki.Remove(akatsuki);

        public void SetMessage(Message message)
        {
            _message = message;
            Notify();
        }

        public void Notify()
        {
            foreach (var member in _akatsuki)
            {
                if(_message is not null)
                {
                    member.Update(_message);
                }        
            }
        }
    }
}