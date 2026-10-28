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

        public void DisplayNinja()
        {
            Console.WriteLine("Name: " + Name);
        }
    }

    // Genin (Rank D, C)
    public class Genin : Ninja
    {
        public int AcademyGraduationScore {get; set;} = 80;

        public Jonin? MentorJonin { get; set; } = null;
        public Genin(string name) : base(name) { }

        public Genin(string name, int AcademyGraduationScore): base(name)
        {
            this.AcademyGraduationScore = AcademyGraduationScore;
        }

        public override bool CanTakeMission(Mission mission)
        {
            return mission is DRank || mission is CRank;
        }
    }

    // Chunin (Rank B)
    public class Chunin : Ninja
    {
        // 1-5
        public int LeadershipScore {get; set;} = 3;

        public Chunin(string name) : base(name) { }

        public Chunin(string name, int LeadershipScore) : base(name)
        {
            this.LeadershipScore = LeadershipScore;
        }

        public override bool CanTakeMission(Mission mission)
        {
            return mission is BRank;
        }
    }

    // Jonin (Rank A, S)
    public class Jonin : Ninja
    {
        public string Specialization {get; set;} = "Tactics";

        public bool HasAnbuExperience {get; set;} = false;

        public Jonin(string name) : base(name) { }

        public Jonin(string name, string Specialization, bool HasAnbuExperience) : base(name)
        {
            this.Specialization = Specialization;
            this.HasAnbuExperience = HasAnbuExperience;
        }

        public override bool CanTakeMission(Mission mission)
        {
            return mission is ARank || mission is SRank;
        }
    }

    // Kage (Singleton - Master) (Rank A, S)
    // sealed class is a class that cannot be inherited
    public sealed class Kage : Ninja
    {
        private static readonly Lazy<Kage> _instance = 
            new Lazy<Kage>(() => new Kage("Tsunade", "Konohagakure"));

        public string VillageName { get; private set; }

        private Kage(string name, string villageName) : base(name)
        {
            VillageName = villageName;
        }

        public static Kage GetInstance()
        {
            return _instance.Value;
        }

        public override bool CanTakeMission(Mission mission)
        {
            return mission is SRank || mission is ARank;
        }
    }
}