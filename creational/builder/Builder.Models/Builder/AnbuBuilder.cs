
using Builder.Models.Ninja;

namespace Builder.Models.Builder
{
    public class AnbuBuilder : NinjaBuilder
    {
        private Anbu _anbu {set; get;} = null!;

        public AnbuBuilder()
        {
            reset();
        }

        public void reset()
        {
            _anbu = new Anbu();
        }

        public void buildNinjaRegNumber() { }
        public void buildBody() => _anbu.body = "Agile Stealth Frame";
        public void buildSpecialEyes() => _anbu.specialEyes = "Night Vision Tracking";
        public void buildChainmailArmor() => _anbu.chainmailArmor = "Light Mesh Armor";
        public void buildShirt() => _anbu.shirt = "Dark Grey High-Neck Shirt";
        public void buildTrouser() => _anbu.trouser = "Black Tactical Pants";
        public void buildHeadband() => _anbu.headband = "Hidden Headband";
        public void buildGloves() => _anbu.gloves = "Arm-Guards with Metal Plating";
        public void buildBandage() => _anbu.bandage = "Tight Ankle and Wrist Wraps";
        public void buildJacket() => _anbu.jacket = "Grey Anbu Chest Vest";
        public void buildShoes() => _anbu.shoes = "Silent Black Boots";
        public void buildPocket() => _anbu.pocket = new List<string> { "Poison Tags", "Smoke Bombs", "Wire Strings" };
        public void buildCloak() => _anbu.cloak = "Black Hooded Cloak";
        public void buildKatana() => _anbu.katana = "Ninjato (Short Sword)";
        public void buildMask() => _anbu.mask = "Porcelain Fox Mask";
        public void buildChakraNature() => _anbu.chakraNature = "Lightning";

        public void buildAttackFactors()
        {
            _anbu.profile.attackFactors = new Dictionary<string, double>
            {
                { "Chidori", 2.8 },
                { "Silent Killing", 3.0 },
                { "Body Flicker", 2.5 }
            };
        }

        public void buildHealFactors(){}

        public Anbu getResult()
        {
            Anbu result = _anbu;
            reset();
            return result;
        }
    }
}