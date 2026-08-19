
using Builder.Models.Ninja;

namespace Builder.Models.Builder
{
    public class AnbuBuilder : NinjaBuilder
    {
        private Anbu _anbu {set; get;} = null!;
        
        public AnbuBuilder(){
            this.reset();
        }

        public void reset()
        {
            _anbu = new Anbu();
        }

        public void buildNinjaRegNumber() { }
        public void buildBody() => _anbu.body = "Agile Stealth Frame";
        public void buildSpecialEyes() => _anbu.specialEyes = "Night Vision Tracking";
        public void buildShirt() => _anbu.shirt = "Dark Grey High-Neck Shirt";
        public void buildTrouser() => _anbu.trouser = "Black Tactical Pants";
        public void buildHeadband() => _anbu.headband = "Hidden Headband";
        public void buildJacket(string qualityGrade) => _anbu.jacket = qualityGrade;
        public void buildShoes() => _anbu.shoes = "Silent Black Boots";
        public void buildMask() => _anbu.mask = "Porcelain Fox Mask";
        public void buildCodeName() => _anbu.codeName = "Shadow Phantom";
        public void buildChakra(bool isElite, int level = 1){
            if (isElite)
            {
                _anbu.chakra = 30000 * level;
            }
            else
            {
                _anbu.chakra = 3000 * level;
            }
        }
        public void buildAttackFactor(int level = 1) => _anbu.attackFactor = 85 * level;
        public void buildHealFactor(int level = 1) => _anbu.healFactor = 20 * level;
        public void buildBaseAttack(int level = 1) => _anbu.baseAttack = 100 * level;
        public void buildBaseHealPerMinute(int level = 1) => _anbu.baseHealPerMinute = 50 * level;
        public void buildIsDefeated() => _anbu.isDefeated = false;

        public void buildAttackFactors()
        {
            _anbu.attackFactors = new Dictionary<string, double>
            {
                { "Chidori", 2.8 },
                { "Silent Killing", 3.0 },
                { "Body Flicker", 2.5 }
            };
        }

        public void buildHealFactors(){}

        public Anbu getResult()
        {
            return _anbu;
        }
    }
}