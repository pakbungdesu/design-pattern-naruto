public interface NinjaBuilder
{
    void reset();
    void buildNinjaRegNumber();
    void buildBody();
    void buildShirt();
    void buildTrouser();
    void buildHeadband();
    void buildJacket(string qualityGrade);
    void buildShoes();
    void buildChakra(bool isElite, int level = 1);
    void buildAttackFactor(int level = 1);
    void buildHealFactor(int level = 1);
    void buildBaseAttack(int level = 1);
    void buildBaseHealPerMinute(int level = 1);
    void buildIsDefeated();
    void buildAttackFactors();

    // Specialty methods (No-ops in implementations that don't use them)
    void buildMask();
    void buildCodeName();
    void buildSpecialEyes();
    void buildHealFactors();
}