using NinjaLicenses;
using MissionRanks;
using System.ComponentModel;

namespace NinjaLicenseFactories
{
    // Flyweight Factory
    public class NinjaLicenseFactory
    {
        private List<NinjaLicense> _LicenseCache = new List<NinjaLicense>();

        public NinjaLicense GetFlyweight(string tierName, string scope, string restriction, MissionRank allowed)
        {
            foreach (var license in _LicenseCache)
            {
                if (license.TierName == tierName && license.Scope == scope && license.Restriction == restriction)
                {
                    Console.WriteLine("[Factory]: Reusing existing Ninja License.");
                    return license;
                }
            }

            Console.WriteLine($"[Factory]: Can't find this Ninja License: Tier Name: '{tierName}', Scope: '{scope}', Restriction: '{restriction}'.");
            Console.WriteLine("[Factory]: Creating new Ninja License.");
            
            NinjaLicense res = new NinjaLicense(tierName, scope, restriction, allowed);
            _LicenseCache.Add(res);
            return res;
        }

        public void DisplayLicense()
        {
            foreach(var license in _LicenseCache)
            {
                Console.WriteLine("\n");
                license.Display();
            }
        }
    }
}