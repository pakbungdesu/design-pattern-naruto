using Elements;

namespace BattleFields
{
    // Adaptee
    public class BattleField
    {
        public Element EnvironmentElement { get; set; }
        public int NaturalChakraPool { get; set; }

        public BattleField(Element environmentElement, int naturalChakraPool)
        {
            EnvironmentElement = environmentElement;
            NaturalChakraPool = naturalChakraPool;
        }

        public int HarvestNaturalChakra(int req)
        {
            int harvested = Math.Min(req, NaturalChakraPool);
            NaturalChakraPool -= harvested;
            return harvested;
        }
    }
}