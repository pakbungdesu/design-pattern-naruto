
namespace Elements
{
    using Visitors;

    public enum Chakra
    {
        Fire,
        Wind,
        Lightning,
        Earth,
        Water
    }

    public abstract class Ninja
    {
        public string Name { get; set; }
        public string Village { get; set; }
        public string JutsuName { get; set; }
        public bool IsTrappedInIllusion { get; set; }

        protected Ninja(string name, string village, string jutsuName, bool isTrappedInIllusion = false)
        {
            Name = name;
            Village = village;
            JutsuName = jutsuName;
            IsTrappedInIllusion = isTrappedInIllusion;
        }

        public abstract void Accept(Visitor visitor);
    }

    public class TaijutsuUser : Ninja
    {
        public int Stamina { get; set; }
        public int MuscleTearSeverity { get; set; }
        public int BoneFractureCount { get; set; }

        public TaijutsuUser(string name, string village, string jutsuName, int stamina, int muscleTear, int fractures, bool trapped = false)
            : base(name, village, jutsuName, trapped)
        {
            Stamina = stamina;
            MuscleTearSeverity = muscleTear;
            BoneFractureCount = fractures;
        }

        public override void Accept(Visitor visitor) => visitor.VisitTaijutsuUser(this);
    }

    public class NinjutsuUser : Ninja
    {
        public Chakra ChakraType { get; set; }
        public int CurrentChakra { get; set; }
        public bool ChakraNetworkBlocked { get; set; }

        public NinjutsuUser(string name, string village, string jutsuName, Chakra chakraType, int currentChakra, bool networkBlocked, bool trapped = false)
            : base(name, village, jutsuName, trapped)
        {
            ChakraType = chakraType;
            CurrentChakra = currentChakra;
            ChakraNetworkBlocked = networkBlocked;
        }

        public override void Accept(Visitor visitor) => visitor.VisitNinjutsuUser(this);
    }

    public class GenjutsuUser : Ninja
    {
        public int UnconsciousLength { get; set; }
        public int MentalFatigue { get; set; }
        public int IllusionDifficultyRank { get; set; }

        public GenjutsuUser(string name, string village, string jutsuName, int mentalFatigue, int difficultyRank, bool trapped = false)
            : base(name, village, jutsuName, trapped)
        {
            MentalFatigue = mentalFatigue;
            IllusionDifficultyRank = difficultyRank;
        }

        public override void Accept(Visitor visitor) => visitor.VisitGenjutsuUser(this);
    }
}