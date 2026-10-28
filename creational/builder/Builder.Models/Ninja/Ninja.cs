namespace Builder.Models.Ninja
{
    public abstract class Ninja
    {
        public string? name { get; set; }
        public string? regNumber { get; set;}
        public string? body { get; set; }
        public string? shirt { get; set; }
        public string? trouser { get; set; }
        public string? headband { get; set; }
        public string? jacket { get; set; }
        public string? shoes { get; set; }
        public int chakra{ get; set;}
        public int attackFactor { get; set; }
        public int healFactor { get; set; }
        public int baseAttack { get; set; }
        public int baseHealPerMinute { get; set; }
        public bool isDefeated { get; set;}
        public Dictionary<string, double> attackFactors { get; set; } = new Dictionary<string, double>();

        public virtual void displayInfo()
        {
            Console.WriteLine($"[Ninja] Reg#: {regNumber}");
            Console.WriteLine($"    Body: {body}, Shirt: {shirt}, Jacket: {jacket}");
            Console.WriteLine($"    Trouser: {trouser}, Headband: {headband}, Shoes: {shoes}");
            Console.WriteLine($"    Chakra: {chakra}, Attack Factor: {attackFactor}, Base Attack: {baseAttack}");
            Console.WriteLine($"    Heal Factor: {healFactor}, Base Heal/Minute: {baseHealPerMinute}");
            Console.WriteLine($"    Is Defeated: {isDefeated}");
        }

        public int calculateAttackDamage(string conditionKey = "", double multiplier = 1.0)
        {
            if (!string.IsNullOrEmpty(conditionKey) && attackFactors.ContainsKey(conditionKey))
            {
                multiplier = attackFactors[conditionKey];
            }

            return (int)(baseAttack * multiplier);
        }

        public int calculateHealingAmount(int minutes, double multiplier = 1.0)
        {
            return (int)(baseHealPerMinute * minutes * multiplier);
        }

        public bool attack(Ninja target, string factorKey = "")
        {
            bool isAttackSuccessful = false;

            if (isDefeated)
            {
                Console.WriteLine($"❌ {name} cannot attack because they are defeated/out of chakra!");
                return isAttackSuccessful;
            }

            if (target.isDefeated)
            {
                Console.WriteLine($"⚠️ {target.name} is already defeated! {name} stops attacking.");
                return isAttackSuccessful;
            }

            Console.WriteLine($"Attacker: {name}, Target: {target.name}");
            Console.WriteLine($"{name}'s current Chakra: {chakra}");
            Console.WriteLine($"{target.name}'s current Chakra: {target.chakra}");

            int finalDamage = calculateAttackDamage(factorKey);
            int chakraCost = (int)(0.25 * finalDamage); // Consuming 25% of the damage as chakra cost for the attack

            if (chakra < chakraCost)
            {
                Console.WriteLine($"⚠️ {name} does not have enough chakra ({chakra}/{chakraCost}) to perform '{factorKey}'!\n");
                return isAttackSuccessful   ;
            }

            chakra -= chakraCost;
            target.chakra = Math.Max(0, target.chakra - finalDamage);

            Console.WriteLine($"{name} attacks {target.name} with factor key '{factorKey}' for {finalDamage} damage!");
            Console.WriteLine($"    - {name}'s remaining Chakra: {chakra}");
            Console.WriteLine($"    - {target.name}'s new Chakra: {target.chakra}\n");

            isAttackSuccessful = true;
            if (target.isDefeated)
            {
                Console.WriteLine($"💀 {target.name} has been defeated in battle!");
            }
            return isAttackSuccessful;
        }
 
        public bool healThis(int minutes)
        {
            bool isHealSuccessful = false;

            if (isDefeated)
            {
                Console.WriteLine($"❌ {name} cannot heal because they are defeated/out of chakra!");
                return isHealSuccessful;
            }

            int healingAmount = calculateHealingAmount(minutes);
            chakra += healingAmount;

            Console.WriteLine($"💉 {name} healed themselves for {healingAmount} points over {minutes} minutes.");
            isHealSuccessful = true;
            return isHealSuccessful;
        }
    }
}