using Enums;
using Ninjas;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Ninja sasuke = new Ninja("Sasuke Uchiha", "Hidden Leaf Village");

            Console.WriteLine("--- Movement Sequence ---");
            sasuke.GoForward(Act.Run, 10);
            sasuke.GoLeft(Act.Walk, 5);
            sasuke.GoBackward(Act.Crawl, 2);
            sasuke.GoRight(Act.Run, 15);

            Console.WriteLine("\n--- Undoing Last 2 Movements ---");
            sasuke.Undo(); 
            sasuke.Undo(); 

            Console.WriteLine("\n--- Adding New Movements ---");
            sasuke.GoForward(Act.Walk, 3);
            sasuke.GoLeft(Act.Run, 8);

            Console.WriteLine("\n--- Deep Undo Sequence ---");
            sasuke.Undo(); 
            sasuke.Undo(); 
            sasuke.Undo(); 
            sasuke.Undo(); 

            Console.WriteLine("\n--- Attempting Undo on Empty History ---");
            sasuke.Undo(); 
            sasuke.Undo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}