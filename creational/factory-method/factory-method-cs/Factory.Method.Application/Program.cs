using System;
using Factory.Method.Models;

namespace Factory.Method.Application
{
    class Program
    {
        static NinjaAcademy[] client(NinjaAcademy[] academy, int[] lengths, string[][] names)
        {
            if (academy.Length != lengths.Length || lengths.Length != names.Length)
            {
                throw new ArgumentException("Academy, lengths, and names arrays must have the same length.");
            }

            for (int i = 0; i < academy.Length; i++)
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

            try
            {
                NinjaAcademy[] academy1 = client(new NinjaAcademy[] { new Elementary(), new Intermediate(), 
            new Advanced(), new Legend() }, lengths1, names1);

                foreach (NinjaAcademy a in academy1)
                {
                    a.train();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            
            try
            {
                Console.WriteLine("\n--- Testing with mismatched lengths ---\n");

                NinjaAcademy[] academy2 = client(new NinjaAcademy[] { new Elementary(), new Intermediate(), 
            new Advanced(), new Legend() }, lengths2, names1);

                foreach (NinjaAcademy a in academy2)
                {
                    a.train();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            int[] lengths3 = [1, 1, 1];
            string[][] names2 = [
                ["Naruto"],
                ["Shikamaru"],
                ["Kakashi"]
            ];

            try
            {
                Console.WriteLine("\n--- Testing with fewer lengths and names ---\n");

                NinjaAcademy[] academy3 = client(new NinjaAcademy[] { new Elementary(), new Intermediate(), 
            new Advanced()}, lengths3, names2);

                foreach (NinjaAcademy a in academy3)
                {
                    a.train();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- Testing with creating schools manually ---\n");

            List<NinjaAcademy> academies = new List<NinjaAcademy>();

            NinjaAcademy academy4 = new Elementary();
            academy4.createNinja(3);
            academies.Add(academy4);

            academy4 = new Intermediate();
            academy4.createNinja(3);
            academies.Add(academy4);

            academy4 = new Advanced();
            academy4.createNinja(3);
            academies.Add(academy4);

            academy4 = new Legend();
            academy4.createNinja(3);
            academies.Add(academy4);

            foreach(NinjaAcademy a in academies)
            {
                a.train();
            }

        }
    }
}