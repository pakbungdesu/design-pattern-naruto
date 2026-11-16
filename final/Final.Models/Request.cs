
namespace Requests
{
    using Ninjas;
    using Enums;
    using Weapons;

    public abstract class RoleRequirement
    {
        public RoleDecorator Role { get; set; }
    }

    public class TankRequirement : RoleRequirement
    {
        public int Endurance { get; set; }
        public TankRequirement(int endurance) 
        { 
            Role = RoleDecorator.Tank; 
            Endurance = endurance; 
        }
    }

    public class AnbuRequirement : RoleRequirement
    {
        public float Speed { get; set; }
        public AnbuRequirement(float speed) 
        { 
            Role = RoleDecorator.Anbu; 
            Speed = speed; 
        }
    }

    public class MedicRequirement : RoleRequirement
    {
        public string MedicalRank { get; set; }
        public string HospitalCode { get; set; }
        public MedicRequirement(string medicalRank, string hospitalCode) 
        { 
            Role = RoleDecorator.Medic; 
            MedicalRank = medicalRank;
            HospitalCode = hospitalCode;
        }
    }

    public class NinjaRequirement
    {
        public NinjaBaseRank BaseRank { get; set; }
        public Location Village { get; set; }
        public string Name { get; set; }
        public ChakraType ChakraNature { get; set; }
        public int Attack { get; set; }
        public double Heal { get; set; }
        public int HP { get; set; }
        public int Stamina { get; set; }
        public string JutsuSpecialty { get; set; } = "Unknown";
        public double ElementBoost { get; set; }
        public int BijuuPool { get; set; }
        public List<RoleRequirement> Roles { get; set; } = new List<RoleRequirement>();

        public NinjaRequirement(NinjaBaseRank baseRank, Location village, string name, ChakraType chakraNature, int attack, double heal, int hp, List<RoleRequirement> roles)
        {
            BaseRank = baseRank;
            Village = village;
            Name = name;
            ChakraNature = chakraNature;
            Attack = attack;
            Heal = heal;
            HP = hp;
            Roles = roles ?? new List<RoleRequirement>();
        }
    }

    public class SquadRequirement
    {
        public string SquadName { get; set; } = "Anonymous Squad";
        public List<NinjaRequirement> RequiredNinjas { get; set; } = new List<NinjaRequirement>();
        public List<SquadRequirement> SubSquads { get; set; } = new List<SquadRequirement>();
    }

    public class ChakraRequirement
    {
        public double BurnChance { get; set; } = 25.0;
        public int CuttingPower { get; set; } = 15;
        public double FlowRate { get; set; } = 0.2;
        public int Hardness { get; set; } = 2;
        public double StunChance { get; set; } = 20.0;
    }

    public class WeaponRequirement
    {
        public int KatanaBaseDamage { get; set; } = 50;
        public int KatanaPenetration { get; set; } = 10;
        public int ShurikenBaseDamage { get; set; } = 5;
        public int ShurikenCount { get; set; } = 5;
        public int KunaiBaseDamage { get; set; } = 15;
        public double KunaiPiercingBonus { get; set; } = 0.25;
        public int KunaiCount { get; set; } = 5;
        public ChakraRequirement ChakraStats { get; set; } = new ChakraRequirement();
    }
    
    public class MissionRequest
    {
        public string MissionName { get; set; }
        public Rank MissionRank { get; set; }
        public Location Location { get; set; }
        public SquadRequirement KonohaBlueprint { get; set; }
        public SquadRequirement AllianceBlueprint { get; set; }
        public WeaponRequirement WeaponBlueprint { get; set; } 
        public MissionRequest(string missionName, Rank missionRank, Location loc, SquadRequirement konohaBlueprint, SquadRequirement allianceBlueprint, WeaponRequirement wr)
        {
            MissionName = missionName;
            MissionRank = missionRank;
            Location = loc;
            KonohaBlueprint = konohaBlueprint;
            AllianceBlueprint = allianceBlueprint;
            WeaponBlueprint = wr;
        }
    }
}