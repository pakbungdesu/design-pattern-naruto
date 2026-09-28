using MissionRanks;
using CompositePart;

namespace Misssions
{
    public class Mission
    {
        public MissionRank Rank { get; set; }
        public Shinobi? AssignedUnit { get; set; }

        public Mission(MissionRank rank)
        {
            Rank = rank;
        }

        public void AssignUnit(Shinobi shinobi)
        {
            AssignedUnit = shinobi;
        }

        public void StartMission()
        {
            if (AssignedUnit != null && AssignedUnit.CheckLicense(Rank))
            {
                Console.WriteLine($"Mission {Rank} started successfully!");
            }
            else
            {
                Console.WriteLine($"Mission {Rank} rejected: Unit lacks valid clearance.");
            }
        }
    }
}