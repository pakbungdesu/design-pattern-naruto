using Ninjas;

namespace RealNinjas
{
    public class RealNinja : Ninja
    {
        private string _AdvancedPassword;

        public RealNinja(string pw)
        {
            _AdvancedPassword = pw;
        }

        public bool Request(string pw)
        {
            Console.WriteLine("[RealNinja] Request received. Validating password.");
            return pw == _AdvancedPassword;
        }
    }
}