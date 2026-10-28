using Abstract.Factory.Models;
using Abstract.Factory.Models.Factory;
using Abstract.Factory.Models.Client;
namespace Abstract.Factory.Application
{
    class Program
    {
        static void client(CombatFactory factory)
        {
            Weapon weapon = factory.createWeapon();
            Defense defense = factory.createDefense();
            Uniform uniform = factory.createUniform();

            weapon.attack();
            defense.block();
            uniform.wear();
            Console.WriteLine("");
        }

        static void Main()
        {
            CombatFactory factory = new KonohaFactory();
            client(factory);

            factory = new KirigakureFactory();
            client(factory);

            Weapon weapon = factory.createWeapon();
            Defense defense = factory.createDefense();
            Uniform uniform = factory.createUniform();

            weapon.attack();
            defense.block();
            uniform.wear();

            factory = new AkatsukiFactory();

            Client wp = new Client(factory);
            wp.attack();

            factory = new SunaFactory();
            wp.factory = factory;
            wp.attack();
        }
    }
}