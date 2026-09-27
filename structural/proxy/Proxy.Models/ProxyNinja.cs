
using Ninjas;
using RealNinjas;

namespace ProxyNinjas
{
    public class ProxyNinja : Ninja
    {
        private RealNinja _RealNinja;
        private string _BasicPassword;

        public ProxyNinja(RealNinja realNinja, string pw)
        {
            _RealNinja = realNinja;
            _BasicPassword = pw;
        }

        private bool HasPermission(string pw)
        {
            return pw == _BasicPassword;
        }

        // Proxy request method with protection control
        public bool Request(string pw)
        {
            if (HasPermission(pw))
            {
                Console.WriteLine("[ProxyNinja] Permission granted. Forwarding request to RealNinja.");
                return _RealNinja.Request(pw);
            }
            Console.WriteLine("[ProxyNinja] Permission denied.");
            return false;
        }
    }
}