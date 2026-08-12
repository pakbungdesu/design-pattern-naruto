using Prototype.Models.Ninjas;

namespace Prototype.Models.Jutsus
{
    public class Fire : Jutsu
    {
        public int burnDamage { get; set; }
        public int burnDuration { get; set; }
        public Fire(string jutsuName, double multiplier, int chakraCost, int burnDamage, int burnDuration)
        {
            this.jutsuName = jutsuName;
            this.multiplier = multiplier;
            this.chakraCost = chakraCost;
            this.burnDamage = burnDamage;
            this.burnDuration = burnDuration;
            this.attackType = "burn";
        }

        public override void execute(Ninja attacker, Ninja defender)
        {
            int damage = (int)(attacker.baseAttack * multiplier);
            Console.WriteLine($"🔥 {attacker.name} casts {jutsuName} on {defender.name}!");
            Console.WriteLine($"   -> Damage = {damage}.");
            Console.WriteLine($"   -> {defender.name} will take {burnDamage} burn damage for {burnDuration} seconds.");
            
            attacker.attack(defender, this.chakraCost);
            defender.defend(damage);
            defender.applyBurn(burnDamage, burnDuration);
        }

        public override Jutsu clone()
        {
            return new Fire(this.jutsuName, this.multiplier, this.chakraCost, this.burnDamage, this.burnDuration);
        }
    }
}