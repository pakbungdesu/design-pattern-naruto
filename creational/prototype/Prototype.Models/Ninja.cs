using Prototype.Models.Jutsus;

namespace Prototype.Models.Ninjas
{
    public class Ninja {
        public string name { get; set; }
        public int baseAttack { get; set; }
        // Chakra acts as both Life Pool (HP) and Energy Pool (MP)
        public int chakra { get; set; }
        public int shield { get; set; }
        public bool isDefeated => chakra <= 0;
        public bool isStunned { get; set; } = false;
        public List<Jutsu> jutsuList { get; set; } = new List<Jutsu>();

        public Ninja(string name, List<Jutsu> jutsuList, int baseAttack = 100, int chakra = 10000, int shield = 10000)
        {
            this.name = name;
            this.baseAttack = baseAttack;
            this.chakra = chakra;
            this.shield = shield;
            this.jutsuList = jutsuList;
        }

        public void attack(Ninja target, int chakraCost)
        {
            if (isDefeated)
            {
                Console.WriteLine($"❌ {name} has no chakra left to move!");
                return;
            }

            if (target.isDefeated)
            {
                Console.WriteLine($"⚠️ {target.name} is already defeated!");
                return;
            }

            if (chakra < chakraCost)
            {
                Console.WriteLine($"⚠️ {name} does not have enough chakra ({chakra}/{chakraCost}) to execute the jutsu safely!");
                return;
            }

            chakra -= chakraCost;
            Console.WriteLine($"⚔️ {name} uses the jutsu! (Spent {chakraCost} chakra | Remaining: {chakra})");

            if (isDefeated)
            {
                Console.WriteLine($"💀 {name} exhausted all their chakra executing the jutsu and collapsed!");
            }
        }
        
        public void defend(int incomingdamage)
        {
            int remainingdamage = incomingdamage;

            // Resolve Shield Defense first
            if (shield > 0)
            {
                int absorbed = Math.Min(shield, remainingdamage);
                shield -= absorbed;
                remainingdamage -= absorbed;
                Console.WriteLine($"🛡️ {name}'s shield absorbed {absorbed} damage. Remaining shield: {shield}");
            }

            // Resolve Direct Chakra Drain 
            if (remainingdamage > 0)
            {
                chakra = Math.Max(0, chakra - remainingdamage);
                Console.WriteLine($"💥 {name} lost {remainingdamage} chakra from the hit! Remaining Chakra: {chakra}");

                if (isDefeated)
                {
                    Console.WriteLine($"💀 {name}'s chakra has been completely depleted! {name} is defeated!");
                }
            }
        }

        public void applyBurn(int burnDamage, int burnDuration)
        {
            Console.WriteLine($"🔥 {name} is burning and will take {burnDamage} damage for {burnDuration} seconds!");
            for (int i = 0; i < burnDuration; i++)
            {
                if (isDefeated) break;
                chakra = Math.Max(0, chakra - burnDamage);
                Console.WriteLine($"🔥 {name} takes {burnDamage} burn damage! Remaining Chakra: {chakra}");
            }
        }

        public void applyStun()
        {
            Console.WriteLine($"⚡ {name} is stunned for one turn and cannot act!");
            isStunned = true;
            
        }

        public void applyAbsorb(double absorbEffect)
        {
            int absorbedAmount = (int)(baseAttack * absorbEffect * 0.5);
            shield += absorbedAmount;
            chakra += absorbedAmount;
            Console.WriteLine($"💧 {name} absorbs {absorbedAmount} chakra and shield points!");
        }

        public void displayInfo()
        {
            Console.WriteLine($"Ninja: {name}");
            Console.WriteLine($"Base Attack: {baseAttack}");
            Console.WriteLine($"Chakra: {chakra}");
            Console.WriteLine($"Shield: {shield}");
            Console.WriteLine($"Status: {(isDefeated ? "Defeated" : isStunned ? "Stunned" : "Active")}");
            Console.WriteLine($"Jutsus:");
            foreach (var jutsu in jutsuList)
            {
                Console.WriteLine($" - {jutsu.jutsuName} (Type: {jutsu.attackType}, Multiplier: {jutsu.multiplier}, Chakra Cost: {jutsu.chakraCost})");
            }
        }

        public void copyOtherSkill(Ninja other, int jutsuId)
        {
            if (jutsuId < 0 || jutsuId >= other.jutsuList.Count)
            {
                Console.WriteLine($"⚠️ Invalid jutsu ID {jutsuId} for {other.name}.");
                return;
            }

            this.jutsuList.Add(other.jutsuList[jutsuId].clone());
            Console.WriteLine($"🔄 {name} copied the jutsu '{other.jutsuList[jutsuId].jutsuName}' from {other.name}!");
        }

        public void copyOtherSkills(Ninja other)
        {
            foreach (var jutsu in other.jutsuList)
            {
                this.jutsuList.Add(jutsu.clone());
                Console.WriteLine($"🔄 {name} copied the jutsu '{jutsu.jutsuName}' from {other.name}!");
            }
            Console.WriteLine($"✅ {name} has copied all jutsus from {other.name}!");
        }

        public void useJutsu(int index, Ninja target)
        {
            if (index < 0 || index >= jutsuList.Count)
            {
                Console.WriteLine($"⚠️ {name} does not have a jutsu at slot {index}.");
                return;
            }

            jutsuList[index].execute(this, target);
        }
    }
}
