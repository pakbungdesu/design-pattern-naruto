using System;
using System.Collections.Generic;
using Facades;
using Requests;
using VillageFactories;
using Ninjas;
using Enums;

class Program
{
    static void Main()
    {
        // 1. Configure Weapon & Chakra Blueprints
        var weaponBlueprint = new WeaponRequirement
        {
            KatanaBaseDamage = 65,
            KatanaPenetration = 15,
            ShurikenCount = 5,
            KunaiCount = 3,
            ChakraStats = new ChakraRequirement
            {
                CuttingPower = 25,
                BurnChance = 35.0
            }
        };

        // 2. Build Konoha Squad Blueprint (with a nested Sub-Squad)
        var konohaBlueprint = new SquadRequirement
        {
            SquadName = "Konoha Vanguard",
            RequiredNinjas = new List<NinjaRequirement>
            {
                new NinjaRequirement(
                    NinjaBaseRank.Jonin,
                    Location.Konohagakure,
                    "Kakashi Hatake",
                    ChakraType.Lightning,
                    attack: 120,
                    heal: 15,
                    hp: 1500,
                    roles: new List<RoleRequirement> { 
                        new AnbuRequirement(280f),
                        new TankRequirement(200) }
                )
                {
                    JutsuSpecialty = "Raikiri",
                    ElementBoost = 0.8
                },
                new NinjaRequirement(
                    NinjaBaseRank.Chunin,
                    Location.Konohagakure,
                    "Sakura Haruno",
                    ChakraType.Earth,
                    attack: 85,
                    heal: 40,
                    hp: 1100,
                    roles: new List<RoleRequirement>
                    {
                        new MedicRequirement("KNH-MED-01"),
                        new TankRequirement(100)
                    }
                )
                {
                    Stamina = 400
                }
            },
            SubSquads = new List<SquadRequirement>
            {
                new SquadRequirement
                {
                    SquadName = "Shadow Recon Sub-Squad",
                    RequiredNinjas = new List<NinjaRequirement>
                    {
                        new NinjaRequirement(
                            NinjaBaseRank.Chunin,
                            Location.Konohagakure,
                            "Shikamaru Nara",
                            ChakraType.Fire,
                            attack: 70,
                            heal: 10,
                            hp: 950,
                            roles: new List<RoleRequirement>()
                        )
                        {
                            Stamina = 350
                        },
                        new NinjaRequirement(
                            NinjaBaseRank.Chunin,
                            Location.Konohagakure,
                            "Akemichi Joji",
                            ChakraType.Earth,
                            attack: 100,
                            heal: 10,
                            hp: 950,
                            roles: new List<RoleRequirement>{
                                new TankRequirement(100)
                            }
                        )
                    }
                }
            }
        };

        // 3. Build Alliance Squad Blueprint
        var allianceBlueprint = new SquadRequirement
        {
            SquadName = "Suna Reinforcement Unit",
            RequiredNinjas = new List<NinjaRequirement>
            {
                new NinjaRequirement(
                    NinjaBaseRank.Kage,
                    Location.Sunagakure,
                    "Gaara",
                    ChakraType.Wind,
                    attack: 140,
                    heal: 20,
                    hp: 2500,
                    roles: new List<RoleRequirement> { new TankRequirement(250) }
                )
                {
                    BijuuPool = 1200
                }
            }
        };

        // 4. Create Request & Dispatch via Facade
        var missionRequest = new MissionRequest(
            missionName: "Sand Border Defense",
            missionRank: Rank.S,
            loc: Location.Sunagakure,
            wr: weaponBlueprint,
            konohaBlueprint: konohaBlueprint,
            allianceBlueprint: allianceBlueprint
        );

        var facade = new KonohaFacade(missionRequest);
        var (konohaTeam, allianceTeam) = facade.Dispatch();

        // Display deployed rosters
        konohaTeam?.Display();
        Console.WriteLine();
        allianceTeam?.Display();

        // 5. Mockup Rogue Enemies using Abstract Village Factories
        // VillageFactory kiriFactory = new KiriFactory();
        // VillageFactory iwaFactory = new IwaFactory();

        // Ninja rogueSwordsman = kiriFactory.CreateJonin(
        //     name: "Zabuza (Rogue)",
        //     chakraNature: ChakraType.Water,
        //     attack: 160,
        //     heal: 0,
        //     hp: 4500,
        //     jutsuSpecialty: "Hidden Mist Jutsu",
        //     elementBoost: 0.9
        // );

        // Ninja rogueCommander = iwaFactory.CreateKage(
        //     name: "Rogue Tsuchikage",
        //     chakraNature: ChakraType.Earth,
        //     attack: 200,
        //     heal: 0,
        //     hp: 8000,
        //     bijuuPool: 1500
        // );

        // // 6. Combat Simulation
        // Console.WriteLine("\n================ BATTLE START ================");

        // // Composite Squad Attack: Entire Konoha tree (including Sub-Squad) attacks Zabuza
        // Console.WriteLine($"\n--- {konohaTeam?.SquadName} engages {rogueSwordsman.Name} (HP: {rogueSwordsman.HP}) ---");
        // konohaTeam?.AttackTarget(rogueSwordsman);
        // Console.WriteLine($"Result -> {rogueSwordsman.Name} Remaining HP: {Math.Max(0, rogueSwordsman.HP)}");

        // // Alliance Squad Attack: Gaara engages Rogue Tsuchikage
        // Console.WriteLine($"\n--- {allianceTeam?.SquadName} engages {rogueCommander.Name} (HP: {rogueCommander.HP}) ---");
        // allianceTeam?.AttackTarget(rogueCommander);
        // Console.WriteLine($"Result -> {rogueCommander.Name} Remaining HP: {Math.Max(0, rogueCommander.HP)}");

        // // Enemy Counter-Attack against a target inside the squad
        // if (konohaTeam != null && konohaTeam.Members.Count > 0 && konohaTeam.Members[0] is Ninja vanguardLead)
        // {
        //     Console.WriteLine($"\n--- Enemy Counter-Attack ---");
        //     rogueCommander.AttackTarget(vanguardLead);
        //     Console.WriteLine($"Result -> {vanguardLead.Name} Remaining HP: {Math.Max(0, vanguardLead.HP)}");
        // }

        // Console.WriteLine("\n================ BATTLE END ================");
    }
}