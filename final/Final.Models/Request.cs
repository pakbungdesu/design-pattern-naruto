
namespace Requests
{
    using Ninjas;
    using Enums;

    public class NinjaRequirement
    {
        public NinjaBaseRank BaseRank { get; set; }
        public Location Village { get; set; }
        public List<RoleDecorator> Roles { get; set; } = new List<RoleDecorator>();
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
        public Squad DeployedSquad { get; set; }
        
        public MissionRequest(string missionName, Rank missionRank, Location loc, SquadRequirement sr) 
        {
            MissionName = missionName;
            MissionRank = missionRank;
            Location = loc;
            SquadBlueprint = sr;
        }
    }
}