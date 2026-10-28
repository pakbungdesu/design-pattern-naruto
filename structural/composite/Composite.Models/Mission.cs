using Shinobis;
using MissionRanks;

namespace Missions
{
    public class Mission
    {
        public string Title { get; }
        public MissionRank Rank { get; }
        public Shinobi? AssignedUnit { get; private set; }

        public Mission(string title, MissionRank rank)
        {
            Title = title;
            Rank = rank;
        }

        public void AssignUnit(Shinobi unit)
        {
            int medics = unit.CountMedics();
            int anbu = unit.CountAnbu();
            int tanks = unit.CountTanks();

            switch (Rank)
            {
                case MissionRank.S:
                    if (anbu < 10 || medics < 1)
                    {
                        throw new InvalidOperationException(
                            $"[Rank S - Secret Assassination] Requires >= 10 Anbu & >= 1 Medic. (Current: {anbu} Anbu, {medics} Medics)");
                    }
                    break;

                case MissionRank.A:
                    if (tanks < 10 || medics < 1)
                    {
                        throw new InvalidOperationException(
                            $"[Rank A - State Related] Requires >= 10 Tanks & >= 1 Medic. (Current: {tanks} Tanks, {medics} Medics)");
                    }
                    break;
            }

            AssignedUnit = unit;
            Console.WriteLine($"[Success] Assigned to {Rank}-Rank Mission: '{Title}'");
        }

        public void StartMission()
        {
            if (AssignedUnit == null)
            {
                Console.WriteLine($"No unit assigned to '{Title}'!");
                return;
            }

            Console.WriteLine($"\n--- Commencing Rank-{Rank} Mission: {Title} ---");
            AssignedUnit.WorkInfo();
        }
    }
}