namespace Abstract.Factory.Models.Kirigakure
{
    public class HiddenMistJutsu: Defense
    {
        public override void block()
        {
            Console.WriteLine("Hidden Mist Jutsu Used");
        }
    }
}