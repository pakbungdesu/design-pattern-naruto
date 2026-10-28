using Abstract.Factory.Models.Suna;

namespace Abstract.Factory.Models.Factory
{
    public class SunaFactory : CombatFactory
    {
        public Weapon createWeapon()
        {
            return new GiantFoldingFan();
        }

        public Defense createDefense()
        {
            return new WindWallJutsu();
        }

        public Uniform createUniform()
        {
            return new SandDesertCloak();
        }
    }
}