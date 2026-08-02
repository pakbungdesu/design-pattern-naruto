using Builder.Models.Builder;

namespace Builder.Models.Director
{
    public class Director
    {
        public void MakeBasicNinja(NinjaBuilder builder)
        {
            builder.reset();
            builder.buildNinjaRegNumber();
            builder.buildBody();
            builder.buildShirt();
            builder.buildTrouser();
            builder.buildShoes();
            builder.buildHeadband();
            builder.buildChakraNature();
        }

        public void MakeFullyEquippedNinja(NinjaBuilder builder)
        {
            builder.reset();
            builder.buildNinjaRegNumber();
            builder.buildBody();
            builder.buildShirt();
            builder.buildTrouser();
            builder.buildShoes();
            builder.buildHeadband();
            builder.buildJacket();
            builder.buildPocket();
            builder.buildKatana();
            builder.buildChakraNature();
            builder.buildAttackFactors();
            builder.buildHealFactors();
        }

        public void MakeEliteSpecialist(NinjaBuilder builder)
        {
            builder.reset();
            builder.buildNinjaRegNumber();
            builder.buildBody();
            builder.buildSpecialEyes();
            builder.buildChainmailArmor();
            builder.buildShirt();
            builder.buildTrouser();
            builder.buildJacket();
            builder.buildGloves();
            builder.buildCloak();
            builder.buildMask();
            builder.buildKatana();
            builder.buildPocket();
            builder.buildChakraNature();
            builder.buildAttackFactors();
            builder.buildHealFactors();
        }
    }
}