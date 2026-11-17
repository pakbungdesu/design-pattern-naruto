
using Elements;
using Visitors;

public class Program
{
    static void Main()
    {
        List<Ninja> shinobiList = new List<Ninja>
        {
            new TaijutsuUser("Rock Lee", "Konoha", "Eight Gates: Primary Lotus", 85, 4, 2, trapped: true),
            new TaijutsuUser("Might Guy", "Konoha", "Eight Gates: Night Guy", 95, 5, 3, trapped: false),

            new NinjutsuUser("Kakashi Hatake", "Konoha", "Raikiri", Chakra.Lightning, 140, networkBlocked: true),
            new NinjutsuUser("Naruto Uzumaki", "Konoha", "Wind Style: Rasenshuriken", Chakra.Wind, 200, networkBlocked: false),

            new GenjutsuUser("Itachi Uchiha", "Akatsuki", "Tsukuyomi", 20, 5, trapped: false),
            new GenjutsuUser("Kurenai Yuhi", "Konoha", "Demonic Illusion: Tree Binding Death", 45, 3, trapped: true)
        };

        List<Visitor> visitors = new List<Visitor>
        {
            new BountyRaterVisitor(),
            new MedicalNinjaVisitor(),
            new ChakraInfusionVisitor(),
            new PrisonerOfficerVisitor(),
            new BountyRaterVisitor()
        };

        foreach (var visitor in visitors)
        {
            Console.WriteLine($"\n================ {visitor.GetType().Name} ================");
            foreach (var ninja in shinobiList)
            {
                ninja.Accept(visitor);
            }
        }
    }
}
