using Jutsus;
using BattleFields;
using ElementalJutsus;
using ElementTypes;
using Ninjas;

namespace ChakraAdapters
{
    public class ChakraAdapter : Jutsu
    {
        private readonly BattleField _field;
        private readonly ElementalJutsu _jutsu;

        public ChakraAdapter(BattleField field, ElementalJutsu jutsu)
        {
            _field = field;
            _jutsu = jutsu;
        }

        public override void Execute(Ninja attacker, Ninja target)
        {
            double conversionRate = CalculateRate(attacker.AffinityElement, _field.EnvironmentElement, _jutsu.Element);

            int rawChakraHarvested = _field.HarvestNaturalChakra(30);
            int convertedNaturalChakra = (int)(rawChakraHarvested * conversionRate);

            Console.WriteLine($"\n[Attempting {_jutsu.Name}]");
            Console.WriteLine($"Field: {_field.EnvironmentElement} | Ninja Affinity: {attacker.AffinityElement} | Conversion Rate: {conversionRate:P0}");
            Console.WriteLine($"Gained {convertedNaturalChakra} chakra from field (Personal: {attacker.PersonalChakra}, Required: {_jutsu.RequiredChakra})");

            attacker.PersonalChakra += convertedNaturalChakra;

            if (attacker.PersonalChakra  > _jutsu.RequiredChakra)
            {
                attacker.PersonalChakra -= _jutsu.RequiredChakra;
                Console.WriteLine($"[HIT] {attacker.Name} struck {target.Name} with {_jutsu.Name}");
            }
            else
            {
                Console.WriteLine($"[FAIL] {attacker.Name} does not have enough chakra to cast {_jutsu.Name}.");
            }
        }

        private double CalculateRate(ElementType ninjaElement, ElementType fieldElement, ElementType jutsuElement)
        {
            if (ninjaElement == fieldElement && fieldElement == jutsuElement) return 1.5; // Boost
            if (ninjaElement == fieldElement || fieldElement == jutsuElement) return 1.0; // Standard
            return 0.4; // Penalty
        }
    }
}