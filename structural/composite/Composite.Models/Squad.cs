using Shinobis;

namespace Squads
{
    public class Squad : Shinobi
    {
        public string Name { get; set; }
        public List<Shinobi> Members { get; } = new();

        public Squad(string name)
        {
            Name = name;
        }

        public void Add(Shinobi unit) => Members.Add(unit);

        public void Remove(Shinobi unit) => Members.Remove(unit);

        public void WorkInfo()
        {
            Console.WriteLine($"[Squad: {Name}] Commencing operations:");
            foreach (var member in Members)
            {
                member.WorkInfo();
            }
            Console.WriteLine($"---------------------------------------");
        }

        public int CountMedics() => Members.Sum(m => m.CountMedics());
        public int CountAnbu() => Members.Sum(m => m.CountAnbu());
        public int CountTanks() => Members.Sum(m => m.CountTanks());
    }
}