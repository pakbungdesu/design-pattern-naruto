using ConcreteHandlers;
using Ninjas;
using Requests;

class Program
{
    static void Main()
    {
        var label1 = new LabelHandler();
        var label2 = new LabelHandler();

        var fieldMedic = new FieldMedicHandler();
        var hospitalMedic = new HospitalMedicHandler();
        var specialist = new SpecialistHandler();
        var tsunade = new TsunadeHandler();
        var rehab = new RehabilitationHandler();

        label1.SetNext(fieldMedic)
              .SetNext(hospitalMedic)
              .SetNext(specialist)
              .SetNext(tsunade)
              .SetNext(rehab);

        label2.SetNext(specialist)
              .SetNext(tsunade)
              .SetNext(rehab);

        var ninja1 = new Ninja("Naruto") { HP = 30 };
        var request1 = new InjuryRequest(ninja1, "Severe injured and unconscious");

        var ninja2 = new Ninja("Sasuke") { HP = 100 };
        var request2 = new InjuryRequest(ninja2, "Mind breaking from Mangekyo Sharingan");

        var ninja3 = new Ninja("Sakura") { HP = 300 };
        var request3 = new InjuryRequest(ninja3, "Moderate physical bleeding");

        var ninja4 = new Ninja("Kakashi") { HP = 1000 };
        var request4 = new InjuryRequest(ninja4, "Several cuts and bruises");

        var ninja5 = new Ninja("Minato") { HP = 2000 };
        var request5 = new InjuryRequest(ninja5, "Exhaustion and fatigue");

        var ninja6 = new Ninja("Itachi") { HP = 0 };
        var request6 = new InjuryRequest(ninja6, "Internal organ failure");

        Console.WriteLine("--- Processing Ninja 1 ---");
        label2.HandleRequest(request1);

        Console.WriteLine("\n--- Processing Ninja 2 ---");
        label2.HandleRequest(request2);

        Console.WriteLine("\n--- Processing Ninja 3 ---");
        label1.HandleRequest(request3);

        Console.WriteLine("\n--- Processing Ninja 4 ---");
        label1.HandleRequest(request4);

        Console.WriteLine("\n--- Processing Ninja 5 ---");
        label1.HandleRequest(request5);

        Console.WriteLine("\n--- Processing Ninja 6 ---");
        label2.HandleRequest(request6);
    }
}