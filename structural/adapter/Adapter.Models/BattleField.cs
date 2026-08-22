using ElementTypes;

namespace BattleFields
{

    public class BattleField
    {
        public ElementType EnvironmentElement { get; }
        public int NaturalChakraPool { get; private set; }

        public BattleField(ElementType environmentElement, int naturalChakraPool)
        {
            EnvironmentElement = environmentElement;
            NaturalChakraPool = naturalChakraPool;
        }

        public int HarvestNaturalChakra(int requestedAmount)
        {
            int harvested = Math.Min(requestedAmount, NaturalChakraPool);
            NaturalChakraPool -= harvested;
            return harvested;
        }
    }
}