using MissionRanks;
using Ninjas;

namespace Missions
{
    public class Mission
    {
        public string Name { get; set; }
        public MissionRank Rank { get; set; }
        public List<Ninja> AssignedUnit { get; set; } = new List<Ninja>();

        public Mission(string name, MissionRank rank)
        {
            Name = name;
            Rank = rank;
        }

        public void Display()
        {
            Console.WriteLine($"[Mission] Name: {Name} | Rank: {Rank}");
            foreach (var ninja in AssignedUnit)
            {
                ninja.Display();
            }
        }

        public void AssignUnit(Ninja[] unit)
        {
            foreach (var ninja in unit)
            {
                AddNinja(ninja);
            }
        }

        public void AddNinja(Ninja ninja)
        {
            if(!ninja.IsDefeated){
                    Console.WriteLine($"[Mission] {ninja.Name} is dead and cannot be assigned to the mission '{Name}'.");
                    return;
            } else{
                if (ninja.License.IsEligibleFor(Rank)){
                    AssignedUnit.Add(ninja);
                    Console.WriteLine($"[Mission] {ninja.Name} has been assigned to the mission '{Name}'");
                } else {
                    Console.WriteLine($"[Mission] {ninja.Name} is not eligible for the mission '{Name}' due to license restrictions.");
                }
            }
        }

        public void RemoveNinja(Ninja ninja)
        {
            if (AssignedUnit.Contains(ninja))
            {
                AssignedUnit.Remove(ninja);
                Console.WriteLine($"[Mission] {ninja.Name} has been removed from the mission '{Name}'");
            }
            else
            {
                Console.WriteLine($"[Mission] {ninja.Name} is not part of the mission '{Name}'");
            }
        }

        public void StartMission()
        {
            Console.WriteLine($"[Mission] Starting mission '{Name}' with rank {Rank}");
            foreach (var ninja in AssignedUnit)
            {
                Console.WriteLine($"[Mission] {ninja.Name} is participating in the mission.");
            }
        }
    }
}