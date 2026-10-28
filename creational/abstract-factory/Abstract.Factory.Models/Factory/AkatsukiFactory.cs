using Abstract.Factory.Models.Akatsuki;

namespace Abstract.Factory.Models.Factory
{
    public class AkatsukiFactory: CombatFactory
    {
        public Weapon createWeapon()
        {
            return new ChakraAuraKunai();
        }

        public Defense createDefense()
        {
            return new AstralProjectionJutsu();
        }

        public Uniform createUniform()
        {
            return new BlackRedCloudCloak();
        }
    }
}