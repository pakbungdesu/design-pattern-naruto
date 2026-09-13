namespace ChakraSubsystems
{
    // Target
    public interface RasenganChakra
    {
        int Transform();
    }

    // Adaptee
    public class NaturalChakra
    {
        public int Chakra { get; set; }
        public double ConversionRate { get; set; }

        public NaturalChakra(int chakra, double rate)
        {
            Chakra = chakra;
            ConversionRate = rate;
        }

        public int Compress()
        {
            Console.WriteLine($"[ChakraTransformer] Compressing chakra: {Chakra} with conversion rate: {ConversionRate:P0}.");
            return (int)(Chakra * ConversionRate);
        }
    }

    // Adapter
    public class ChakraAdapter : RasenganChakra
    {
        private NaturalChakra _engine;

        public ChakraAdapter(NaturalChakra engine)
        {
            _engine = engine;
        }

        public int Transform()
        {
            return _engine.Compress();
        }
    }
}