using NinjaSubsystems;
using WindSubsystems;
using ChakraSubsystems;
using RasenganFacades;

public class Program
{
    public static class Client
    {
        public static void ExecuteJutsu(RasenganFacade facade, int n)
        {
            Console.WriteLine("[Client] Initiating Rasengan jutsu...");
            facade.Cast(n);
            Console.WriteLine("[Client] Rasengan jutsu execution completed.");
        }
    }
    public static void Main()
    {
        // Setup subsystems
        Ninja naruto = new ShadowNinja("Naruto", "Uzumaki", "Kurama");
        CloneManager cloneMgr = new CloneManager(naruto);
        NaturalChakra naturalChakra = new NaturalChakra(120, 0.85);
        WindInfuser windInfuser = new WindInfuser(0.95, 9000, 14.5);

        // Initialize Facade
        RasenganFacade facade = new RasenganFacade(cloneMgr, naturalChakra, windInfuser);

        // Delegate execution through the Client function
        Client.ExecuteJutsu(facade, 2);
    }
}
