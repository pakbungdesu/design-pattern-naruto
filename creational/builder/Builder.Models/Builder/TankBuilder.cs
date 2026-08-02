using Builder.Models.Ninja;

namespace Builder.Models.Builder
{
    public class TankBuilder : NinjaBuilder
    {
        private TankNinja _tankNinja = null!;

        public TankBuilder()
        {
            reset();
        }

        public void reset()
        {
            _tankNinja = new TankNinja();
        }

        public void buildNinjaRegNumber() { }
        public void buildBody() => _tankNinja.body = "Robust Heavy-Set Frame";
        public void buildSpecialEyes() => _tankNinja.specialEyes = "Standard Sensory Perception";
        public void buildChainmailArmor() => _tankNinja.chainmailArmor = "Full Torso Chainmail Mesh";
        public void buildShirt() => _tankNinja.shirt = "Dark Blue High-Collar Shinobi Shirt";
        public void buildTrouser() => _tankNinja.trouser = "Dark Blue Tactical Pants";
        public void buildHeadband() => _tankNinja.headband = "Konoha Forehead Protector";
        public void buildGloves() => _tankNinja.gloves = "Metal-Plated Shinobi Gauntlets";
        public void buildBandage() => _tankNinja.bandage = "Reinforced Forearm and Shin Wraps";
        public void buildJacket() => _tankNinja.jacket = "Standard Green Konoha Flak Jacket";
        public void buildShoes() => _tankNinja.shoes = "Standard Shinobi Sandals";
        public void buildPocket() => _tankNinja.pocket = new List<string> { "Explosive Tags", "Iron Defense Seals", "Ration Pills", "Kunai Set" };
        public void buildCloak() => _tankNinja.cloak = "Heavy Frontline Vanguard Cloak";
        public void buildKatana() => _tankNinja.katana = "Standard Issue Shinobi Blade";
        public void buildMask(){}
        public void buildChakraNature() => _tankNinja.chakraNature = "Earth";

        public void buildAttackFactors()
        {
            _tankNinja.profile.attackFactors = new Dictionary<string, double>
            {
                { "Mud Wall", 2.2 },
                { "Rock Armor", 2.8 },
                { "Pillar Thrust", 2.5 },
            };
        }

        public void buildHealFactors(){}

        public TankNinja getResult()
        {
            TankNinja result = _tankNinja;
            reset();
            return result;
        }
    }
}