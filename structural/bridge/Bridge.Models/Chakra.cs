namespace Chakras
{
    public abstract class Chakra
    {
        public string ElementName { get; set; } = string.Empty;
        public abstract int ApplyOffense(int baseDamage);
        public abstract int ApplyDefense(int incomingDamage);
    }

    public class FireChakra : Chakra
    {
        public int BurnBonus { get; set; }

        public FireChakra(int burnBonus = 50)
        {
            BurnBonus = burnBonus;
            ElementName = "Fire";
        }

        public override int ApplyOffense(int baseDamage)
        {
            Console.WriteLine($"      [Fire Effect] Scorch bonus adds +{BurnBonus} damage!");
            return baseDamage + BurnBonus;
        }

        public override int ApplyDefense(int incomingDamage)
        {
            Console.WriteLine($"      [Fire Effect] Flame aura softens the blow slightly.");
            return incomingDamage - BurnBonus;
        }
    }

    public class WindChakra : Chakra
    {
        public double ArmorPenetration { get; set; }

        public WindChakra(double armorPenetration = 0.35)
        {
            ArmorPenetration = armorPenetration;
            ElementName = "Wind";
        }

        public override int ApplyOffense(int baseDamage)
        {
            Console.WriteLine($"      [Wind Effect] Slices through defenses (+{ArmorPenetration * 100}%)!");
            return (int)(baseDamage * (1 + ArmorPenetration));
        }

        public override int ApplyDefense(int incomingDamage)
        {
            int mitigated = (int)(incomingDamage * 0.7); // 30% mitigation
            Console.WriteLine($"      [Wind Effect] Deflects 30% of incoming damage.");
            return mitigated;
        }
    }
}