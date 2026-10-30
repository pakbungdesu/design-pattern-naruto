using Originators;
using Caretakers;
using Enums;

public class Program 
{
    static void Client(Movement m, Caretaker ct)
    {
        m.Display();
        ct.AddHistory();
    }

    public static void Main(string[] args) 
    {
        Movement ninjaMovement = new Movement(Direction.Forward, Act.Walk, 4);
        Caretaker caretaker = new Caretaker(ninjaMovement);

        Console.WriteLine("\n--- Start Moving ---");
        Client(ninjaMovement, caretaker);

        
        ninjaMovement.Direction = Direction.Right;
        ninjaMovement.Act = Act.Run;
        ninjaMovement.Step = 10;
        Client(ninjaMovement, caretaker);

        ninjaMovement.Direction = Direction.Left;
        ninjaMovement.Act = Act.Crawl;
        ninjaMovement.Step = 6;
        Client(ninjaMovement, caretaker);

        ninjaMovement.Direction = Direction.Backward;
        ninjaMovement.Act = Act.Walk;
        ninjaMovement.Step = 3;
        Client(ninjaMovement, caretaker);

        ninjaMovement.Direction = Direction.Forward;
        ninjaMovement.Act = Act.Run;
        ninjaMovement.Step = 5;
        Client(ninjaMovement, caretaker);

        Console.WriteLine("\n--- Reversing History (Undo All) ---");
        while (true) 
        {
            try 
            {
                caretaker.Undo();
                ninjaMovement.Display();
            }
            catch 
            {
                Console.WriteLine("Nothing left in history.");
                break;
            }
        }
    }
}
