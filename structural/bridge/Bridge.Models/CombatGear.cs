using Ninjas;

namespace CombatGears
{
    public abstract class CombatGear
    {
        public Chakras.Chakra? Effect { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public abstract void PrepareMaterial();
        public abstract void Enchant();
    }

    public class Weapon : CombatGear
    {
        public Weapon(Chakras.Chakra chakra, string modelName)
        {
            Effect = chakra;
            ModelName = modelName;
        }

        public override void PrepareMaterial() => Console.WriteLine($"Preparing weapon for '{ModelName}'...");
        public override void Enchant() => Console.WriteLine($"Enchanting {ModelName} with {Effect?.ElementName}...");

        public int Attack(Ninja target)
        {
            Console.WriteLine($"-> Striking {target.Name} with {ModelName} ({Effect?.ElementName} Infused)...");
            int finalDamage = Effect?.ApplyOffense(target.BaseAttack) ?? 0;
            return finalDamage;
        }
    }

    public class Defence : CombatGear
    {
        public double AbsorbRatio { get; set; } = 0.15;
        public Defence(Chakras.Chakra chakra, string modelName)
        {
            Effect = chakra;
            ModelName = modelName;
        }

        public override void PrepareMaterial() => Console.WriteLine($"Preparing defence for '{ModelName}'...");
        public override void Enchant() => Console.WriteLine($"Enchanting {ModelName} with {Effect?.ElementName}...");
        public int Protect(int incomingDamage)
        {
            Console.WriteLine($"-> Guarding with {ModelName} ({Effect?.ElementName} Infused)...");
            int damageAfterArmor = (int)(incomingDamage * (1 - AbsorbRatio));
            int finalDamage = Effect?.ApplyDefense(damageAfterArmor) ?? 0;
            return finalDamage;
        }
    }

    public class Outfit : CombatGear
    {
        public string Color { get; set; } = "Default";

        public Outfit(Chakras.Chakra chakra, string color , string modelName)
        {
            Effect = chakra;
            Color = color;
            ModelName = modelName;
        }

        public override void PrepareMaterial() => Console.WriteLine($"Preparing outfit for '{ModelName}'...");
        public override void Enchant() => Console.WriteLine($"Enchanting {ModelName} with {Effect?.ElementName}...");   
        public void Wear()
        {
            Console.WriteLine($"-> Wearing {ModelName} ({Color} Color) with {Effect?.ElementName} Infused...");
        }
    }
}