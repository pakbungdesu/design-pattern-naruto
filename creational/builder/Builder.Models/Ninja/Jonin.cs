namespace Builder.Models.Ninja
{
    public class Jonin
    {
        public string name { get; set; } = "Anonymous";
        public int chakra { get; set; } = 20000;

        // Damage of this object per attacking: Total Damage * attackFactor
        public double attackFactor {get; set; } = 0.1;

        // Damage of this object per healing: Total Healing * healFactor
        public double healFactor {get; set; } = 0.1;

        // Target: baseAttack * attackFactors[string]
        public int baseAttack { get; set; } = 100;

        // Target: baseHealPerMinute * healFactors[string]
        public int baseHealPerMinute { get; set; } = 100;
        public bool isDefeated => chakra <= 0;
        public Dictionary<string, double> attackFactors { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> healFactors { get; set; } = new Dictionary<string, double>();

        public int calculateAttackDamage(string conditionKey = "")
        {
            double multiplier = 1.0;

            if (!string.IsNullOrEmpty(conditionKey) && attackFactors.ContainsKey(conditionKey))
            {
                multiplier = attackFactors[conditionKey];
            }

            return (int)(baseAttack * multiplier);
        }

        public int calculateHealingAmount(int minutes, string conditionKey = "")
        {
            double multiplier = 1.0;

            if (!string.IsNullOrEmpty(conditionKey) && healFactors.ContainsKey(conditionKey))
            {
                multiplier = healFactors[conditionKey];
            }

            return (int)(baseHealPerMinute * minutes * multiplier);
        }

        public void attack(Jonin target, string factorKey = "")
        {
            if (isDefeated)
            {
                Console.WriteLine($"❌ {name} cannot attack because they are defeated/out of chakra!");
                return;
            }

            if (target.isDefeated)
            {
                Console.WriteLine($"⚠️ {target.name} is already defeated! {name} stops attacking.");
                return;
            }

            Console.WriteLine($"Attacker: {name}, Target: {target.name}");
            Console.WriteLine($"{name}'s current Chakra: {chakra}");
            Console.WriteLine($"{target.name}'s current Chakra: {target.chakra}");

            int finalDamage = calculateAttackDamage(factorKey);
            int chakraCost = (int)(attackFactor * finalDamage);

            if (chakra < chakraCost)
            {
                Console.WriteLine($"⚠️ {name} does not have enough chakra ({chakra}/{chakraCost}) to perform '{factorKey}'!\n");
                return;
            }

            chakra -= chakraCost;
            target.chakra = Math.Max(0, target.chakra - finalDamage);

            Console.WriteLine($"{name} attacks {target.name} with factor key '{factorKey}' for {finalDamage} damage!");
            Console.WriteLine($"    - {name}'s remaining Chakra: {chakra}");
            Console.WriteLine($"    - {target.name}'s new Chakra: {target.chakra}\n");

            if (target.isDefeated)
            {
                Console.WriteLine($"💀 {target.name} has been defeated in battle!");
            }
        }

        public void heal(int minutes, string factorKey = "")
        {
            if (isDefeated)
            {
                Console.WriteLine($"❌ {name} is defeated and cannot heal themselves!\n");
                return;
            }

            int finalHeal = calculateHealingAmount(minutes, factorKey);
            chakra += finalHeal;

            Console.WriteLine($"💚 {name} heals for {minutes} min using '{factorKey}' (+{finalHeal} Chakra)!");
            Console.WriteLine($"    - {name}'s new Chakra: {chakra}\n");
        }

        public void heal(Jonin target, int minutes, string factorKey = "")
        {
            if (isDefeated)
            {
                Console.WriteLine($"❌ {name} is defeated and cannot perform medical jutsu!");
                return;
            }

            int finalHeal = calculateHealingAmount(minutes, factorKey);
            int chakraCost = (int)(healFactor * finalHeal);

            if (chakra < chakraCost)
            {
                Console.WriteLine($"⚠️ {name} lacks chakra ({chakra}/{chakraCost}) to heal {target.name}!");
                return;
            }

            chakra -= chakraCost;
            target.chakra += finalHeal;

            Console.WriteLine($"💉 Medical Ninja {name} heals {target.name} for {minutes} min using '{factorKey}' (+{finalHeal} Chakra)!");
            Console.WriteLine($"    - {name}'s remaining Chakra: {chakra}");
            Console.WriteLine($"    - {target.name}'s new Chakra: {target.chakra}\n");
        }
    }
}