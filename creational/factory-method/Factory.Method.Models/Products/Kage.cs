namespace Factory.Method.Models.Products
{
    public class Kage: Ninja
    {
        public string Name { get; set; } = "Anonymous";
        public NinjaRank Rank { get; set; } = NinjaRank.Kage;
        public int Health { get; set; } = 5000;
        public int Chakra { get; set; } = 3000;
        public int Speed { get; set; } = 95;

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