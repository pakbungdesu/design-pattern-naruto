
using Ninjas;
using RealNinjas;

namespace ProxyNinjas
{
    public class ProxyNinja : Ninja
    {
        private RealNinja _RealNinja;
        private string _BasicPassword;
        public string Name { get; set; }
        public string BasicToken { get; set; } = "random123";
        public string AdvancedToken { get; set; } = "random123";

        public ProxyNinja(string name, RealNinja realNinja, string pw)
        {
            Name = name;
            _RealNinja = realNinja;
            _BasicPassword = pw;
        }

        private bool HasPermission(Ninja caller)
        {
            if(caller.BasicToken == _BasicPassword)
            {
                Console.WriteLine($"[ProxyNinja] Basic password validated for {Name}.");
                return true;
            }
            Console.WriteLine($"[ProxyNinja] Basic password validation failed for {Name}.");
            return false;
        }


        public bool Request(Ninja caller)
        {
            if (HasPermission(caller))
            {
                return _RealNinja.Request(caller);
            }
            Console.WriteLine($"[ProxyNinja] Permission denied for {caller.Name}.");
            return false;
        }
    }
}