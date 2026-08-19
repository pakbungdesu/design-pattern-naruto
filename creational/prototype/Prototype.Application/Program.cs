using Prototype.Models.Ninjas;
using Prototype.Models.Jutsus;

namespace Prototype.Application
{
    public class Program
    {
        public static void client()
        {
            Lightning chidori = new Lightning("Chidori", 1.5, 200, 0.9);
            Fire fireball = new Fire("Fireball Jutsu", 2.0, 300, 50, 3);
            Water waterBlast = new Water("Water Blast", 1.8, 250, 0.5);
            Earth mudWall = new Earth("Mud Wall", 1.2, 150, 0.4);
            Wind rasengan = new Wind("Rasengan", 2.2, 350, 0.4);

            Ninja kakashi = new Ninja("Kakashi", new List<Jutsu> { chidori, fireball, waterBlast, mudWall}, baseAttack: 150, chakra: 12000, shield: 8000);
            Ninja sasuke = new Ninja("Sasuke", new List<Jutsu>(), baseAttack: 140, chakra: 10000, shield: 5000);
            Ninja itachi = new Ninja("Itachi", new List<Jutsu>(), baseAttack: 160, chakra: 11000, shield: 6000);
            Ninja naruto = new Ninja("Naruto", new List<Jutsu> { rasengan }, baseAttack: 140, chakra: 10000, shield: 5000);

            Console.WriteLine("--- Initial States ---");
            kakashi.displayInfo();
            Console.WriteLine();
            sasuke.displayInfo();
            Console.WriteLine();
            itachi.displayInfo();
            Console.WriteLine();
            naruto.displayInfo();
            Console.WriteLine();

            //  Copy skill from Kakashi to Sasuke
            Console.WriteLine("--- Prototype Cloning Action ---");
            sasuke.copyOtherSkill(kakashi, 1);
            itachi.copyOtherSkills(kakashi);
            Console.WriteLine();
    
            Console.WriteLine("--- Jutsu Execution ---");
            sasuke.useJutsu(0, kakashi);
            itachi.useJutsu(2, kakashi);
            naruto.useJutsu(0, sasuke);
            kakashi.useJutsu(0, itachi);

            if(itachi.isStunned)
            {
                Console.WriteLine($"⚡ {itachi.name} is stunned and cannot move!");
            }
            else
            {
                itachi.useJutsu(0, naruto);
            }

            kakashi.useJutsu(2, sasuke);
            Console.WriteLine();

            Console.WriteLine("--- Final States ---");
            kakashi.displayInfo();
            Console.WriteLine();
            sasuke.displayInfo();
            Console.WriteLine();
            itachi.displayInfo();
            Console.WriteLine();
            naruto.displayInfo();
        }

        public static void Main(string[] args)
        {
            client();

            Lightning chidori = new Lightning("Chidori", 1.5, 200, 0.9);

            // {}

            List<Lightning> jutsus = new List<Lightning>();

            for (int i = 0; i < 10; i++)
            {
                jutsus.Add((Lightning)chidori.clone());
            }

            for (int i = 0; i < jutsus.Count; i++)
            {
                Console.WriteLine(jutsus[i].jutsuName);
            }
        }
    }
}