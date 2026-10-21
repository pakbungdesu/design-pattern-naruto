using Ninjas;
using RealNinjas;

namespace ProxyNinjas
{
    public class ProxyNinja : Ninja
    {
        private readonly RealNinja _realNinja;
        private readonly string _validSecurityToken;
        private readonly Role _Role;
        public string Name => _realNinja.Name;

        public ProxyNinja(RealNinja realNinja, string validSecurityToken, Role role = Role.Chunin)
        {
            _realNinja = realNinja;
            _validSecurityToken = validSecurityToken;
            _Role = role;
        }

        public bool ExecuteMission(AuthContext callerContext)
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

            if (callerContext.Mission.RoleRequired < _Role)
            {
                Console.WriteLine($"[ProxyNinja] Access Denied: Mission required '{callerContext.Mission.RoleRequired}', but got {_Role}.");
                return false;
            }

            Console.WriteLine($"[ProxyNinja] Authorization granted for caller with role '{callerContext.Mission.RoleRequired}'. Forwarding request.");
            
            return _realNinja.ExecuteMission(callerContext);
        }
    }
}