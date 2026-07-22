using System;
using Factory.Method.Models;

namespace Factory.Method.Application
{
    class Program
    {
        static Ninja[] client(NinjaAcademy academy, int lengths)
        {

            Ninja[] ninjas = new Ninja[lengths];
            
            for (int i = 0; i < lengths; i++)
            {
                ninjas[i] = academy.createNinja();
            }

            return ninjas;
        }

      
        static void Main() 
        {            
            
        NinjaAcademy academy = new Elementary();
        Ninja ninja = academy.createNinja(); 
        academy.train(ninja);

        academy = new Intermediate();
        ninja = academy.createNinja();
        academy.train(ninja);

        academy = new Advanced();
        ninja = academy.createNinja();
        academy.train(ninja);

        Console.WriteLine("Create many ninjas");
        Ninja[] ninjas = client(academy, 3);
        foreach(Ninja n in ninjas){
            academy.train(n);
        }

        }
    }
}