
namespace Observers
{
    using Messages;

    public interface IAkatsuki
    {
        void Display();
        void Update(Message m);
    }

    public class RougeNinja : IAkatsuki
    {
        private readonly string _name;
        private readonly string _villageOfOrigin;
        private readonly float _coordinateX;
        private readonly float _coordinateY;
        public Message? Message {set; get;}

        public RougeNinja(string name, string village, float x, float y)
        {
            _name = name;
            _villageOfOrigin = village;
            _coordinateX = x;
            _coordinateY = y;
        }

        public void Display()
        {
            Console.WriteLine($"Ninja: {_name} from {_villageOfOrigin} at ({_coordinateX}, {_coordinateY})");
        }

        public void Update(Message m)
        {
            Message = m;
            Console.Write($"[{_name}] Received -> ");
            Message.Display();
        }
    }

    public class Squad : IAkatsuki
    {
        private string _teamName;
        private List<IAkatsuki> _members = new List<IAkatsuki>();
        public Squad(string teamName) => _teamName = teamName;
        public void Add(IAkatsuki unit) => _members.Add(unit);
        public void Remove(IAkatsuki unit) => _members.Remove(unit);

        public void Display()
        {
            Console.WriteLine($"Squad: {_teamName}");
            foreach (var member in _members)
            {
                member.Display();
            }
            Console.WriteLine("-------------------------------------");
        }

        public void Update(Message m)
        {
            Console.WriteLine($"[Squad {_teamName}] Broadcasting update to all members:");
            foreach (var member in _members)
            {
                member.Update(m);
            }
        }
    }
}