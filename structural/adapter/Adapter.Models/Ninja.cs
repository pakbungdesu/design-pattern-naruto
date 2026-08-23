using ElementTypes;
using Jutsus;

namespace Ninjas
{
    public class Ninja
    {
        public string Name { get; }
        public ElementType AffinityElement { get; }
        public int PersonalChakra { get; private set; }

        public List<Jutsu> Jutsus { get; } = new();

        public Ninja(string name, ElementType affinityElement, int personalChakra)
        {
            Name = name;
            AffinityElement = affinityElement;
            PersonalChakra = personalChakra;
        }

        public void AddChakra(int amount) => PersonalChakra += amount;
        public bool CanAfford(int cost) => PersonalChakra > cost;
        public void SpendChakra(int cost) => PersonalChakra -= cost;

        public void Cast(int jutsuIndex, Ninja target)
        {
            if (jutsuIndex < 0 || jutsuIndex >= Jutsus.Count)
            {
                Console.WriteLine($"[ERROR] Invalid Jutsu selection index: {jutsuIndex}.");
                return;
            }

            if (target == null)
            {
                Console.WriteLine("[ERROR] Target does not exist.");
                return;
            }
            Jutsus[jutsuIndex].Execute(this, target);
        }
    }
}