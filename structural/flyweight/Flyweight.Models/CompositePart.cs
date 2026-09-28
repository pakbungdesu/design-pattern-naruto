using NinjaLicenses;
using MissionRanks;

namespace CompositePart
{
    public interface Shinobi
    {
        void Display();
        bool CheckLicense(MissionRank rank);
    }

    // Ninja Leaf Class
    public class Ninja : Shinobi
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int HP { get; set; }
        public bool IsDefeated { get; set; }
        public NinjaLicense License { get; set; }

        public Ninja(string name, int atk, int def, int hp, NinjaLicense license)
        {
            Name = name;
            ATK = atk;
            DEF = def;
            HP = hp;
            IsDefeated = false;
            License = license;
        }

        public void Attack(Ninja target) { /* Attack logic */ }
        public void Defend(Ninja attacker) { /* Defend logic */ }
        public void Execute(Ninja target) { /* Execute logic */ }

        public void Display()
        {
            Console.WriteLine($"--- Ninja: {Name} (HP: {HP}, ATK: {ATK}, DEF: {DEF}) ---");
            License.Display();
        }

        public bool CheckLicense(MissionRank rank)
        {
            return License != null && License.IsEligibleFor(rank);
        }
    }

    // Squad Composite Class
    public class Squad : Shinobi
    {
        public string Name { get; set; }
        private List<Shinobi> _members = new List<Shinobi>();

        public Squad(string name)
        {
            Name = name;
        }

        public void Add(Shinobi unit) => _members.Add(unit);
        public void Remove(Shinobi unit) => _members.Remove(unit);

        public void Display()
        {
            Console.WriteLine($"=== Squad: {Name} ===");
            foreach (var member in _members)
            {
                member.Display();
            }
        }

        public bool CheckLicense(MissionRank rank)
        {
            foreach (var member in _members)
            {
                if (!member.CheckLicense(rank)) return false;
            }
            return true;
        }
    }
}