namespace Builder.Models.Ninja
{
    public class TankNinja : Ninja
    {
        private static int count = 0;

        private int id = 0;

        public TankNinja()
        {
            id = count++;
            regNumber = "TANK-" + id.ToString("D4");
        }

        ~TankNinja()
        {
            count--;
        }

        public static int getCount()
        {
            return count;
        }
    }
}