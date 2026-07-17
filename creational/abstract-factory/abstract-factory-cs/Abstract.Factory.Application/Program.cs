using Abstract.Factory.Models;
using Abstract.Factory.Models.Factory;

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
        }

        static void Main()
        {
            CombatFactory factory = new KonohaFactory();
            client(factory);

            factory = new KirigakureFactory();
            client(factory);

            factory = new SunaFactory();
            client(factory);

            factory = new AkatsukiFactory();
            client(factory);
        }
    }
}