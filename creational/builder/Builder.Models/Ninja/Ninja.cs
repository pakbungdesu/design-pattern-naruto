namespace Builder.Models.Ninja
{
    public abstract class Ninja
    {
        public Jonin profile { get; internal set; } = new Jonin();
        public string regNumber { get; internal set; } = string.Empty;
        public string body { get; internal set; } = string.Empty;
        public string specialEyes { get; internal set; } = string.Empty;
        public string chainmailArmor { get; internal set; } = string.Empty;
        public string shirt { get; internal set; } = string.Empty;
        public string trouser { get; internal set; } = string.Empty;
        public string headband { get; internal set; } = string.Empty;
        public string gloves { get; internal set; } = string.Empty;
        public string bandage { get; internal set; } = string.Empty;
        public string jacket { get; internal set; } = string.Empty;
        public string shoes { get; internal set; } = string.Empty;
        public List<string> pocket { get; internal set; } = new List<string>();
        public string cloak { get; internal set; } = string.Empty;
        public string katana { get; internal set; } = string.Empty;
        public string chakraNature { get; internal set; } = string.Empty;

        public virtual void displayInfo()
        {
            Console.WriteLine($"(ID: {regNumber}) --- {GetType().Name} Profile ---");
            Console.WriteLine($"Chakra Nature: {chakraNature}");
            Console.WriteLine($"Outfit: {shirt}, {trouser}, {jacket}");
            Console.WriteLine($"Armor: {chainmailArmor}");
            Console.WriteLine($"Weapon: {katana}");
            Console.WriteLine($"Pocket Contents: {string.Join(", ", pocket)}");
            Console.WriteLine("Jutsu for attacking:");

            if (profile.attackFactors.Count > 0)
            {
                Console.WriteLine("Attack Jutsu:");
                foreach (var jutsu in profile.attackFactors)
                {
                    Console.WriteLine($" - {jutsu.Key}: x{jutsu.Value}");
                }
            }

            if (profile.healFactors.Count > 0)
            {
                Console.WriteLine("Medical Jutsu:");
                foreach (var jutsu in profile.healFactors)
                {
                    Console.WriteLine($" - {jutsu.Key}: x{jutsu.Value}");
                }
            }
        }
    }
}