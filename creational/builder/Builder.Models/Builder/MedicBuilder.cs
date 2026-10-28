using Builder.Models.Ninja;

namespace Builder.Models.Builder
{
    public class MedicBuilder : NinjaBuilder
    {
        private MedicalNinja _medicalNinja = null!;

        public MedicBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            _medicalNinja = new MedicalNinja();
        }

        public void buildNinjaRegNumber() { }
        public void buildBody() => _medicalNinja.body = "Standard Medical Frame";
        public void buildShirt() => _medicalNinja.shirt = "White Medical Top";
        public void buildTrouser() => _medicalNinja.trouser = "Dark Grey Pants";
        public void buildHeadband() => _medicalNinja.headband = "Konoha Forehead Protector";
        public void buildJacket(string qualityGrade) => _medicalNinja.jacket = qualityGrade;
        public void buildShoes() => _medicalNinja.shoes = "Standard Shinobi Sandals";
        public void buildMask(){}
        public void buildCodeName(){}
        public void buildSpecialEyes(){}
        public void buildChakra(bool isElite, int level = 1 )
        {
            if (isElite)
            {
                _medicalNinja.chakra = 50000 * level;
            }
            else
            {
                _medicalNinja.chakra = 5000 * level;
            }
        }
        public void buildAttackFactor(int level = 1) => _medicalNinja.attackFactor = 50 * level;
        public void buildHealFactor(int level = 1) => _medicalNinja.healFactor = 50 * level;
        public void buildBaseAttack(int level = 1) => _medicalNinja.baseAttack = 75 * level;
        public void buildBaseHealPerMinute(int level = 1) => _medicalNinja.baseHealPerMinute = 75 * level;
        public void buildIsDefeated() => _medicalNinja.isDefeated = false;

        public void buildHealFactors()
        {
            _medicalNinja.healFactors = new Dictionary<string, double>
            {
                { "Mystical Palm Technique", 1.8 },
                { "Poison Extraction", 1.2 }
            };
        }

        public void buildAttackFactors()
        {
            _medicalNinja.attackFactors = new Dictionary<string, double>
            {
                { "Chakra Scalpel Slash", 1.5 },
                { "Cherry Blossom Impact", 2.2 }
            };
        }

        public MedicalNinja getResult()
        {
            return _medicalNinja;
        }
    }
}