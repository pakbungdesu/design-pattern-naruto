using ConcreteHandlers;
using Ninjas;
using Requests;

class Program
{
    static void Main()
    {
        LabelHandler label1 = new LabelHandler();
        LabelHandler label2 = new LabelHandler();
        LabelHandler label3 = new LabelHandler();

        FieldMedicHandler fieldMedic = new FieldMedicHandler();
        HospitalMedicHandler hospitalMedic = new HospitalMedicHandler();
        SpecialistHandler specialist = new SpecialistHandler();
        TsunadeHandler tsunade = TsunadeHandler.GetInstance();
        RehabilitationHandler rehab = new RehabilitationHandler();

        label1.SetNext(fieldMedic)
              .SetNext(hospitalMedic)
              .SetNext(specialist)
              .SetNext(tsunade)
              .SetNext(rehab);

        label2.SetNext(specialist)
              .SetNext(tsunade)
              .SetNext(rehab);

        label3.SetNext(specialist)
              .SetNext(tsunade)
              .SetNext(null);

        Ninja ninja1 = new Ninja("Naruto") { HP = 30 };
        InjuryRequest request1 = new InjuryRequest(ninja1, "Severe injured and unconscious");

        Ninja ninja2 = new Ninja("Sasuke") { HP = 100 };
        InjuryRequest request2 = new InjuryRequest(ninja2, "Mind breaking from Mangekyo Sharingan");

        Ninja ninja3 = new Ninja("Sakura") { HP = 300 };
        InjuryRequest request3 = new InjuryRequest(ninja3, "Moderate physical bleeding");

        Ninja ninja4 = new Ninja("Kakashi") { HP = 1000 };
        InjuryRequest request4 = new InjuryRequest(ninja4, "Several cuts and bruises");

        Ninja ninja5 = new Ninja("Minato") { HP = 2000 };
        InjuryRequest request5 = new InjuryRequest(ninja5, "Exhaustion and fatigue");

        Ninja ninja6 = new Ninja("Itachi") { HP = 0 };
        InjuryRequest request6 = new InjuryRequest(ninja6, "Internal organ failure");

        Ninja ninja7 = new Ninja("Neiji") { HP = 30 };
        InjuryRequest request7 = new InjuryRequest(ninja7, "Severe injured and unconscious");

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

        Console.WriteLine("\n--- Processing Ninja 7 ---");
        label3.HandleRequest(request7);
    }
}