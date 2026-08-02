using Abstract.Factory.Models.Konoha;

namespace Abstract.Factory.Models.Factory
{
    public class KonohaFactory : CombatFactory
    {
        public Weapon createWeapon()
        {
            return new StandardKunai();
        }

        public Defense createDefense()
        {
            return new SubstitutionJutsu();
        }

        public Uniform createUniform()
        {
            return new GreenJacket();
        }
    }
}