namespace Abstract.Factory.Models.Factory
{
    public interface CombatFactory
    {
        public Weapon createWeapon();
        public Defense createDefense();

        public Uniform createUniform();
    }
}