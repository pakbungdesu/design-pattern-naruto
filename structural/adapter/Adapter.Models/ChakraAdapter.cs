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
            Console.WriteLine($"\n[Attempting {_jutsu.Name}]");

            int convertedChakra = GatherConvertedChakra(attacker);
            attacker.AddChakra(convertedChakra);

            Console.WriteLine($"Gained {convertedChakra} chakra from field (Personal: {attacker.PersonalChakra}, Required: {_jutsu.RequiredChakra})");

            if (attacker.CanAfford(_jutsu.RequiredChakra))
            {
                attacker.SpendChakra(_jutsu.RequiredChakra);
                Console.WriteLine($"[HIT] {attacker.Name} struck {target.Name} with {_jutsu.Name}");
            }
            else
            {
                Console.WriteLine($"[FAIL] {attacker.Name} cannot cast {_jutsu.Name} on {target.Name}.");
            }
        }

        private int GatherConvertedChakra(Ninja attacker)
        {
            double rate = CalculateRate(attacker.AffinityElement, _field.EnvironmentElement, _jutsu.Element);
            int rawChakra = _field.HarvestNaturalChakra(30);

            Console.WriteLine($"Field: {_field.EnvironmentElement} | Ninja Affinity: {attacker.AffinityElement} | Conversion Rate: {rate}");

            return (int)(rawChakra * rate);
        }

        private double CalculateRate(ElementType ninjaElement, ElementType fieldElement, ElementType jutsuElement)
        {
            if (ninjaElement == fieldElement && fieldElement == jutsuElement) return 1.5; // Boost
            if (ninjaElement == fieldElement || fieldElement == jutsuElement) return 1.0; // Standard
            return 0.4; // Penalty
        }
    }
}