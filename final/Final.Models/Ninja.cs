
namespace Ninjas
{
    using Requests;
    using Weapons;
    using Enums;

    public interface Shinobi
    {
        void Display();
        void AttackTarget(Ninja target);
    }

    public class Squad : Shinobi
    {
        public string SquadName { get; set; } = "Anonymous Squad";
        public MissionRequest? Mission { get; set; }
        public List<Shinobi> Members { get; set; } = new List<Shinobi>();
        public void Add(Shinobi unit) { Members.Add(unit); }
        public void Remove(Shinobi unit) { Members.Remove(unit); }

        public void AttackTarget(Ninja target) 
        {
            foreach (var member in Members)
            {
                member.AttackTarget(target);
            }
        }

        public void Display() { 
            
            Console.WriteLine($"Squad: {SquadName}");
            foreach (var member in Members)
            {
                member.Display();
            }
        }
    }

    public abstract class Ninja : Shinobi
    {
        public string Name { get; set; } = "Anonymous Ninja";
        public ChakraType ChakraNature { get; set; }
        public int Attack { get; set; }
        public double Heal { get; set; }
        public int HP { get; set; }
        public Location Village { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public bool IsReady { get; set; } = false;
        public abstract void AttackTarget(Ninja target);
        public abstract void Display();
        public Ninja(string name, ChakraType chakraNature, int attack, double heal, int hp, Location village)
        {
            Name = name;
            ChakraNature = chakraNature;
            Attack = attack;
            Heal = heal;
            HP = hp;
            Village = village;
        }
    }

    public class Chunin : Ninja { 
        public int StaminaPoints { get; set; }

        public Chunin(string name, ChakraType chakraNature, int attack, double heal, int hp, Location village, int stamina)
            : base(name, chakraNature, attack, heal, hp, village)
        {
            StaminaPoints = stamina;
        }

        public override void AttackTarget(Ninja target)
        {
            int damage = Attack + (int)(StaminaPoints * 0.5);
            Console.WriteLine($"{Name} (Chunin) attacks {target.Name} for {damage} damage.");
            target.HP -= damage;
        }

        public override void Display()
        {
            Console.WriteLine($"Chunin: {Name}, Chakra: {ChakraNature}, Attack: {Attack}, Heal: {Heal}, HP: {HP}, Village: {Village}, Stamina: {StaminaPoints}");
        }
    }

    public class Jonin : Ninja { 
        public string JutsuMastery { get; set; } = "Mysterious Jutsu";
        public double ElementBoost { get; set; } = 0.7;

        public Jonin(string name, ChakraType chakraNature, int attack, double heal, int hp, Location village, string jutsuSpecialty, double elementBoost = 0.7)
            : base(name, chakraNature, attack, heal, hp, village)
        {
            JutsuMastery = jutsuSpecialty;
            ElementBoost = elementBoost;
        }

        public override void AttackTarget(Ninja target){
            int damage = Attack + (int)(Attack * ElementBoost);
            Console.WriteLine($"{Name} (Jonin) attacks {target.Name} for {damage} damage.");
            target.HP -= damage;
        }

        public override void Display()
        {
            Console.WriteLine($"Jonin: {Name}, Chakra: {ChakraNature}, Attack: {Attack}, Heal: {Heal}, HP: {HP}, Village: {Village}, Jutsu: {JutsuMastery}");
        }
    }

    public class Kage : Ninja { 
        public int BijuuChakraPool { get; set; } = 1000;

        public Kage(string name, ChakraType chakraNature, int attack, double heal, int hp, Location village, int bijuuPool)
            : base(name, chakraNature, attack, heal, hp, village)
        {
            BijuuChakraPool = bijuuPool;
        }

        public override void AttackTarget(Ninja target)
        {
            int damage = Attack + (int)(BijuuChakraPool * 1.5);
            Console.WriteLine($"{Name} (Kage) attacks {target.Name} for {damage} damage.");
            target.HP -= damage;
        }

        public override void Display()
        {
            Console.WriteLine($"Kage: {Name}, Chakra: {ChakraNature}, Attack: {Attack}, Heal: {Heal}, HP: {HP}, Village: {Village}, Bijuu Chakra: {BijuuChakraPool}");
        }
    }

    // --- Decorator ---
    public abstract class Decorator : Ninja
    {
        protected Ninja _ninja;
        public Decorator(Ninja ninja)
            : base(
                ninja.Name,
                ninja.ChakraNature,
                ninja.Attack,
                ninja.Heal,
                ninja.HP,
                ninja.Village)
        {
            _ninja = ninja;
        }

        public override void AttackTarget(Ninja target)
        {
            _ninja.AttackTarget(target);
        }

        public override void Display()
        {
            _ninja.Display();
        }   
    }

    public class Tank : Decorator { 
        public float Endurance { get; set; } 
        public Tank(Ninja n, float endurance) : base(n) { 
            Endurance = endurance;
        }

        public override void AttackTarget(Ninja target)
        {
            base.AttackTarget(target);
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Tank Endurance: {Endurance}");
        }
    }

    public class Anbu : Decorator { 
        public float Speed { get; set; } 
        public Anbu(Ninja n, float speed) : base(n) { 
            Speed = speed;
        }

        public override void AttackTarget(Ninja target)
        {
            base.AttackTarget(target);
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Anbu Speed: {Speed}");
        }
    }

    public class Medic : Decorator 
    { 
        public string MedicalRank { get; set; } 
        public string HospitalCode { get; set; } 

        public Medic(Ninja n, string medicalRank, string hospitalCode) : base(n) { 
            MedicalRank = medicalRank;
            HospitalCode = hospitalCode;
        }

        public void HealPatient(Ninja patient)
        {
            int healAmount = (int)(Heal * 10);
            patient.HP += healAmount;
            Console.WriteLine($"{Name} heals {patient.Name} for {healAmount} HP.");
        } 

        public override void AttackTarget(Ninja target)
        {
            base.AttackTarget(target);
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Medic Medical Rank: {MedicalRank}, Hospital Code: {HospitalCode}");
        }
    }
}