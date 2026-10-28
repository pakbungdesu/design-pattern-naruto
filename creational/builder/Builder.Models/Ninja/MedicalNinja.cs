namespace Builder.Models.Ninja
{
    public class MedicalNinja : Ninja
    {
        private static int id = 0;

        public Dictionary<string, double> healFactors { get; set; } = new Dictionary<string, double>();

        public MedicalNinja()
        {
            id++;
            regNumber = "MED-" + id.ToString("D4");    
        }

        public static int getLastId()
        {
            return id;
        }

        public int calculateHealingOtherAmount(int minutes, string conditionKey = "")
        {
            double multiplier = 1.0;

            if (!string.IsNullOrEmpty(conditionKey) && healFactors.ContainsKey(conditionKey))
            {
                multiplier = healFactors[conditionKey];
            }

            return (int)(baseHealPerMinute * minutes * multiplier);
        }

        public bool healOther(Ninja target, int minutes, string conditionKey = "")
        {
            
            bool isHealSuccessful = false;
            int healingAmount = calculateHealingOtherAmount(minutes, conditionKey);

            if(healingAmount >= chakra * 0.1)
            {
                Console.WriteLine($"❌ {name} does not have enough chakra to heal {target.name} for {healingAmount} points.");
                return isHealSuccessful;
            }

            Console.WriteLine($"💉 {name} heals {target.name} for {healingAmount} points over {minutes} minutes.");

            if (!string.IsNullOrEmpty(conditionKey) && healFactors.ContainsKey(conditionKey))
            {
                Console.WriteLine($"    - Using: {conditionKey}, Healing Multiplier: {healFactors[conditionKey]}");
            }
        
            Console.WriteLine($"    - {name}'s current chakra: {chakra}");
            Console.WriteLine($"    - {target.name}'s current chakra: {target.chakra}");

            if (isDefeated)
            {
                Console.WriteLine($"❌ {name} cannot heal because they are defeated/out of chakra!");
                return isHealSuccessful;
            }

            if (target.isDefeated)
            {
                Console.WriteLine($"⚠️ {target.name} is already defeated! {name} stops healing.");
                return isHealSuccessful;
            }

            chakra -= (int)(healingAmount * 0.1); // Healing consumes 10% of the healing amount
            target.chakra += healingAmount;

            Console.WriteLine($"After healing {target.name}");
            Console.WriteLine($"    - {name}'s current chakra: {chakra}");
            Console.WriteLine($"    - {target.name}'s current chakra: {target.chakra}");
            displayInfo();
            isHealSuccessful = true;
            return isHealSuccessful;
        }
    }
}