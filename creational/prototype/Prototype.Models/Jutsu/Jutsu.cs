using Prototype.Models.Ninjas;

namespace Prototype.Models.Jutsus
{
    public abstract class Jutsu
    {
        public string jutsuName { get; set; } = "Anonymous Jutsu";
        public string? attackType { get; set; }
        public int chakraCost { get; set; }
        public double multiplier { get; set; }  
        public abstract void execute(Ninja attacker, Ninja defender);
        public abstract Jutsu clone();
    }
}