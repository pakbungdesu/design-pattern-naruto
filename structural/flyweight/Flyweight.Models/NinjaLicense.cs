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

        public bool IsEligibleFor(MissionRank missionRank)
        {
            bool rankValid = AllowedRank >= missionRank;
            bool restrictionValid = true;

            if (Restriction.ToLower().Contains("supervised") && missionRank >= MissionRank.B)
            {
                // Supervised licenses cannot handle high-rank missions alone
                restrictionValid = false;
            }

            return rankValid && restrictionValid;
        }
    }
}