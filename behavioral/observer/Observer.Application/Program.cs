using Publishers;
using Observers;
using Messages;

public class Program
{
    static void Main()
    {
        PainPublisher pain = PainPublisher.GetPainPublisher();

        RougeNinja itachi = new RougeNinja("Itachi Uchiha", "Leaf", 10.5f, 20.1f);
        RougeNinja kisame = new RougeNinja("Kisame Hoshigaki", "Mist", 10.6f, 20.2f);
        RougeNinja deidara = new RougeNinja("Deidara", "Stone", 45.2f, 88.3f);
        RougeNinja sasori = new RougeNinja("Sasori", "Sand", 45.4f, 88.5f);
        RougeNinja hidan = new RougeNinja("Hidan", "Hot Water", 70.1f, 15.8f);

        Squad itachiKisameDuo = new Squad("Itachi & Kisame Duo");
        itachiKisameDuo.Add(itachi);
        itachiKisameDuo.Add(kisame);

        Squad deidaraSasoriDuo = new Squad("Deidara & Sasori Art Duo");
        deidaraSasoriDuo.Add(deidara);
        deidaraSasoriDuo.Add(sasori);

        pain.Subscribe(itachiKisameDuo);
        pain.Subscribe(deidaraSasoriDuo);
        pain.Subscribe(hidan);
        
        Console.WriteLine("\n--- BROADCAST 1: Nine-Tails Intel ---");
        Message intelNaruto = new Message("Naruto Uzumaki", 9, 100.0f, 50.0f);
        pain.SetMessage(intelNaruto);

        Console.WriteLine("\n--- BROADCAST 2: One-Tail Intel ---");
        pain.Unsubscribe(deidaraSasoriDuo);
        Message intelGaara = new Message("Gaara", 1, 30.0f, 40.0f);
        pain.SetMessage(intelGaara);

        Console.WriteLine("\n--- TEST1: Composite Pattern ---");
        Squad akatsuki = new Squad("Akatsuki Team");
        akatsuki.Add(itachiKisameDuo);
        akatsuki.Add(deidaraSasoriDuo);
        akatsuki.Add(hidan);
        akatsuki.Display();

        Console.WriteLine("\n--- BROADCAST 3: Two-Tail Intel ---");
        pain.Unsubscribe(itachiKisameDuo);
        pain.Unsubscribe(hidan);
        pain.Subscribe(akatsuki);
        Message intelYugito = new Message("Yugito Nii", 2, 85.4f, 12.3f);
        pain.SetMessage(intelYugito);

        Console.WriteLine("\n--- BROADCAST 4: Eight-Tail Intel ---");
        itachiKisameDuo.Remove(kisame);
        RougeNinja tobi = new RougeNinja("Tobi", "Leaf", 12.0f, 22.0f);
        itachiKisameDuo.Add(tobi);
        
        Message intelPain = new Message("Killer Bee", 8, 55.0f, 65.0f);
        pain.SetMessage(intelPain);
    }
}