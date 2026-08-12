namespace Singleton.Models.Missions
{
    public sealed class MissionQueue
    {
        private static readonly Lazy<MissionQueue> _instance = 
            new Lazy<MissionQueue>(() => new MissionQueue());

        private readonly Queue<Mission> _queue;

        // Prevents external instantiation
        private MissionQueue()
        {
            _queue = new Queue<Mission>();
        }

        // Global access
        public static MissionQueue Instance => _instance.Value;

        // Queue operations
        public void AddMission(Mission mission)
        {
            _queue.Enqueue(mission);
            Console.WriteLine($"📋 Enqueued [{mission.GetType().Name}] '{mission.Title}'");
        }

        public Mission? DequeueMission()
        {
            if (_queue.Count == 0)
            {
                Console.WriteLine("⚠️ No missions available in the queue.");
                return null;
            }

            Mission mission = _queue.Dequeue();
            Console.WriteLine($"🚀 Assigned [{mission.GetType().Name}] '{mission.Title}'");
            return mission;
        }

        public void DisplayQueue()
        {
            Console.WriteLine($"\n--- Konoha Mission Board Queue ({_queue.Count} Pending) ---");
            if (_queue.Count == 0)
            {
                Console.WriteLine("Board is empty.");
                return;
            }

            foreach (var mission in _queue)
            {
                mission.DisplayMissionDetails();
            }
        }
    }
}