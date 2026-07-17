
namespace Abstract.Factory.Models
{
    public abstract class Weapon
    {
        public double Price {get; set;} = 500;
        
        public abstract void attack();
    }
}