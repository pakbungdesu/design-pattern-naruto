using Ninjas;
using Elements;

namespace Jutsus
{
    public class Jutsu
    {
        public string Name { get; set; }
        public Element Element { get; set; }
        public int Cost { get; set; }

        public Jutsu(string name, Element element, int cost)
        {
            Name = name;
            Element = element;
            Cost = cost;
        }

        public int Execute(Ninja attacker, Ninja target)
        {
            Console.WriteLine($"{attacker.Name} hits {target.Name} with {Name}!");
            return Cost;
        }
    }
}