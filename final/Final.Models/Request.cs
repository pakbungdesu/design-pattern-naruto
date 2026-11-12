
namespace Requests
{
    using Ninjas;
    using Enums;
    using System.Collections.Generic;

    public abstract class RoleRequirement
    {
        public RoleDecorator Role { get; set; }
    }

    public class TankRequirement : RoleRequirement
    {
        public float Endurance { get; set; }
        public TankRequirement(float endurance) 
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

    public class MissionRequest
    {
        public string MissionName { get; set; }
        public Rank MissionRank { get; set; }
        public Location Location { get; set; }
        public SquadRequirement SquadBlueprint { get; set; }
        public Squad? DeployedSquad { get; set; }
        
        public MissionRequest(string missionName, Rank missionRank, Location loc, SquadRequirement sr) 
        {
            MissionName = missionName;
            MissionRank = missionRank;
            Location = loc;
            SquadBlueprint = sr;
        }
    }
}