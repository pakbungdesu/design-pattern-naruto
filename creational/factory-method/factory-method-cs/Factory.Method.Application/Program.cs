using System;
using Factory.Method.Models;

namespace Factory.Method.Application
{
    class Program
    {
        static void client(NinjaAcademy academy)
        {
            academy.train();
        }

        static NinjaAcademy[] CreateNinjaAcademy(int[] lengths, string[][] names)
        {
            if(lengths.Length != 4)
            {
                throw new ArgumentException("Lengths array must have exactly 4 elements.");
            }

            NinjaAcademy[] academy = [new Elementary(), new Intermediate(), 
                                    new Advanced(), new Legend()];

            for (int i = 0; i < lengths.Length; i++)
            {

                academy[i].createNinja(lengths[i], names[i]);
            }

            return academy;
        }
      
        static void Main() 
        {            
            int[] lengths1 = [2, 2, 2, 3];
            int[] lengths2 = [1, 1, 1, 1];
            string[][] names1 = [
                ["Naruto","Sasuke"],
                ["Shikamaru", "Choji"],
                ["Kakashi", "Guy"],
                ["Hashirama", "Tobirama", "Tsunade"]
            ];

            NinjaAcademy[] academy1 = CreateNinjaAcademy(lengths1, names1);
            
            foreach (NinjaAcademy a in academy1)
            {
                client(a);
            }

            Console.WriteLine("\n--- Testing with mismatched lengths ---\n");
            NinjaAcademy[] academy2 = CreateNinjaAcademy(lengths2, names1);
            try
            {
                foreach (NinjaAcademy a in academy2)
                {
                    client(a);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}