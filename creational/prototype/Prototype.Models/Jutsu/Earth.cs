using Prototype.Models.Ninjas;

namespace Prototype.Models.Jutsus
{
    public class Earth : Jutsu
    {
        public double damageReduction { get; set; }

        public Earth(string jutsuName, double multiplier, int chakraCost, double damageReduction)
        {
            this.jutsuName = jutsuName;
            this.multiplier = multiplier;
            this.chakraCost = chakraCost;
            this.damageReduction = damageReduction;
            this.attackType = "shatter";
        }

        public override void execute(Ninja attacker, Ninja defender)
        {
            int rawDamage = (int)(attacker.baseAttack * multiplier);
            int reducedDamage = (int)(rawDamage * (1.0 - damageReduction));

            Console.WriteLine($"🪨 {attacker.name} casts {jutsuName} on {defender.name}!");
            Console.WriteLine($"   -> Raw damage = {rawDamage}.");
            Console.WriteLine($"   -> Damage reduction = {damageReduction * 100}%.");
            Console.WriteLine($"   -> Final damage after reduction = {reducedDamage}.");

            attacker.attack(defender, this.chakraCost);
            defender.defend(reducedDamage);
        }

        public override Jutsu clone()
        {
            return new Earth(this.jutsuName, this.multiplier, this.chakraCost, this.damageReduction);
        }
    }
        }