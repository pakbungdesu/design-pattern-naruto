namespace Singleton.Models.Missions
{
    public sealed class MissionDatabase
    {
        // Lazy<T> ensures the value is created only when first accessed.
        // readonly ensures the Lazy<T> instance itself cannot be reassigned.
        private static readonly Lazy<MissionDatabase> _instance = 
            new Lazy<MissionDatabase>(() => new MissionDatabase());

        private readonly List<Mission> _missions;

        private MissionDatabase()
        {
            _missions = new List<Mission>();
        }

        public static MissionDatabase Instance => _instance.Value;

        public int Count => _missions.Count;

        public void AddMission(Mission mission)
        {
            _missions.Add(mission);
            Console.WriteLine($"Added [{mission.GetType().Name}] '{mission.Title}' to Konoha Database.");
        }

        public Mission? GetMissionAt(int index)
        {
            if (index < 0 || index >= _missions.Count)
            {
                Console.WriteLine($"Invalid index {index}. No mission found.");
                return null;
            }

            return _missions[index];
        }

        // Remove a mission when completed or cancelled
        public bool RemoveMissionAt(int index)
        {
            if (index < 0 || index >= _missions.Count)
            {
                Console.WriteLine($"Cannot remove. Invalid index {index}.");
                return false;
            }

            Mission removed = _missions[index];
            _missions.RemoveAt(index);
            Console.WriteLine($"Mission '{removed.Title}' completed and removed from database.");
            return true;
        }

        public void DisplayAllMissions()
        {
            Console.WriteLine($"\n--- Konoha Mission Board ({_missions.Count} Missions Available) ---");
            if (_missions.Count == 0)
            {
                Console.WriteLine("No missions available.");
                return;
            }

            for (int i = 0; i < _missions.Count; i++)
            {
                Console.Write($"[{i}] ");
                _missions[i].DisplayMissionDetails();
            }
        }
    }
}