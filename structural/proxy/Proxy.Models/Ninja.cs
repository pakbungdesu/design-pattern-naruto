namespace Ninjas {
    public interface Ninja
    {
        bool ExecuteMission(string missionName, AuthContext callerContext);
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
        public Role UserRole { get; }

        public AuthContext(string token, Role role)
        {
            Token = token;
            UserRole = role;
        }
    }
}
