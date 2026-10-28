using Missions;

namespace Ninjas {
    public interface Ninja
    {
        bool ExecuteMission(AuthContext callerContext);
    }

    public enum Role
    {
        Genin,
        Chunin,
        Jonin,
        Hokage
    }

    public class AuthContext
    {
        public string Token { get; }
        public Mission Mission { get; }

        public AuthContext(string token, Mission mission)
        {
            Token = token;
            Mission = mission;
        }
    }
}
