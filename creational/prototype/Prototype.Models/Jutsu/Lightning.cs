using Prototype.Models.Ninjas;

namespace Prototype.Models.Jutsus
{
    public class Lightning : Jutsu
    {
        public double stunChance { get; set; }

        public Lightning(string jutsuName, double multiplier, int chakraCost, double stunChance)
        {
            this.jutsuName = jutsuName;
            this.multiplier = multiplier;
            this.chakraCost = chakraCost;
            this.stunChance = stunChance;
            this.attackType = "stun";
        }

        public override void execute(Ninja attacker, Ninja defender)
        {
            int damage = (int)(attacker.baseAttack * multiplier);
            Console.WriteLine($"⚡ {attacker.name} casts {jutsuName} on {defender.name}!");
            Console.WriteLine($"   -> Damage = {damage}.");
            
            attacker.attack(defender, this.chakraCost);
            defender.defend(damage);

            Random rand = new Random();
            if (rand.NextDouble() < stunChance)
            {
                Console.WriteLine($"   -> {defender.name} is stunned!");
                defender.applyStun();
            }
        }

        public override Jutsu clone()
        {
            return new Lightning(this.jutsuName, this.multiplier, this.chakraCost, this.stunChance);
        }
    }
}