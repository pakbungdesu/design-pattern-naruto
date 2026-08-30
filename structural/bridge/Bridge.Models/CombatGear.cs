
namespace CombatGears
{
    public abstract class CombatGear
    {
        public Chakras.Chakra? ChakraType { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public double Multiplier { get; set; } = 1.0;

        public abstract void PrepareMaterial();
        public virtual void Enchant() => Console.WriteLine($"Infusing '{ModelName}' with {ChakraType?.ElementName}...");
    }

    public class Weapon : CombatGear
    {
        public Weapon(Chakras.Chakra chakra) => ChakraType = chakra;

        public override void PrepareMaterial() => Console.WriteLine($"Forging weapon steel for '{ModelName}'...");

        public void Attack(Ninjas.Ninja attacker, Ninjas.Ninja defender)
        {
            if (ChakraType != null)
            {
                ChakraType.ApplyOffensiveEffect(attacker, defender, Multiplier, ModelName);
            }
            else
            {
                int damage = (int)(attacker.BaseAttack * Multiplier);
                Console.WriteLine($"⚔️ {attacker.Name} attacks {defender.Name} with {ModelName} for {damage} damage.");
                defender.Defend(damage);
            }
        }
    }

    public class Defence : CombatGear
    {
        public double AbsorbRatio { get; set; } = 0.15;

        public Defence(Chakras.Chakra chakra) => ChakraType = chakra;

        public override void PrepareMaterial() => Console.WriteLine($"Inscribing defensive scrolls for '{ModelName}'...");

        public void Protect(int incomingDamage, Ninjas.Ninja defender)
        {
            if (ChakraType != null)
            {
                ChakraType.ApplyDefensiveEffect(defender, incomingDamage, AbsorbRatio, ModelName);
            }
            else
            {
                int absorb = (int)(incomingDamage * AbsorbRatio);
                int finalDamage = incomingDamage - absorb;
                Console.WriteLine($"🛡️ Shield '{ModelName}' absorbs {absorb} DMG. Final DMG: {finalDamage}");
                defender.Defend(finalDamage);
            }
        }
    }

    public class Outfit : CombatGear
    {
        public double AbsorbRatio { get; set; } = 0.15;

        public Outfit(Chakras.Chakra chakra) => ChakraType = chakra;

        public override void PrepareMaterial() => Console.WriteLine($"Making outfit for '{ModelName}'...");

        public void Protect(int incomingDamage, Ninjas.Ninja defender)
        {
            if (ChakraType != null)
            {
                ChakraType.ApplyDefensiveEffect(defender, incomingDamage, AbsorbRatio, ModelName);
            }
            else
            {
                int absorb = (int)(incomingDamage * AbsorbRatio);
                int finalDamage = incomingDamage - absorb;
                Console.WriteLine($"🥷 Outfit '{ModelName}' absorbs {absorb} DMG. Final DMG: {finalDamage}");
                defender.Defend(finalDamage);
            }
        }
    }
}