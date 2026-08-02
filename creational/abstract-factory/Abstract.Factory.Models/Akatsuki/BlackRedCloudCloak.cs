namespace Abstract.Factory.Models.Akatsuki
{
    public class BlackRedCloudCloak : Uniform
    {
        public BlackRedCloudCloak()
        {
            Price = 800;
        }

        public override void wear()
        {
            Console.WriteLine("Black Red Cloud Cloak Worn");
        }
    }
}