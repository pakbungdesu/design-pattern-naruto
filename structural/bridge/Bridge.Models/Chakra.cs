namespace Chakras
{
    public abstract class Chakra
    {
        public string? ElementName { get; set; }
        public int ChakraCost { get; set;}
        
        // Executes the elemental effects and damage calculations
        public abstract void ApplyOffensiveEffect(Ninjas.Ninja attacker, Ninjas.Ninja defender, double gearMultiplier, string gearName);
        public abstract void ApplyDefensiveEffect(Ninjas.Ninja defender, int incomingDamage, double baseAbsorb, string gearName);
    }

    public class FireChakra : Chakra
    {
        public int BurnDamage { get; set; } = 25;
        public int BurnDuration { get; set; } = 3;

        public FireChakra(int burnDamage = 25, int burnDuration = 3, int chakraCost = 15)
        {
            ElementName = "Fire (Katon)";
            BurnDamage = burnDamage;
            BurnDuration = burnDuration;
            ChakraCost = chakraCost;
        }

        public override void ApplyOffensiveEffect(Ninjas.Ninja attacker, Ninjas.Ninja defender, double gearMultiplier, string gearName)
        {
            int damage = (int)(attacker.BaseAttack * gearMultiplier);

            Console.WriteLine($"🔥 {attacker.Name} strikes with {gearName} [Fire]!");
            Console.WriteLine($"   -> Direct Damage = {damage}");
            Console.WriteLine($"   -> {defender.Name} will take {BurnDamage} burn damage for {BurnDuration} turns.");

            attacker.SpendChakra(ChakraCost);
            defender.Defend(damage);
            defender.ApplyBurn(BurnDamage, BurnDuration);
        }

        public override void ApplyDefensiveEffect(Ninjas.Ninja defender, int incomingDamage, double baseAbsorb, string gearName)
        {
            int absorb = (int)(incomingDamage * baseAbsorb);
            int finalDamage = incomingDamage - absorb;

            Console.WriteLine($"🔥 Fire Barrier '{gearName}' scorches incoming attack, absorbing {absorb} damage!");
            defender.Defend(finalDamage);
        }
    }

    public class WindChakra : Chakra
    {
        public double ArmorPenetration { get; set; } = 0.35;

        public WindChakra(double armorPenetration = 0.35, int chakraCost = 10)
        {
            ElementName = "Wind (Futon)";
            ArmorPenetration = armorPenetration;
            ChakraCost = chakraCost;
        }

        public override void ApplyOffensiveEffect(Ninjas.Ninja attacker, Ninjas.Ninja defender, double gearMultiplier, string gearName)
        {
            int rawDamage = (int)(attacker.BaseAttack * gearMultiplier);
            int finalDamage = (int)(rawDamage * (1.0 + ArmorPenetration));

            Console.WriteLine($"🌪️ {attacker.Name} strikes with {gearName} [Wind]!");
            Console.WriteLine($"   -> Raw damage = {rawDamage}");
            Console.WriteLine($"   -> Armor penetration = {ArmorPenetration * 100}%");
            Console.WriteLine($"   -> Final damage = {finalDamage}");

            attacker.SpendChakra(ChakraCost);
            defender.Defend(finalDamage);
        }

        public override void ApplyDefensiveEffect(Ninjas.Ninja defender, int incomingDamage, double baseAbsorb, string gearName)
        {
            // Wind deflects an additional 15% damage
            double totalAbsorb = baseAbsorb + 0.15;
            int absorb = (int)(incomingDamage * totalAbsorb);
            int finalDamage = Math.Max(0, incomingDamage - absorb);

            Console.WriteLine($"🌪️ Wind Barrier '{gearName}' deflects impact! Total absorbed: {absorb}");
            defender.Defend(finalDamage);
        }
    }
}