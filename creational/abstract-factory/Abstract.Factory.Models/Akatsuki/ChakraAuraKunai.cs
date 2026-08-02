namespace Abstract.Factory.Models.Akatsuki
{
    public class ChakraAuraKunai : Weapon
    {
        public ChakraAuraKunai()
        {
            Price = 800;
        }
        public override void attack()
        {
            Console.WriteLine("Chakra Aura Kunai Used");
        }
    }
}