using Ninjas;
using RealNinjas;
using ProxyNinjas;
using Missions;

class Program
{
    static void Client(ProxyNinja proxyNinja, AuthContext callerContext)
    {
        bool result = proxyNinja.ExecuteMission(callerContext);
        if (result)
        {
            Console.WriteLine($"[Client] Mission '{callerContext.Mission.Title}' executed successfully.");
        }
        else
        {
            Console.WriteLine($"[Client] Mission '{callerContext.Mission.Title}' execution failed.");
        }
    }
    static void Main(string[] args)
    {

        RealNinja naruto = new RealNinja("Uzumaki Naruto");
        ProxyNinja proxyNaruto = new ProxyNinja(naruto, "validToken123", Role.Jonin);

        Mission mission = new Mission("Rescue the Village", "Save the village from impending doom.", 1000.0, Role.Jonin);
        AuthContext validContext = new AuthContext("validToken123", mission);
        AuthContext invalidContext = new AuthContext("invalidToken456", mission);

        Console.WriteLine("--- Attempting with valid context ---");
        Client(proxyNaruto, validContext);
        Console.WriteLine("\n--- Attempting with invalid context ---");
        Client(proxyNaruto, invalidContext);
    }
}
