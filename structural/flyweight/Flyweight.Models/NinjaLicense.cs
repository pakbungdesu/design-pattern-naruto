using MissionRanks;

namespace NinjaLicenses
{
    // Flyweight Class
    public class NinjaLicense
    {
        public string TierName { get; }

        public string Restriction { get; }

        public MissionRank AllowedRank { get; }

        public NinjaLicense(string tierName, string restriction, MissionRank allowed)
        {
            TierName = tierName;
            Restriction = restriction;
            AllowedRank = allowed;
        }

        public void Display()
        {
            Console.WriteLine($"[License] Tier: {TierName} | Restriction: {Restriction}| Maximum Rank Allowed: {AllowedRank}");
        }

        public bool CheckLicense(MissionRank missionRank)
        {
            return AllowedRank >= missionRank;
        }
    }
}