using Ninjas;
using RealNinjas;
using ProxyNinjas;

class Program
{
    static void Client(ProxyNinja proxyNinja, string missionName, AuthContext callerContext)
    {
        bool result = proxyNinja.ExecuteMission(missionName, callerContext);
        if (result)
        {
            Console.WriteLine($"[Client] Mission '{missionName}' executed successfully.");
        }
        else
        {
            Console.WriteLine($"[Client] Mission '{missionName}' execution failed.");
        }
    }
    static void Main(string[] args)
    {

        RealNinja naruto = new RealNinja("Uzumaki Naruto");
        ProxyNinja proxyNaruto = new ProxyNinja(naruto, "validToken123", Role.Jonin);

        AuthContext validContext = new AuthContext("validToken123", Role.Jonin);
        AuthContext invalidContext = new AuthContext("invalidToken456", Role.Genin);

        Client(proxyNaruto, "Rescue the Village", validContext);
        Client(proxyNaruto, "Rescue the Village", invalidContext);
    }
}
