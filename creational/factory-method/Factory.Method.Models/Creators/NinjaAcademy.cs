 namespace Factory.Method.Models.Creators
{
     abstract class NinjaAcademy {

      public Ninja[] Ninjas { get; set; } = Array.Empty<Ninja>();

      public abstract void createNinja(int length, string[] names);
      
      public void train(Ninja ninja){
            Console.WriteLine($"Training {ninja.Name} the {ninja.GetType().Name}...");
            ninja.attack();
            ninja.defend();
            ninja.heal();
      }

      public void train(){
            foreach (Ninja ninja in Ninjas)
            {
                  train(ninja);
            }
      }
    }
}
