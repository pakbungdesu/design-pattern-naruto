namespace Factory.Method.Models
{
    public class Genin: Ninja
    {
        public string Name { get; set; } = "Anonymous";
        public NinjaRank Rank { get; set; } = NinjaRank.Genin;
        public int Health { get; set; } = 500;
        public int Chakra { get; set; } = 400;
        public int Speed { get; set; } = 60;

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