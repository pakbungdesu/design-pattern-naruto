using ConcreteHandlers;
using Ninjas;
using Requests;
using Levels;

class Program
{
    static void Main()
    {
        var deathCheck = new DeathCheckHandler();
        var fieldMedic = new FieldMedicHandler();
        var hospitalMedic = new HospitalMedicHandler();
        var specialist = new SpecialistHandler();
        var tsunade = new TsunadeHandler();
        var rehab = new RehabilitationHandler();

        deathCheck.SetNext(fieldMedic)
                  .SetNext(hospitalMedic)
                  .SetNext(specialist)
                  .SetNext(tsunade)
                  .SetNext(rehab);

        var ninja1 = new Ninja("Naruto") { HP = 30 };
        var request1 = new InjuryRequest(ninja1, "Severe injured and unconscious", Level.Critical);

        var ninja2 = new Ninja("Sasuke") { HP = 100 };
        var request2 = new InjuryRequest(ninja2, "Mind breaking from Mangekyo Sharingan", Level.Emergency);

        var ninja3 = new Ninja("Sakura") { HP = 1000 };
        var request3 = new InjuryRequest(ninja3, "Moderate bleeding", Level.Urgent);

        var ninja4 = new Ninja("Kakashi") { HP = 2000 };
        var request4 = new InjuryRequest(ninja4, "Minor cuts", Level.LessUrgent);

        var ninja5 = new Ninja("Itachi") { HP = 0 };
        var request5 = new InjuryRequest(ninja5, "Severe injury", Level.Critical);


        Console.WriteLine("--- Processing Ninja 1 ---");
        deathCheck.HandleRequest(request1);

        Console.WriteLine("\n--- Processing Ninja 2 ---");
        deathCheck.HandleRequest(request2);

        Console.WriteLine("\n--- Processing Ninja 3 ---");
        deathCheck.HandleRequest(request3);

        Console.WriteLine("\n--- Processing Ninja 4 ---");
        deathCheck.HandleRequest(request4);

        Console.WriteLine("\n--- Processing Ninja 5 ---");
        deathCheck.HandleRequest(request5);
    }
}