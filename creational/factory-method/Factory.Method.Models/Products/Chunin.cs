namespace Factory.Method.Models.Products
{
    public class Chunin: Ninja
    {
        public string Name { get; set; } = "Anonymous";
        public NinjaRank Rank { get; set; } = NinjaRank.Chunin;
        public int Health { get; set; } = 1000;
        public int Chakra { get; set; } = 800;
        public int Speed { get; set; } = 75;

        public void attack(){
            Console.WriteLine($"{Name} casts a Jutsu!");
        }
        
        public void defend(){
            Console.WriteLine($"{Name} deflects the attack!");
        }
        
        public void heal(){
            Console.WriteLine($"{Name} regenerates chakra!");
        }

    }
}