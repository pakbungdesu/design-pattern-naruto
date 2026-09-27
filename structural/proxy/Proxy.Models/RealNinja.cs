using Ninjas;

namespace RealNinjas
{
    public class RealNinja : Ninja
    {
        private string _AdvancedPassword;
        public string Name { get; set; }
        public string BasicToken { get; set; } = "random123";
        public string AdvancedToken { get; set; } = "random123";

        public RealNinja(string name, string pw)
        {
            Name = name;
            _AdvancedPassword = pw;
        }

        public bool Request(Ninja caller)
        {
            Console.WriteLine($"[RealNinja] Request received from {caller.Name}. Validating tokens.");
            return caller.AdvancedToken == _AdvancedPassword;
        }
    }
}