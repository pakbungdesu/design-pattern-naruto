namespace NinjaSubsystems
{

    public class Ninja
    {
        public string Name { get; set; }
        public string Clan { get; set; }
        public string Jinchuriki { get; set; }

        public Ninja(string name, string clan, string jinchuriki)
        {
            Name = name;
            Clan = clan;
            Jinchuriki = jinchuriki;
        }

        public virtual void Attack(Ninja target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}!");
        }

        public virtual void Defend(Ninja attacker)
        {
            Console.WriteLine($"{Name} defends against {attacker.Name}!");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[Ninja] {Name} | Clan: {Clan} | Jinchuriki: {Jinchuriki}");
        }

        public virtual Ninja Clone()
        {
            return this;
        }
    }

    public class ShadowNinja : Ninja
    {
        public bool Lesser { get; }

        public ShadowNinja(string name, string clan, string jinchuriki): base(name, clan, jinchuriki)
        {
            Lesser = true;
        }

        public override void Attack(Ninja target) => 
            Console.WriteLine($"{Name} attacks {target.Name}!");

        public override void Defend(Ninja attacker) => 
            Console.WriteLine($"{Name} defends against {attacker.Name}!");

        public override void DisplayInfo() => 
            Console.WriteLine($"[Ninja] {Name} | Clan: {Clan} | Jinchuriki: {Jinchuriki} | Lesser: {Lesser}");

        public override Ninja Clone()
        {
            return this;
        }
    }

    public class CloneManager
    {
        private Ninja _prototype;

        public CloneManager(Ninja n)
        {
            _prototype = n;
        }

        public List<Ninja> SpawnClone(int n)
        {
            List<Ninja> ninjas = new List<Ninja>();
            for (int i = 0; i < n; i++)
            {
                ninjas.Add(_prototype.Clone());
                Console.WriteLine($"[CloneManager] Spawned clone {i + 1} of {n}.");
            }
            return ninjas;
        }
    }
}