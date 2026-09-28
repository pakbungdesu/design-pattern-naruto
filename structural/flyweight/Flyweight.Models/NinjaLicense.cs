using MissionRanks;

namespace NinjaLicenses
{
    // Flyweight Class
    public class NinjaLicense
    {
        public string TierName { get; }
        public string Scope { get; }
        public string Restriction { get; }

        public MissionRank AllowedRank { get; }

        public NinjaLicense(string tierName, string scope, string restriction)
        {
            TierName = tierName;
            Scope = scope;
            Restriction = restriction;
        }

        public void Display()
        {
            Console.WriteLine($"[License] Tier: {TierName} | Scope: {Scope} | Restriction: {Restriction}");
        }

        public bool IsEligibleFor(MissionRank missionRank)
        {
            return AllowedRank >= missionRank; 
        }
    }
}