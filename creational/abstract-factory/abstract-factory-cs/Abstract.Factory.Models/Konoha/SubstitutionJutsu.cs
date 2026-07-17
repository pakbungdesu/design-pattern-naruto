namespace Abstract.Factory.Models.Konoha
{
    public class SubstitutionJutsu: Defense
    {
        public override void block()
        {
            Console.WriteLine("Substitution Jutsu Used");
        }
    }
}