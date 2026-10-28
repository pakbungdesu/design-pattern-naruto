using Prototype.Models.Ninjas;

namespace Prototype.Models.Jutsus
{
    public class Wind : Jutsu
    {
        public double armorPenetration { get; set; }

        public Wind(string jutsuName, double multiplier, int chakraCost, double armorPenetration)
        {
            this.jutsuName = jutsuName;
            this.multiplier = multiplier;
            this.chakraCost = chakraCost;
            this.armorPenetration = armorPenetration;
            this.attackType = "split";
        }

        public override void execute(Ninja attacker, Ninja defender)
        {
            int rawDamage = (int)(attacker.baseAttack * multiplier);
            int finalDamage = (int)(rawDamage * (1.0 + armorPenetration));   

            Console.WriteLine($"🌪️ {attacker.name} casts {jutsuName} on {defender.name}!");
            Console.WriteLine($"   -> Raw damage = {rawDamage}.");
            Console.WriteLine($"   -> Armor penetration = {armorPenetration * 100}%.");
            Console.WriteLine($"   -> Final damage = {finalDamage}.");

            attacker.attack(defender, this.chakraCost);
            defender.defend(finalDamage);
        }

        public override Jutsu clone()
        {
            return new Wind(this.jutsuName, this.multiplier, this.chakraCost, this.armorPenetration);
        }
    }
}