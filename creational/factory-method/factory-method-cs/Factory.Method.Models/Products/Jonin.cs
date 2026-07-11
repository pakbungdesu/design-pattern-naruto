namespace Factory.Method.Models
{
    public class Jonin: Ninja
    {
        public string Name { get; set; } = "Anonymous";
        public NinjaRank Rank { get; set; } = NinjaRank.Jonin;
        public int Health { get; set; } = 2000;
        public int Chakra { get; set; } = 1500;
        public int Speed { get; set; } = 85;

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