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
        public bool IsDefeated => HP > 0;
        public NinjaLicense License { get; set; }

        public Ninja(string name, int atk, int def, int hp, NinjaLicense license)
        {
            Name = name;
            ATK = atk;
            DEF = def;
            HP = hp;
            License = license;
        }

        private void Attack(Ninja target)
        {
            target.HP = Math.Max(0, target.HP - (this.ATK - target.DEF));
        }

        public void Execute(Ninja target)
        {
            Console.WriteLine($"=== BEFORE ATTACKING ===");
            Console.WriteLine($"--- Attacker: {Name} (HP: {HP}, ATK: {ATK}, DEF: {DEF}) ---");
            Console.WriteLine($"--- Target: {target.Name} (HP: {target.HP}, ATK: {target.ATK}, DEF: {target.DEF}) ---");

            if (IsDefeated)
            {
                Console.WriteLine($"{Name} is dead. Can't attack {target.Name}");
                return;
            }

            if (target.IsDefeated)
            {
                Console.WriteLine($"{target.Name} is already dead.");
                return;
            }

            Attack(target);
            Console.WriteLine($"{Name} attacked {target.Name}");
            
            Console.WriteLine($"=== AFTER ATTACKING ===");
            Console.WriteLine($"--- Attacker: {Name} (HP: {HP}, ATK: {ATK}, DEF: {DEF}) ---");
            Console.WriteLine($"--- Target: {target.Name} (HP: {target.HP}, ATK: {target.ATK}, DEF: {target.DEF}) ---");
        }

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

        private bool Count(MissionRank rank, int supervisedCount, int standardCount, int advancedCount, int noRestrictionCount)
        {
            switch (rank)
            {
                case MissionRank.C:
                    // C-Rank: If squad contains a supervised member, require at least 1 high/advanced member
                    if (supervisedCount > 0 && advancedCount < 1)
                    {
                        return false; 
                    }
                    break;

                case MissionRank.B:
                    // B-Rank: Requires 3 standard members
                    if (standardCount < 3)
                    {
                        return false;
                    }
                    break;

                case MissionRank.A:
                    // A-Rank: Requires 5 advanced members
                    if (advancedCount < 5)
                    {
                        return false;
                    }
                    break;

                case MissionRank.S:
                    // S-Rank: Needs at least one none/no restriction member AND 7 advanced members
                    if (noRestrictionCount < 1 || advancedCount < 7)
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }

        public bool CheckLicense(MissionRank rank)
        {
            // baseline
            foreach (var member in _members)
            {
                if (!member.CheckLicense(rank)) return false;
            }

            int supervisedCount = 0;
            int standardCount = 0;
            int advancedCount = 0;
            int noRestrictionCount = 0;

            foreach (var member in _members)
            {
               if (member is Ninja ninja && ninja.License != null)
                {
                    string rest = ninja.License.Restriction.ToLower();
                    if (rest.Contains("supervised")) supervisedCount++;
                    else if (rest.Contains("standard")) standardCount++;
                    else if (rest.Contains("advanced")) advancedCount++;
                    else if (string.IsNullOrEmpty(rest) || rest.Contains("none")) noRestrictionCount++;
                }
            }

            return Count(rank, supervisedCount, standardCount, advancedCount, noRestrictionCount);
        }
    }
}