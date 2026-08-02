namespace Factory.Method.Models
{
    public class Legend : NinjaAcademy {
        public override Ninja createNinja(){
            return new Kage();
        }
    }
}  