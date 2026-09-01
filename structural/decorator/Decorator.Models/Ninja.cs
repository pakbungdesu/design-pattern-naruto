using DefensiveGears;
using OffensiveGears;

namespace Ninjas
{
    public class Ninja
    {
        public string Name { get; set; }
        public int Chakra { get; set; } = 200;
        public int Shield { get; set; } = 50;
        public double ChakraCost { get; set; } = 0.1;
        public int BaseAttack { get; set; } = 20;
        public int BaseDefense { get; set; } = 10;
        public bool IsDead => Chakra <= 0;
        public bool IsPoisoned { get; set; } = false;
        public bool CanBeSeen { get; set; } = true;
        public int PoisonTurnsRemaining { get; set; } = 0;

        private OffensiveGear? _offensiveGear;
        private DefensiveGear? _defensiveGear;

        public Ninja(string name) => Name = name;

        public void EquipOffensive(OffensiveGear gear)
        {
            _offensiveGear = gear;
            gear.Owner = this;
        }

        public void EquipDefensive(DefensiveGear gear)
        {
            _defensiveGear = gear;
            gear.Owner = this;
        }

        public int Attack(Ninja target)
        {
            // Before attacking
            if (!CheckVisibility(target))
            {
                return 0;
            }

            CheckPoisoning(target);

            // Execute Attacking (Gear vs Bare-Handed)
            Console.WriteLine($"\n[Action] {Name} attacks {target.Name}!");

            int damageDealt;
            if (_offensiveGear != null)
            {
                damageDealt = _offensiveGear.Attack(target);
            }
            else
            {
                Console.WriteLine($"  -> Bare-handed attack dealing {BaseAttack} damage.");
                target.Defend(BaseAttack);
                damageDealt = BaseAttack;
            }

            ChakraConsumption(damageDealt);
            return damageDealt;
        }

        public void ApplyPoison(int turns = 3)
        {
            IsPoisoned = true;
            PoisonTurnsRemaining = turns;
            Console.WriteLine($"  -> {Name} was poisoned for {turns} turns!");
        }

        public void Depoison()
        {
            IsPoisoned = false;
            PoisonTurnsRemaining = 0;
            Console.WriteLine($"  -> {Name} is no longer poisoned.");
        }

        public void ProcessPoisonTurn()
        {
            if (!IsPoisoned) return;

            Console.WriteLine($"  -> {Name} suffers 10 poison damage.");
            TakeDirectDamage(10);
            
            PoisonTurnsRemaining--;
            if (PoisonTurnsRemaining <= 0)
            {
                Depoison();
            }
        }

        public void ChakraConsumption(int damageDealt)
        {
            int chakraUsed = (int)(damageDealt * ChakraCost);
            Chakra = Math.Max(0, Chakra - chakraUsed);
            Console.WriteLine($"  -> {Name} used {chakraUsed} Chakra for the attack. (Remaining Chakra: {Chakra})");
        }

        public void CheckPoisoning(Ninja target)
        {
            if (IsPoisoned)
            {
                Console.WriteLine($"  -> {Name} is poisoned and takes 10 damage before attacking.");
                TakeDirectDamage(10);
            }

            if (target.IsPoisoned)
            {
                Console.WriteLine($"  -> {target.Name} is poisoned and takes 10 damage before defending.");
                target.TakeDirectDamage(10);
            }
        }

        public bool CheckVisibility(Ninja target)
        {
            if (!target.CanBeSeen)
            {
                Console.WriteLine($"  -> {target.Name} is invisible and cannot be targeted this turn.");
                return false;
            }
            return true;
        }

        public void Defend(int incomingDamage)
        {
            int gearAbsorb = _defensiveGear?.Defense(this) ?? 0;
            int totalDefense = BaseDefense + gearAbsorb;
            int netDamage = Math.Max(1, incomingDamage - totalDefense);

            Console.WriteLine($"  -> {Name} total defense mitigated {totalDefense} damage.");
            TakeDirectDamage(netDamage);
        }

        public void TakeDirectDamage(int damage)
        {
            if (Shield > 0)
            {
                int absorbed = Math.Min(Shield, damage);
                Shield -= absorbed;
                damage -= absorbed;
                Console.WriteLine($"       -> {Name}'s shield absorbed {absorbed} DMG. (Shield: {Shield})");
            }

            if (damage > 0)
            {
                Chakra = Math.Max(0, Chakra - damage);
                Console.WriteLine($"       -> {Name} takes {damage} net damage. (Chakra: {Chakra})");
            }
        }

        public void DisplayGearInfo()
        {
            Console.WriteLine($"\n================ STATUS: {Name} ================");
            Console.WriteLine($"  Offensive : {_offensiveGear?.GetInfo() ?? "None"}");
            Console.WriteLine($"  Defensive : {_defensiveGear?.GetInfo() ?? "None"}");
            Console.WriteLine($"  Is Dead   : {IsDead}");
            Console.WriteLine($"  Stats     : Chakra={Chakra} | ChakraCost={ChakraCost} | Shield={Shield} | BaseATK={BaseAttack} | BaseDEF={BaseDefense}");
            Console.WriteLine($"  Conditions: Poisoned={IsPoisoned} | CanBeSeen={CanBeSeen}");
            Console.WriteLine($"  Poison Turns Remaining: {PoisonTurnsRemaining}");
            Console.WriteLine("================================================");
        }
    }
}