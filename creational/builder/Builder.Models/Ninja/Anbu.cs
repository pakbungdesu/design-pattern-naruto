namespace Builder.Models.Ninja
{
    public class Anbu : Ninja
    {

        private static int id = 0;

        public string? mask { get; set; }

        public string? codeName { get; set; }

        public string? specialEyes { get; set; }

        public Anbu()
        {
            id++;
            regNumber = "ANBU-" + id.ToString("D4");
        }

        public static int getLastId()
        {
            return id;
        }

        public override void displayInfo()
        {
            base.displayInfo();
            Console.WriteLine($"    Mask: {mask}, Code Name: {codeName}, Special Eyes: {specialEyes}");
        }
    }
}