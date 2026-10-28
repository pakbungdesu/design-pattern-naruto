namespace Abstract.Factory.Models
{
    public abstract class Uniform
    {
        public double Price {get; set;} = 300;
        public abstract void wear();
    }
}