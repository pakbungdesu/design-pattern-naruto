
namespace WindSubsystems
{
    public class WindInfuser
    {
        private double _sharpness;
        private int _rpm;
        private double _bar;

        public WindInfuser(double sharpness, int rpm, double bar)
        {
            _sharpness = sharpness;
            _rpm = rpm;
            _bar = bar;
        }

        public void InfuseWind()
        {
            GrindChakraToBlades(_sharpness);
            GenerateVortexCurrents(_rpm);
            RegulateAirPressure(_bar);
        }

        private void GrindChakraToBlades(double sharpness) =>
            Console.WriteLine($"[WindInfuser] Chakra sharpened to {sharpness:P0}.");

        private void GenerateVortexCurrents(int rpm) =>
            Console.WriteLine($"[WindInfuser] Vortex rotating at {rpm} RPM.");

        private void RegulateAirPressure(double bar) =>
            Console.WriteLine($"[WindInfuser] Pressure stabilized at {bar} bar.");
    }
}