using BattleFields;
using ChakraSources;
using Elements;

namespace ChakraAdapters
{
   public class ChakraAdapter : ChakraSource
    {
        private readonly BattleField _field;

        public ChakraAdapter(BattleField field)
        {
            _field = field;
        }

        public int HarvestUsableChakra(int requested, Element ninjaElem)
        {
            int rawEnergy = _field.HarvestNaturalChakra(requested);
            double rate = CalculateRate(ninjaElem, _field.EnvironmentElement);
            return (int)(rawEnergy * rate);
        }

        private double CalculateRate(Element ninjaElem, Element fieldElem)
        {
            if (ninjaElem == fieldElem) return 1.5; // Bonus
            return 1.0;                             // Standard
        }
    }
}