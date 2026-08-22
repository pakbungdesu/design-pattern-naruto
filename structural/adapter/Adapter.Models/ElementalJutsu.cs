using ElementTypes;

namespace ElementalJutsus
{
    public class ElementalJutsu
    {
        public string Name { get; }
        public ElementType Element { get; }
        public int RequiredChakra { get; }

        public ElementalJutsu(string name, ElementType element, int requiredChakra)
        {
            Name = name;
            Element = element;
            RequiredChakra = requiredChakra;
        }
    }
}