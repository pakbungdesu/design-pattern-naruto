
namespace Ninjas
{
    using Requests;
    using Weapons;
    using Enums;

    public interface Shinobi
    {
        void Display();
    }

    public class Squad : Shinobi
    {
        public string SquadName { get; set; } = "Anonymous Squad";
        public MissionRequest Mission { get; set; }
        public List<Shinobi> Members { get; set; } = new List<Shinobi>();
        
        public void Add(Shinobi unit) { Members.Add(unit); }
        public void Remove(Shinobi unit) { Members.Remove(unit); }
        public void Display() { }
    }

    public class Ninja : Shinobi
    {
        public string Name { get; set; } = "Anonymous Ninja";
        public ChakraType ChakraNature { get; set; }
        public int Attack { get; set; }
        public double Heal { get; set; }
        public int HP { get; set; }
        public Location Village { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public bool IsReady { get; set; }

        public virtual void AttackTarget(Ninja target) { }
        public virtual void HealTarget(int minute) { }
        public virtual void Display() { }
    }

    public class Chunin : Ninja { 
        public int StaminaPoints { get; set; } 
    }

    public class Jonin : Ninja { 
        public string JutsuMastery { get; set; } 
        public double ElementBoost { get; set; } 
    }

    public class Kage : Ninja { 
        public int BijuuChakraPool { get; set; } 
    }

    // --- Decorator ---
    public abstract class Decorator : Ninja
    {
        protected Ninja _ninja;
        public Decorator(Ninja ninja) { _ninja = ninja; }
        public override void AttackTarget(Ninja target) { _ninja.AttackTarget(target); }
        public override void HealTarget(int minute) { _ninja.HealTarget(minute); }
        public override void Display() { _ninja.Display(); }
    }

    public class Tank : Decorator { public float Endurance { get; set; } public Tank(Ninja n) : base(n) { } }
    public class Anbu : Decorator { public float Speed { get; set; } public Anbu(Ninja n) : base(n) { } }
    public class Medic : Decorator 
    { 
        public string MedicalRank { get; set; } 
        public string HospitalCode { get; set; } 
        public void HealPatient(Ninja patient) { } 
        public Medic(Ninja n) : base(n) { } 
    }
}