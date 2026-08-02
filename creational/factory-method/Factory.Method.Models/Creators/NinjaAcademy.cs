namespace Factory.Method.Models
{
      public abstract class NinjaAcademy {

      public abstract Ninja createNinja();
      
      public void train(Ninja ninja){
            Console.WriteLine($"Training {ninja.Name} the {ninja.GetType().Name}...");
            ninja.attack();
            ninja.defend();
            ninja.heal();
      }
    }
}
