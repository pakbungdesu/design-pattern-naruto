using Singleton.Models.Missions;

namespace Singleton.Models.Ninjas
{
    public abstract class Ninja
    {
        public string Name { get; set; }

        protected Ninja(string name)
        {
            Name = name;
        }

        public abstract bool CanTakeMission(Mission mission);
    }

    // Genin (Rank D, C)
    public class Genin : Ninja
    {
        public Genin(string name) : base(name) { }

        public override bool CanTakeMission(Mission mission)
        {
            return mission is DRank || mission is CRank;
        }
    }

    // Chunin (Rank B)
    public class Chunin : Ninja
    {
        public Chunin(string name) : base(name) { }

        public override bool CanTakeMission(Mission mission)
        {
            return mission is BRank;
        }
    }

    // Jonin (Rank A, S)
    public class Jonin : Ninja
    {
        public Jonin(string name) : base(name) { }

        public override bool CanTakeMission(Mission mission)
        {
            return mission is ARank || mission is SRank;
        }
    }

    // Kage (Singleton - Master) (Rank A, S)
    public sealed class Kage : Ninja
    {
        private static readonly Lazy<Kage> _instance = 
            new Lazy<Kage>(() => new Kage("Tsunade"));

        private Kage(string name) : base(name) { }

        public static Kage Instance => _instance.Value;

        public override bool CanTakeMission(Mission mission)
        {
            return mission is SRank || mission is ARank;
        }
    }
}