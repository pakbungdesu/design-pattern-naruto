using CombatGears;

namespace Ninjas
{
    public class Ninja
    {
        public string Name { get; set; }
        public int BaseAttack { get; set; }
        public double HealRate { get; set; } = 5; // Chakra points per minute
        public int Chakra { get; set; }
        public bool IsDefeated => Chakra <= 0;
        public List<Weapon> Weapons { get; set; } = new();
        public List<Defence> Defences { get; set;} = new();
        public Outfit? Uniform { get; set; }
        public Outfit? AddOn { get; set; }

        public Ninja(string name, int baseAttack = 100, int chakra = 10000)
        {
            Name = name;
            BaseAttack = baseAttack;
            Chakra = chakra;
        }

        public void ModifyChakra(int finalDamage)
        {
            Chakra -= finalDamage;
            if (Chakra < 0) Chakra = 0;
            Console.WriteLine($"⚡ {Name}'s chakra is now {Chakra}.");
        }

        public void HealChakra(int minutes)
        {
            if (IsDefeated)
            {
                Console.WriteLine($"❌ {Name} cannot heal (Defeated: {IsDefeated})");
                return;
            }

            int healAmount = (int)(minutes * HealRate);
            Chakra += healAmount;
            Console.WriteLine($"💖 {Name} heals {healAmount} chakra. Total chakra: {Chakra}");
        }

        public int UseWeapon(int index, Ninja target)
        {
            if (IsDefeated)
            {
                Console.WriteLine($"❌ {Name} cannot attack (Defeated: {IsDefeated})");
                return 0;
            }

            if (index < 0 || index >= Weapons.Count)
            {
                Console.WriteLine($"⚠️ Invalid weapon index [{index}] for {Name}.");
                return 0;
            }
            // Final damage
            return Weapons[index].Attack(target);
        }

        public int UseDefence(int index, int incomingDamage)
        {
            if (index < 0 || index >= Defences.Count)
            {
                Console.WriteLine($"⚠️ Invalid defence index [{index}] for {Name}. Taking direct hit.");
                return 0;
            }
            // Final damage after defence
            return Defences[index].Protect(incomingDamage);
        }

 
        public void DisplayInfo()
        {
            Console.WriteLine($"\n==================== [ {Name} ] ====================");
            Console.WriteLine($"Status:       {(IsDefeated ? "Defeated" : "Active")}");
            Console.WriteLine($"Stats:        Base ATK: {BaseAttack} | Chakra/HP: {Chakra}");
            Console.WriteLine($"Uniform:      {Uniform?.ModelName ?? "None"} [{Uniform?.Effect?.ElementName ?? "None"}]");
            Console.WriteLine($"AddOn:        {AddOn?.ModelName ?? "None"} [{AddOn?.Effect?.ElementName ?? "None"}]");

            Console.WriteLine("Weapons:");
            for (int i = 0; i < Weapons.Count; i++)
            {
                Console.WriteLine($"  [{i}] {Weapons[i].ModelName} [{Weapons[i].Effect?.ElementName}]");
            }

            Console.WriteLine("Defences:");
            for (int i = 0; i < Defences.Count; i++)
            {
                Console.WriteLine($"  [{i}] {Defences[i].ModelName} [{Defences[i].Effect?.ElementName}]");
            }

            Console.WriteLine("==================================================\n");
        }
    }
}