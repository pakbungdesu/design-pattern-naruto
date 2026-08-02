using System.Collections.Generic;
using Builder.Models.Ninja;

namespace Builder.Models.Builder
{
    public class MedicBuilder : NinjaBuilder
    {
        private MedicalNinja _medicalNinja = null!;

        public MedicBuilder()
        {
            reset();
        }

        public void reset()
        {
            _medicalNinja = new MedicalNinja();
        }

        public void buildNinjaRegNumber() { }
        public void buildBody() => _medicalNinja.body = "Standard Medical Frame";
        public void buildSpecialEyes() => _medicalNinja.specialEyes = "Chakra Diagnostic Vision";
        public void buildChainmailArmor() => _medicalNinja.chainmailArmor = "Thin Protective Lining";
        public void buildShirt() => _medicalNinja.shirt = "White Medical Top";
        public void buildTrouser() => _medicalNinja.trouser = "Dark Grey Pants";
        public void buildHeadband() => _medicalNinja.headband = "Konoha Forehead Protector";
        public void buildGloves() => _medicalNinja.gloves = "Sterile Chakra Gloves";
        public void buildBandage() => _medicalNinja.bandage = "Emergency Medical Gauze";
        public void buildJacket() => _medicalNinja.jacket = "Light Medical Apron";
        public void buildShoes() => _medicalNinja.shoes = "Standard Shinobi Sandals";
        public void buildPocket() => _medicalNinja.pocket = new List<string> { "Medical Scrolls", "Scalpel Set", "Antidote Vials" };
        public void buildCloak() => _medicalNinja.cloak = "White Medical Corps Cloak";
        public void buildKatana() => _medicalNinja.katana = "Chakra Scalpel Blade";
        public void buildChakraNature() => _medicalNinja.chakraNature = "Water";
        public void buildMask(){}

        public void buildHealFactors()
        {
            _medicalNinja.profile.healFactors = new Dictionary<string, double>
            {
                { "Mystical Palm Technique", 1.8 },
                { "Poison Extraction", 1.2 }
            };
        }

        public void buildAttackFactors()
        {
            _medicalNinja.profile.attackFactors = new Dictionary<string, double>
            {
                { "Chakra Scalpel Slash", 1.5 },
                { "Cherry Blossom Impact", 2.2 }
            };
        }

        public MedicalNinja getResult()
        {
            MedicalNinja result = _medicalNinja;
            reset();
            return result;
        }
    }
}