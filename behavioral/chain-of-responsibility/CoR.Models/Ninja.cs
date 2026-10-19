
namespace Ninjas
{
    public class Ninja
    {
        public string Name {get; set;} = "Anonymous Ninja";
        public int HP {get; set;} = 5000;
        public int BaseAttack {get; set;} = 200;
        public double BaseHeal {get; set;} = 1.5;
        public bool IsDead => HP <= 0;

        public Ninja(string name)
        {
            Name = name;
        }

        public void Attack(Ninja target)
        {
            if (IsDead)
            {
                Console.WriteLine($"{Name} is dead and cannot attack!");
                return;
            }

            if (target.IsDead)
            {
                Console.WriteLine($"{target.Name} is already dead!");
                return;
            }

            int damage = BaseAttack;
            target.HP -= damage;

            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage! ({target.HP} HP remaining)");

            if (target.IsDead)
            {
                Console.WriteLine($"{target.Name} has been defeated!");
            }
        }

        public void Heal(double healMultiplier = 1.0)
        {
            if (IsDead)
            {
                Console.WriteLine($"{Name} is dead and cannot heal!");
                return;
            }

            double healAmount = BaseHeal * HP * healMultiplier;
            HP += (int)healAmount;

            Console.WriteLine($"{Name} heals for {healAmount:F1} HP! ({HP} HP remaining)");
        }
    }
}