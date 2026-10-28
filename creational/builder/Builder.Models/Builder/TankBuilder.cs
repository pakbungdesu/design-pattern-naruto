using Builder.Models.Ninja;

namespace Builder.Models.Builder
{
    public class TankBuilder : NinjaBuilder
    {
        private TankNinja _tankNinja = null!;

        public TankBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            _tankNinja = new TankNinja();
        }

        public void buildNinjaRegNumber() { }
        public void buildBody() => _tankNinja.body = "Robust Heavy-Set Frame";
        public void buildSpecialEyes() => _tankNinja.specialEyes = "Standard Sensory Perception";
        public void buildShirt() => _tankNinja.shirt = "Dark Blue High-Collar Shinobi Shirt";
        public void buildTrouser() => _tankNinja.trouser = "Dark Blue Tactical Pants";
        public void buildHeadband() => _tankNinja.headband = "Konoha Forehead Protector";
        public void buildJacket(string qualityGrade) => _tankNinja.jacket = $"{qualityGrade} Konoha Flak Jacket";
        public void buildShoes() => _tankNinja.shoes = "Standard Shinobi Sandals";
        public void buildChakra(bool isElite, int level = 1)
        {
            if (isElite)
            {
                _tankNinja.chakra = 30000 * level;
            }
            else
            {
                _tankNinja.chakra = 3000 * level;
            }
        }
        public void buildAttackFactor(int level = 1) => _tankNinja.attackFactor = 95 * level;
        public void buildHealFactor(int level = 1) => _tankNinja.healFactor = 20 * level;
        public void buildBaseAttack(int level = 1) => _tankNinja.baseAttack = 100 * level;
        public void buildBaseHealPerMinute(int level = 1) => _tankNinja.baseHealPerMinute = 50 * level;
        public void buildIsDefeated() => _tankNinja.isDefeated = false;
        public void buildMask(){}
        public void buildCodeName(){}
        public void buildHealFactors(){}
        public void buildAttackFactors()
        {
            _tankNinja.attackFactors = new Dictionary<string, double>
            {
                { "Mud Wall", 2.2 },
                { "Rock Armor", 2.8 },
                { "Pillar Thrust", 2.5 },
            };
        }

        public TankNinja getResult()
        {
            return _tankNinja;
        }
    }
}