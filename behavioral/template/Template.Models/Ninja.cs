
namespace Ninjas
{
    using Trainings;
    
    public class Ninja
    {
        public string Name { get; }

        public Ninja(string name)
        {
            Name = name;
        }

        public void Practice(JutsuTraining training)
        {
            Console.WriteLine($"[{Name} starts {training.GetType().Name} training]");
            training.Train();
        }
    }
}