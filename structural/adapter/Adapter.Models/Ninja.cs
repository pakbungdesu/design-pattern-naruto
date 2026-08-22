using Jutsus;
using ElementTypes;

namespace Ninjas
{
    public class Ninja
    {
        public string Name { get; }
        public ElementType AffinityElement { get; }
        public int PersonalChakra { get; set; }
        public List<Jutsu> Jutsus { get; } = new();

        public Ninja(string name, ElementType affinityElement, int personalChakra)
        {
            Name = name;
            AffinityElement = affinityElement;
            PersonalChakra = personalChakra;
        }

        public void Cast(int jutsuIndex, Ninja target)
        {
            Jutsus[jutsuIndex].Execute(this, target);
        }
    }
}