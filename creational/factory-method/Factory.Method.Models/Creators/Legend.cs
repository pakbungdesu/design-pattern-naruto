using Factory.Method.Models.Products;

namespace Factory.Method.Models.Creators
{
    class Legend : NinjaAcademy {
     public override void createNinja(int length, string[] names){

        if (length != names.Length)
        {
            throw new ArgumentException("Length of names array must match the specified length.");
        }

          Ninja[] ninjas = new Ninja[length];

            for (int i = 0; i < length; i++)
            {
                ninjas[i] = new Kage();
                ninjas[i].Name = names[i];
            }

            this.Ninjas = ninjas;
      }
    }
}  