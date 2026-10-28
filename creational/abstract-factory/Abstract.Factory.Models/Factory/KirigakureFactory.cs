using Abstract.Factory.Models.Kirigakure;

namespace Abstract.Factory.Models.Factory
{
    public class KirigakureFactory : CombatFactory
    {
        public Weapon createWeapon()
        {
            return new StandardKatana();
        }

        public Defense createDefense()
        {
            return new HiddenMistJutsu();
        }

        public Uniform createUniform()
        {
            return new StripedMistWarmer();
        }
    }
}