using Prototype.Models.Ninjas;

namespace Prototype.Models.Jutsus
{
    public class Water : Jutsu
    {
        public double absorbEffect { get; set; }

        public Water(string jutsuName, double multiplier, int chakraCost, double absorbEffect)
        {
            this.jutsuName = jutsuName;
            this.multiplier = multiplier;
            this.chakraCost = chakraCost;
            this.absorbEffect = absorbEffect;
            this.attackType = "drown";
        }

        public override void execute(Ninja attacker, Ninja defender)
        {
            int damage = (int)(attacker.baseAttack * multiplier);
            Console.WriteLine($"💧 {attacker.name} casts {jutsuName} on {defender.name}!");
            Console.WriteLine($"   -> Damage = {damage}.");
            Console.WriteLine($"   -> {defender.name} will absorb {absorbEffect * 100}% of the damage.");

            attacker.attack(defender, this.chakraCost);
            defender.defend(damage);
            defender.applyAbsorb(absorbEffect);
        }

        public override Jutsu clone()
        {
            return new Water(this.jutsuName, this.multiplier, this.chakraCost, this.absorbEffect);
        }
    }   
}