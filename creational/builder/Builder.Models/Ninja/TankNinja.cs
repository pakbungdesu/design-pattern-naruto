namespace Builder.Models.Ninja
{
    public class TankNinja : Ninja
    {
        private static int id = 0;

        public string? specialEyes { get; set; }

        public TankNinja()
        {
            id++;
            regNumber = "TANK-" + id.ToString("D4");
        }

        public static int getLastId()
        {
            return id;
        }

        public override void displayInfo()
        {
            base.displayInfo();
            Console.WriteLine($"    Special Eyes: {specialEyes}");
        }
    }
}