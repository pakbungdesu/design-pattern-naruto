
namespace Abstract.Factory.Models
{

    public abstract class Defense
    {
        public int Price {get; set;} = 400;
        
        public abstract void block();
    }
}