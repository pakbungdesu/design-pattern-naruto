using Shinobis;

namespace Ninjas
{
    public abstract class Ninja : Shinobi
    {
        public string Name { get; set; }
        public int Chakra { get; set; } = 5000;
        public double ChakraCost {get; set;} = 0.1;
        public int Shield { get; set; } = 5000;
        public int BaseAttack { get; set; } = 200;
        public double BaseHealPerMinute { get; set; } = 1.5;
        public bool IsDefeated => Chakra <= 0;
        public Dictionary<string, double> AttackFactors { get; set; } = new();

        public Ninja(string name)
        {
            Name = name;
        }

        public int Attack(Ninja target, string key)
        {
            if (IsDefeated)
            {
                Console.WriteLine($"❌ {Name} has no chakra left to move!");
                return 0;
            }

            if (target.IsDefeated)
            {
                Console.WriteLine($"⚠️ {target.Name} is already defeated!");
                return 0;
            }

            int damage = CalculateAttackDamage(key);
            int chakraCost = (int)(damage * ChakraCost);

            if (Chakra < chakraCost)
            {
                Console.WriteLine($"⚠️ {Name} does not have enough chakra ({Chakra}/{chakraCost}) to execute the jutsu safely!");
                return 0;
            }

            Chakra -= chakraCost;
            Console.WriteLine($"⚔️ {Name} uses the jutsu! (Spent {chakraCost} chakra | Remaining: {Chakra})");

            if (IsDefeated)
            {
                Console.WriteLine($"💀 {Name} exhausted all their chakra executing the jutsu and collapsed!");
                return damage;
            }

            return damage;
        }
        
        public void Defend(int incomingdamage)
        {
            int remainingdamage = incomingdamage;

            // Resolve Shield Defense first
            if (Shield > 0)
            {
                int absorbed = Math.Min(Shield, remainingdamage);
                Shield -= absorbed;
                remainingdamage -= absorbed;
                Console.WriteLine($"🛡️ {Name}'s shield absorbed {absorbed} damage. Remaining shield: {Shield}");
            }

            // Resolve Direct Chakra Drain 
            if (remainingdamage > 0)
            {
                Chakra = Math.Max(0, Chakra - remainingdamage);
                Console.WriteLine($"💥 {Name} lost {remainingdamage} chakra from the hit! Remaining Chakra: {Chakra}");

                if (IsDefeated)
                {
                    Console.WriteLine($"💀 {Name}'s chakra has been completely depleted! {Name} is defeated!");
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Ninja: {Name}");
            Console.WriteLine($"Base Attack: {BaseAttack}");
            Console.WriteLine($"Chakra: {Chakra}");
            Console.WriteLine($"Shield: {Shield}");
            Console.WriteLine($"Status: {(IsDefeated ? "Defeated" : "Active")}");
            Console.WriteLine($"Jutsus:");
            foreach (KeyValuePair<string, double> entry in AttackFactors)
            {
                Console.WriteLine($"Jutsu: {entry.Key}, Multiplier: {entry.Value}");
            }
        }

        public virtual int CalculateAttackDamage(string key)
        {
            return (int)(AttackFactors.TryGetValue(key, out var factor) ? BaseAttack * factor : BaseAttack);
        }

        public virtual int CalculateHealingAmount(int minute)
        {
            return (int)(BaseHealPerMinute * minute);
        }

        public virtual void HealThis(int minute)
        {
            int amount = CalculateHealingAmount(minute);
            Console.WriteLine($"  [Self-Heal] {Name} recovers {amount} HP over {minute} minutes.");
            Chakra += amount;
            Shield += amount;
        }

        public virtual void WorkInfo()
        {
            Console.WriteLine($"  [{GetType().Name}] {Name} is on mission.");
        }

        public virtual int CountMedics() => 0;
        public virtual int CountAnbu() => 0;
        public virtual int CountTanks() => 0;
    }

    // Concrete Leaves
    public class Anbu : Ninja
    {
        public string Mask { get; set; }
        public string CodeName { get; set; }
        public string SpecialEyes { get; set; }

        public Anbu(string name, string codeName, string mask = "Fox", string specialEyes = "None") 
            : base(name)
        {
            CodeName = codeName;
            Mask = mask;
            SpecialEyes = specialEyes;
        }

        public override int CountAnbu() => 1;
    }

    public class Medic : Ninja
    {
        public Dictionary<string, int> HealFactors { get; set; } = new();

        public Medic(string name) : base(name)
        {
            Chakra = 4000;
            BaseHealPerMinute = 3.0;
            BaseAttack = 100;
        }

        public int CalculateHealingOtherAmount(int minutes, string conditionKey = "")
        {
            double multiplier = 1.0;

            if (!string.IsNullOrEmpty(conditionKey) && HealFactors.ContainsKey(conditionKey))
            {
                multiplier = HealFactors[conditionKey];
            }

            return (int)(BaseHealPerMinute * minutes * multiplier);
        }

        public bool healOther(Ninja target, int minutes, string conditionKey = "")
        {
            
            bool isHealSuccessful = false;
            int healingAmount = CalculateHealingOtherAmount(minutes, conditionKey);

            if(healingAmount >= Chakra * 0.1)
            {
                Console.WriteLine($"❌ {Name} does not have enough chakra to heal {target.Name} for {healingAmount} points.");
                return isHealSuccessful;
            }

            Console.WriteLine($"💉 {Name} heals {target.Name} for {healingAmount} points over {minutes} minutes.");

            if (!string.IsNullOrEmpty(conditionKey) && HealFactors.ContainsKey(conditionKey))
            {
                Console.WriteLine($"    - Using: {conditionKey}, Healing Multiplier: {HealFactors[conditionKey]}");
            }
        
            Console.WriteLine($"    - {Name}'s current chakra: {Chakra}");
            Console.WriteLine($"    - {target.Name}'s current chakra: {target.Chakra}");

            if (IsDefeated)
            {
                Console.WriteLine($"❌ {Name} cannot heal because they are defeated/out of chakra!");
                return isHealSuccessful;
            }

            if (target.IsDefeated)
            {
                Console.WriteLine($"⚠️ {target.Name} is already defeated! {Name} stops healing.");
                return isHealSuccessful;
            }

            Chakra -= (int)(healingAmount * 0.1); // Healing consumes 10% of the healing amount
            target.Chakra += healingAmount;

            Console.WriteLine($"After healing {target.Name}");
            Console.WriteLine($"    - {Name}'s current chakra: {Chakra}");
            Console.WriteLine($"    - {target.Name}'s current chakra: {target.Chakra}");
            DisplayInfo();
            isHealSuccessful = true;
            return isHealSuccessful;
        }

        public override int CountMedics() => 1;
    }

    public class Tank : Ninja
    {
        public string SpecialEyes { get; set; }

        public Tank(string name, string specialEyes = "Byakugan") : base(name)
        {
            SpecialEyes = specialEyes;
        }

        public override int CountTanks() => 1;
    }
}