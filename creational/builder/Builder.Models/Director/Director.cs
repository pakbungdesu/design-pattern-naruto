namespace Builder.Models.Director
{
    public class Director
    {
        public void MakeStandardJonin(NinjaBuilder builder)
        {
            builder.reset();
            builder.buildNinjaRegNumber();
            builder.buildBody();
            builder.buildShirt();
            builder.buildTrouser();
            builder.buildHeadband();
            builder.buildJacket("Standard");
            builder.buildShoes();
            builder.buildMask();
            builder.buildCodeName();
            builder.buildChakra(isElite: false, level: 1);
            builder.buildAttackFactor(level: 1);
            builder.buildAttackFactors();
            builder.buildHealFactor(level: 1);
            builder.buildHealFactors();
            builder.buildBaseAttack(level: 1);
            builder.buildBaseHealPerMinute(level: 1);
            builder.buildIsDefeated();
        }

        public void MakePremiumJonin(NinjaBuilder builder)
        {
            builder.reset();
            builder.buildNinjaRegNumber();
            builder.buildBody();
            builder.buildShirt();
            builder.buildTrouser();
            builder.buildHeadband();
            builder.buildJacket("Premium");
            builder.buildShoes();
            builder.buildMask();
            builder.buildCodeName();
            builder.buildChakra(isElite: false, level: 2);
            builder.buildAttackFactor(level: 2);
            builder.buildAttackFactors();
            builder.buildHealFactor(level: 2);
            builder.buildHealFactors();
            builder.buildBaseAttack(level: 2);
            builder.buildBaseHealPerMinute(level: 2);
            builder.buildIsDefeated();
        }

        public void MakeEliteSpecialist(NinjaBuilder builder)
        {
            builder.reset();
            builder.buildNinjaRegNumber();
            builder.buildBody();
            builder.buildShirt();
            builder.buildTrouser();
            builder.buildHeadband();
            builder.buildJacket("Elite");
            builder.buildShoes();
            builder.buildMask();
            builder.buildCodeName();
            builder.buildSpecialEyes();
            builder.buildChakra(isElite: true, level: 3);
            builder.buildAttackFactor(level: 3);
            builder.buildAttackFactors();
            builder.buildHealFactor(level: 3);
            builder.buildHealFactors();
            builder.buildBaseAttack(level: 3);
            builder.buildBaseHealPerMinute(level: 3);
            builder.buildIsDefeated();
        }
    }
}