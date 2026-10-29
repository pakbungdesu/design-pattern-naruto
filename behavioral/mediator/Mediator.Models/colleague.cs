
namespace colleagues
{
    using mediators;

    // 1. Define a shared interface for any combatant unit
    public interface ICombatant
    {
        string Name { get; set; }
        int Attack { get; set; }
        public int HP { get; set; }
        string Location { get; set; }
    }

    public abstract class Ninja : ICombatant
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public string Location { get; set; }
        public bool Ready {get; set;} = false;

        protected ISummitProtection _mediator;

        protected Ninja(string name, int hp, int atk, string location, ISummitProtection mediator)
        {
            Name = name;
            HP = hp;
            Attack = atk;
            Location = location;
            _mediator = mediator;
        }

        public abstract void DisplayInfo();

        public void Fight()
        {
           DisplayInfo();
           Console.WriteLine($"is fighting at {Location}...");
        }

        public void Evacuate(string route)
        {
            DisplayInfo();
            Console.WriteLine($"is evacuating by {route}");
        }

        public void Notify(string message, int winrate=100)
        {
            _mediator.Notify(this, message, winrate);
        }
    }

    // 3. Concrete Colleague: TankNinja (Combat Role)
    public class TankNinja : Ninja
    {
        public int Endurance { get; set; }

        public TankNinja(string name, int hp, int atk, int endurance, string location, ISummitProtection mediator)
            : base(name, hp, atk, location, mediator)
        {
            Endurance = endurance;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Tank Unit] {Name} | Attack: {Attack} | Endurance: {Endurance} | HP: {HP} | Ready Status: {Ready}");
        }
    }

    // 4. Concrete Colleague: AnbuNinja (Escort and Evacuation Role)
    public class AnbuNinja : Ninja
    {
        public string Mask {set; get;}

        public AnbuNinja(string name, int hp, int atk, string location, string mask, ISummitProtection mediator)
            : base(name, hp, atk, location, mediator)
        {
            Mask = mask;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[ANBU Squad] {Name} | Location: {Location} | Mask {Mask} | Ready Status: {Ready}");
        }
    }

    // 5. Concrete Colleague: MedicalNinja (Medical Treatment Role)
    public class MedicalNinja : Ninja
    {

        public MedicalNinja(string name, int hp, int atk, ISummitProtection mediator, string location ="meeting room")
            : base(name, hp, atk, location, mediator){}

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Medical Team] {Name} | Ready Status {Ready}");
        }

        public void Healing(Ninja patient)
        {
            DisplayInfo();
            Console.WriteLine($"is healing {patient.Name}...");
        }
    }

    public class Enemy : ICombatant
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public string Location { get; set; }

        public Enemy(string name, int hp, int attack, string location)
        {
            Name = name;
            HP = hp;
            Attack = attack;
            Location = location;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[Enemy] {Name} | Attack: {Attack} | Location: {Location} | HP: {HP}");
        }
    }
}
