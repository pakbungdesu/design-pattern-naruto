using Originators;
using Caretakers;
using Enums;
using Ninjas;

public class Program 
{
    static void Client(Movement m, Ninja ninja)
    {
        Console.WriteLine($"Name: {ninja.Name}, Village: {ninja.Village} is moving...");
        m.Display();
        ninja.AddHistory();
    }

    public static void Main(string[] args) 
    {
        Console.WriteLine("\n--- Start Moving ---");

        Ninja ninja = new Ninja("Naruto Uzumaki", "Leaf Village");
        
        Movement movement = new Movement(Direction.Forward, Act.Walk, 4);
        Caretaker caretaker = new Caretaker(movement);
        ninja.SetCaretaker(caretaker);
        Client(movement, ninja);

        movement.Direction = Direction.Right;
        movement.Act = Act.Run;
        movement.Step = 10;
        Client(movement, ninja);

        movement.Direction = Direction.Left;
        movement.Act = Act.Crawl;
        movement.Step = 6;
        Client(movement, ninja);

        movement.Direction = Direction.Backward;
        movement.Act = Act.Walk;
        movement.Step = 3;
        Client(movement, ninja);

        movement.Direction = Direction.Forward;
        movement.Act = Act.Run;
        movement.Step = 5;
        Client(movement, ninja);

        Console.WriteLine("\n--- Reversing History (Undo All) ---");
        while (true) 
        {
            try 
            {
                ninja.Undo();
                movement.Display();
            }
            catch 
            {
                Console.WriteLine("Nothing left in history.");
                break;
            }
        }
    }
}
