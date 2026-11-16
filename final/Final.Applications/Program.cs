
using Handlers;
using Requests;
using Enums;
using Ninjas;
using Weapons;

class Program
{
    static void Main()
    {
        // 1. Setup the Chain of Responsibility
        KonohaRecruitHandler konohaHandler = new KonohaRecruitHandler();
        AllianceRecruitHandler allianceHandler = new AllianceRecruitHandler();
        WeaponHandler weaponHandler = new WeaponHandler();
        DispatchHandler dispatchHandler = new DispatchHandler();

        // Link the chain: Konoha -> Alliance -> Weapon -> Dispatch
        konohaHandler.SetNext(allianceHandler);
        allianceHandler.SetNext(weaponHandler);
        weaponHandler.SetNext(dispatchHandler);

        // 2. Create the standard weapon blueprint
        WeaponRequirement standardWeapons = new WeaponRequirement
        {
            KatanaBaseDamage = 60,
            ShurikenCount = 10,
            KunaiCount = 3
        };

        Console.WriteLine("==================================================");
        Console.WriteLine(" SCENARIO 1: JOINT COMBAT MISSION (Konoha + Suna) ");
        Console.WriteLine("==================================================\n");

        // Blueprint for Konoha Squad
        SquadRequirement team7 = new SquadRequirement
        {
            SquadName = "Team 7 Extraction Unit",
            RequiredNinjas = new List<NinjaRequirement>
            {
                new NinjaRequirement(NinjaBaseRank.Jonin, Location.Konohagakure, "Kakashi", ChakraType.Lightning, 120, 10, 1500, new List<RoleRequirement>())
                {
                    JutsuSpecialty = "Raikiri",
                    ElementBoost = 1.5
                },
                new NinjaRequirement(NinjaBaseRank.Chunin, Location.Konohagakure, "Sakura", ChakraType.Earth, 90, 300, 1000, new List<RoleRequirement> 
                { 
                    new MedicRequirement("Head Medic", "KNH-MED-01") 
                })
                {
                    Stamina = 500
                }
            }
        };

        // Blueprint for Alliance (Suna) Squad
        SquadRequirement sandSiblings = new SquadRequirement
        {
            SquadName = "Sand Siblings Backup",
            RequiredNinjas = new List<NinjaRequirement>
            {
                new NinjaRequirement(NinjaBaseRank.Kage, Location.Sunagakure, "Gaara", ChakraType.Wind, 150, 50, 3000, new List<RoleRequirement>
                {
                    new TankRequirement(200f)
                })
                {
                    BijuuPool = 5000
                }
            }
        };

        // Create the joint mission request
        MissionRequest jointMission = new MissionRequest(
            missionName: "Rescue Kazekage",
            missionRank: Rank.S,
            loc: Location.Sunagakure,
            wr: standardWeapons,
            requestedWeaponKits: 0, // No extra standalone weapons needed
            konohaBlueprint: team7,
            allianceBlueprint: sandSiblings
        );

        // Execute Scenario 1
        konohaHandler.HandleRequest(jointMission);


        Console.WriteLine("\n\n==================================================");
        Console.WriteLine(" SCENARIO 2: WEAPONS SUPPLY RUN (No Squads)       ");
        Console.WriteLine("==================================================\n");

        // Create a logistics mission requesting exactly 50 kits, with NO squad blueprints
        MissionRequest supplyRun = new MissionRequest(
            missionName: "Restock Northern Border",
            missionRank: Rank.B,
            loc: Location.Kumogakure,
            wr: standardWeapons,
            requestedWeaponKits: 50, // Pure logistics order
            konohaBlueprint: null,   // Skips KonohaRecruitHandler
            allianceBlueprint: null  // Skips AllianceRecruitHandler
        );

        konohaHandler.HandleRequest(supplyRun);


        Console.WriteLine("\n\n==================================================");
        Console.WriteLine(" SCENARIO 3: KONOHA ONLY MISSION                  ");
        Console.WriteLine("==================================================\n");

        SquadRequirement anbuSquad = new SquadRequirement
        {
            SquadName = "Anbu Black Ops Team Alpha",
            RequiredNinjas = new List<NinjaRequirement>
            {
                new NinjaRequirement(NinjaBaseRank.Jonin, Location.Konohagakure, "Yamato", ChakraType.Water, 110, 20, 1200, new List<RoleRequirement>
                {
                    new AnbuRequirement(300f)
                })
                {
                    JutsuSpecialty = "Wood Release"
                }
            }
        };

        MissionRequest stealthMission = new MissionRequest(
            missionName: "Infiltrate Orochimaru's Hideout",
            missionRank: Rank.A,
            loc: Location.Iwagakure,
            wr: standardWeapons,
            requestedWeaponKits: 0,
            konohaBlueprint: anbuSquad,
            allianceBlueprint: null
        );

        // Execute Scenario 3
        konohaHandler.HandleRequest(stealthMission);
    }
}