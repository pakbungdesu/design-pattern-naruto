namespace Abstract.Factory.Models.Kirigakure
{
    public class StandardKatana: Weapon
    {
        public override void attack()
        {
            Console.WriteLine("Standard Katana Used");
        }
    }
}