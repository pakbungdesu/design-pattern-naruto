namespace Builder.Models.Ninja
{
    public class MedicalNinja : Ninja
    {
        private static int count = 0;

        private int id = 0;

        public MedicalNinja()
        {
            id = count++;
            regNumber = "MED-" + id.ToString("D4");    
        }

        ~MedicalNinja()
        {
            count--;
        }

        public static int getCount()
        {
            return count;
        }
    }
}