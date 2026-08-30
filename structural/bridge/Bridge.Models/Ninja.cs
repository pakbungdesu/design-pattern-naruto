using CombatGears;

namespace Ninjas
{
    public class Ninja
    {
        // Core Attributes
        public string Name { get; set; }
        public int BaseAttack { get; set; }
        public int Chakra { get; set; }
        public int Shield { get; set; }
        public bool IsDefeated => Chakra <= 0;

        // Gear Loadout (Builder & Bridge)
        public List<Weapon> Weapons { get; } = new();
        public List<Defence> Defences { get; } = new();
        public Outfit? Uniform { get; set; }
        public Outfit? AddOn { get; set; }


        public Ninja(string name, int baseAttack = 100, int chakra = 10000, int shield = 10000)
        {
            Name = name;
            BaseAttack = baseAttack;
            Chakra = chakra;
            Shield = shield;
        }

        public void SpendChakra(int cost)
        {
            Chakra = Math.Max(0, Chakra - cost);
            Console.WriteLine($"⚡ {Name} spent {cost} chakra. Remaining: {Chakra}");
            if (IsDefeated)
            {
                Console.WriteLine($"💀 {Name} exhausted all chakra and collapsed!");
            }
        }

        public void Defend(int incomingDamage)
        {
            int remainingDamage = incomingDamage;

            if (Shield > 0)
            {
                int absorbed = Math.Min(Shield, remainingDamage);
                Shield -= absorbed;
                remainingDamage -= absorbed;
                Console.WriteLine($"🛡️ {Name}'s shield absorbed {absorbed} damage. Remaining Shield: {Shield}");
            }

            if (remainingDamage > 0)
            {
                Chakra = Math.Max(0, Chakra - remainingDamage);
                Console.WriteLine($"💥 {Name} took {remainingDamage} direct chakra damage! Remaining Chakra: {Chakra}");

                if (IsDefeated)
                {
                    Console.WriteLine($"💀 {Name}'s chakra depleted to 0! {Name} has been defeated!");
                }
            }
        }

        public void ApplyBurn(int burnDamage, int burnDuration)
        {
            Console.WriteLine($"🔥 {Name} is afflicted with burn ({burnDamage} DMG/turn for {burnDuration} turns)!");
            for (int i = 0; i < burnDuration; i++)
            {
                if (IsDefeated) break;
                Chakra = Math.Max(0, Chakra - burnDamage);
                Console.WriteLine($"🔥 {Name} suffered {burnDamage} burn tick. Remaining Chakra: {Chakra}");
            }
        }

        public void ApplyAbsorb(double absorbMultiplier)
        {
            int gained = (int)(BaseAttack * absorbMultiplier * 0.5);
            Shield += gained;
            Chakra += gained;
            Console.WriteLine($"💧 {Name} absorbed {gained} points into Shield and Chakra!");
        }


        public void UseWeapon(int index, Ninja target)
        {
            if (IsDefeated)
            {
                Console.WriteLine($"❌ {Name} cannot attack (Defeated: {IsDefeated}");
                return;
            }

            if (index < 0 || index >= Weapons.Count)
            {
                Console.WriteLine($"⚠️ Invalid weapon index [{index}] for {Name}.");
                return;
            }

            Weapons[index].Attack(this, target);
        }

        public void UseDefence(int index, int incomingDamage)
        {
            if (index < 0 || index >= Defences.Count)
            {
                Console.WriteLine($"⚠️ Invalid defence index [{index}] for {Name}. Taking direct hit.");
                Defend(incomingDamage);
                return;
            }

            Defences[index].Protect(incomingDamage, this);
        }

 
        public void DisplayInfo()
        {
            Console.WriteLine($"\n==================== [ {Name} ] ====================");
            Console.WriteLine($"Status:       {(IsDefeated ? "💀 Defeated" : "🟢 Active")}");
            Console.WriteLine($"Stats:        Base ATK: {BaseAttack} | Chakra/HP: {Chakra} | Shield: {Shield}");
            Console.WriteLine($"Uniform:      {Uniform?.ModelName ?? "None"} [{Uniform?.ChakraType?.ElementName ?? "None"}]");
            Console.WriteLine($"AddOn:        {AddOn?.ModelName ?? "None"} [{AddOn?.ChakraType?.ElementName ?? "None"}]");

            Console.WriteLine("Weapons:");
            for (int i = 0; i < Weapons.Count; i++)
            {
                Console.WriteLine($"  [{i}] {Weapons[i].ModelName} (x{Weapons[i].Multiplier}) [{Weapons[i].ChakraType?.ElementName}]");
            }

            Console.WriteLine("Defences:");
            for (int i = 0; i < Defences.Count; i++)
            {
                Console.WriteLine($"  [{i}] {Defences[i].ModelName} [{Defences[i].ChakraType?.ElementName}]");
            }

            Console.WriteLine("==================================================\n");
        }
    }
}