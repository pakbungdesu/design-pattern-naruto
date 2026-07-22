namespace Factory.Method.Models
{
    public class Elementary : NinjaAcademy {

        public override Ninja createNinja(){
            return new Genin();
        }
    }
}  