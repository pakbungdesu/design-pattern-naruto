namespace Factory.Method.Models
{
    public class Intermediate : NinjaAcademy {

        public override Ninja createNinja(){
            return new Chunin();
        }
    }
}  