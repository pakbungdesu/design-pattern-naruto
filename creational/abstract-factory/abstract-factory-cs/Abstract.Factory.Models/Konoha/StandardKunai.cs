namespace Abstract.Factory.Models.Konoha
{
    public class StandardKunai: Weapon
    {
        public override void attack()
        {
            Console.WriteLine("Standard Kunai Used");
        }
    }
}