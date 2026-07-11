namespace Factory.Method.Models
{
    public interface Ninja 
    {
        void attack();
        void defend();
        void heal();

        string Name { get; set; }
        NinjaRank Rank { get; set; }
        int Health { get; set; }
        int Chakra { get; set; }
        int Speed { get; set;}
    }
}