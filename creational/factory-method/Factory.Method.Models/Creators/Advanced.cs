namespace Factory.Method.Models
{
    public class Advanced : NinjaAcademy {

        public override Ninja createNinja()
        {
            return new Jonin();
        }
    }
}  