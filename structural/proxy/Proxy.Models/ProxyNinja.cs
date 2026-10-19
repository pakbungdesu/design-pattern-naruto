using Ninjas;
using RealNinjas;

namespace ProxyNinjas
{
    public class ProxyNinja : Ninja
    {
        private readonly RealNinja _realNinja;
        private readonly string _validSecurityToken;
        private readonly Role _minRequiredRole;
        public string Name => _realNinja.Name;

        public ProxyNinja(RealNinja realNinja, string validSecurityToken, Role minRequiredRole = Role.Jonin)
        {
            _realNinja = realNinja;
            _validSecurityToken = validSecurityToken;
            _minRequiredRole = minRequiredRole;
        }

        public bool ExecuteMission(string missionName, AuthContext callerContext)
        {
            if (callerContext == null)
            {
                Console.WriteLine($"[ProxyNinja] Access Denied: Missing security context.");
                return false;
            }

            if (callerContext.Token != _validSecurityToken)
            {
                Console.WriteLine($"[ProxyNinja] Access Denied: Invalid security token.");
                return false;
            }

            if (callerContext.UserRole < _minRequiredRole)
            {
                Console.WriteLine($"[ProxyNinja] Access Denied: Role '{callerContext.UserRole}'. Mission required at level {_minRequiredRole}.");
                return false;
            }

            Console.WriteLine($"[ProxyNinja] Authorization granted for caller with role '{callerContext.UserRole}'. Forwarding request.");
            
            return _realNinja.ExecuteMission(missionName, callerContext);
        }
    }
}