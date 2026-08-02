namespace Abstract.Factory.Models.Akatsuki
{
    public class AstralProjectionJutsu : Defense
    {
        public AstralProjectionJutsu()
        {
            Price = 800;
        }
        
        public override void block()
        {
            Console.WriteLine("Astral Projection Jutsu Used");
        }
    }
}