
using System;
using System.Collections.Generic;
using MissionRanks;
using Ninjas;
using Missions;

namespace VillageManager
{
    public class Village
    {
        private List<Ninja> _Ninjas = new List<Ninja>();
        private List<Mission> _Missions = new List<Mission>();

        public void AddNinja(Ninja ninja)
        {
            if (!_Ninjas.Contains(ninja))
            {
                _Ninjas.Add(ninja);
                Console.WriteLine($"[Village]: Ninja '{ninja.Name}' has been added to the village registry.");
            }
        }

        public void RemoveNinja(Ninja ninja)
        {
            if (_Ninjas.Contains(ninja))
            {
                _Ninjas.Remove(ninja);
                Console.WriteLine($"[Village]: Ninja '{ninja.Name}' has been removed from the village registry.");
            }
        }

        public void AddMission(Mission mission)
        {
            if (!_Missions.Contains(mission))
            {
                _Missions.Add(mission);
                Console.WriteLine($"[Village]: Mission '{mission.Rank}' posted to the village board.");
            }
        }

        public void RemoveMission(Mission mission)
        {
            if (_Missions.Contains(mission))
            {
                _Missions.Remove(mission);
                Console.WriteLine($"[Village]: Mission '{mission.Rank}' removed from the board.");
            }
        }

        public bool CheckLicense(MissionRank missionRank)
        {
            Console.WriteLine($"[Village]: Checking licenses for all village ninjas for rank {missionRank}...");
            bool allPassed = true;

            foreach (var ninja in _Ninjas)
            {
                bool eligible = ninja.CheckLicense(missionRank);
                Console.WriteLine($"  - {ninja.Name}: {(eligible ? "Eligible" : "Ineligible")}");
                if (!eligible)
                {
                    allPassed = false;
                }
            }

            return allPassed;
        }

        public void Display()
        {
            foreach (var ninja in _Ninjas)
            {
                ninja.Display();
            }
        }
    }
}