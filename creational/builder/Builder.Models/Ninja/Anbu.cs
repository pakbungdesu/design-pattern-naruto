using System;

namespace Builder.Models.Ninja
{
    public class Anbu : Ninja
    {
        private static int count = 0;
        private int id = 0;

        public string mask { get; internal set; } = string.Empty;

        public Anbu()
        {
            id = count++;
            regNumber = "ANBU-" + id.ToString("D4");
        }

        ~Anbu()
        {
            count--;
        }

        public static int getCount()
        {
            return count;
        }

        public override void displayInfo()
        {
            base.displayInfo();
            Console.WriteLine($"Mask: {mask}");
        }
    }
}