namespace Program
{
    using Invokers;
    using Ninjas;
    using Receivers;
    using Commands;
    using Enums;

    public class Program
    {
        static void Client(HandSign handsign, Beast beast, CommandMode cmd, Ninja ninja)
        {
            Console.WriteLine($"\n--- {ninja.Name} is executing command for {beast.GetType().Name} ---");
            handsign.SetCommand(cmd);
            ninja.ExecuteCommand(handsign);
        
        }

        static void Main()
        {
            Ninja naruto = new Ninja("Naruto");
            HandSign narutoHandSign = new HandSign("Naruto's Hand Sign");
            TailedBeast nineTails = new TailedBeast(9, "Orange", ElementNature.Wind);

            Ninja sasuke = new Ninja("Sasuke");
            HandSign sasukeHandSign = new HandSign("Sasuke's Hand Sign");
            Susanoo susanoo = new Susanoo(Stage.Perfect, "Purple");
            
            CommandMode activateCloak = new TailedCloakMode(nineTails, 5);
            CommandMode fight = new TailedFightMode(nineTails, sasuke);
            CommandMode defend = new TailedDefendMode(nineTails, sasuke);

            CommandMode susanooCloak = new SusanooCloakMode(susanoo, 10);
            CommandMode susanooFight = new SusanooFightMode(susanoo, naruto);
            CommandMode susanooDefend = new SusanooDefendMode(susanoo, sasuke);
            
            
            Client(narutoHandSign, nineTails, activateCloak, naruto);
            Client(sasukeHandSign, susanoo, susanooCloak, sasuke);

            Client(sasukeHandSign, susanoo, susanooFight, sasuke);
            Client(narutoHandSign, nineTails, defend, naruto);

            Client(narutoHandSign, nineTails, fight, naruto);
            Client(sasukeHandSign, susanoo, susanooDefend, sasuke);
        }
    }
}
