using Abstract.Factory.Models.Factory;

namespace Abstract.Factory.Models.Client
{
    public class Client(CombatFactory factory)
    {
        public CombatFactory factory {set; get;} = factory;
        public Weapon weapon {set; get;} = factory.createWeapon();

        public void attack()
        {
            weapon.attack();
        }
    }
}