using Ninjas;
using Trainings;

public class Program
{
        static void Main()
        {
            Ninja naruto = new Ninja("Naruto Uzumaki");
            naruto.Practice(new TreeClimbing());
            naruto.Practice(new Rasengan());

            Ninja sasuke = new Ninja("Sasuke Uchiha");
            sasuke.Practice(new WaterWalking());
            sasuke.Practice(new Fireball());
        }
}
