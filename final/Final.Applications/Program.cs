using System;
using System.Collections.Generic;
using Facades;
using Requests;
using VillageFactories;
using Ninjas;
using Enums;

class Program
{
    static void Client(int idx, Decorator attacker, Decorator target)
    {
        Console.WriteLine("=== Before Attacking ===");
        target.Display();
        attacker.UseEquippedWeapons(idx, target);
        Console.WriteLine("=== After Attacking ===");
        target.Display();
    }

    static void Client(Decorator attacker, Decorator target)
    {
        Console.WriteLine("=== Before Attacking ===");
        target.Display();
        attacker.UseEquippedWeapons(target);
        Console.WriteLine("=== After Attacking ===");
        target.Display();
    }

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
                CuttingPower = 25
            }
        };

        // 2. Build Konoha Squad Blueprint (3-Level Nested Composite)
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
                // Level 2: Sub-Squad inside Konoha Vanguard
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
                            "Akimichi Choji",
                            ChakraType.Earth,
                            attack: 100,
                            heal: 10,
                            hp: 950,
                            roles: new List<RoleRequirement>{
                                new TankRequirement(100)
                            }
                        )
                        {
                            Stamina = 300
                        }
                    },
                    SubSquads = new List<SquadRequirement>
                    {
                        new SquadRequirement
                        {
                            SquadName = "Infiltration Micro-Cell",
                            RequiredNinjas = new List<NinjaRequirement>
                            {
                                new NinjaRequirement(
                                    NinjaBaseRank.Chunin,
                                    Location.Konohagakure,
                                    "Yamanaka Ino",
                                    ChakraType.Water,
                                    attack: 65,
                                    heal: 25,
                                    hp: 850,
                                    roles: new List<RoleRequirement>
                                    {
                                        new MedicRequirement("KNH-MED-02")
                                    }
                                )
                                {
                                    Stamina = 250
                                },
                                new NinjaRequirement(
                                    NinjaBaseRank.Chunin,
                                    Location.Konohagakure,
                                    "Hyuga Hinata",
                                    ChakraType.Lightning,
                                    attack: 80,
                                    heal: 15,
                                    hp: 900,
                                    roles: new List<RoleRequirement>
                                    {
                                        new AnbuRequirement(260f)
                                    }
                                )
                                {
                                    Stamina = 320
                                }
                            }
                        }
                    }
                }
            }
        };

        // 3. Build Alliance Squad Blueprint
        var allianceBlueprint = new SquadRequirement
        {
            SquadName = "Shinobi Alliance Joint Force",
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
            },
            SubSquads = new List<SquadRequirement>
            {
                // Level 2: Sand Siblings Sub-Squad (Sunagakure)
                new SquadRequirement
                {
                    SquadName = "Sand Siblings Vanguard",
                    RequiredNinjas = new List<NinjaRequirement>
                    {
                        new NinjaRequirement(
                            NinjaBaseRank.Jonin,
                            Location.Sunagakure,
                            "Temari",
                            ChakraType.Wind,
                            attack: 115,
                            heal: 10,
                            hp: 1300,
                            roles: new List<RoleRequirement>()
                        )
                        {
                            JutsuSpecialty = "Great Sickle Weasel",
                            ElementBoost = 0.85
                        },
                        new NinjaRequirement(
                            NinjaBaseRank.Jonin,
                            Location.Sunagakure,
                            "Kankuro",
                            ChakraType.Lightning,
                            attack: 105,
                            heal: 10,
                            hp: 1250,
                            roles: new List<RoleRequirement> { new AnbuRequirement(240f) }
                        )
                        {
                            JutsuSpecialty = "Black Secret Technique",
                            ElementBoost = 0.6
                        }
                    },
                    SubSquads = new List<SquadRequirement>
                    {
                        // Level 3: Cross-Village Support Micro-Cell (Kumogakure & Kirigakure)
                        new SquadRequirement
                        {
                            SquadName = "Kumo-Kiri Assault Unit",
                            RequiredNinjas = new List<NinjaRequirement>
                            {
                                new NinjaRequirement(
                                    NinjaBaseRank.Jonin,
                                    Location.Kumogakure,
                                    "Darui",
                                    ChakraType.Lightning,
                                    attack: 130,
                                    heal: 15,
                                    hp: 1450,
                                    roles: new List<RoleRequirement>
                                    {
                                        new AnbuRequirement(270f),
                                        new TankRequirement(150)
                                    }
                                )
                                {
                                    JutsuSpecialty = "Black Lightning",
                                    ElementBoost = 0.9
                                },
                                new NinjaRequirement(
                                    NinjaBaseRank.Jonin,
                                    Location.Kirigakure,
                                    "Chojuro",
                                    ChakraType.Water,
                                    attack: 120,
                                    heal: 10,
                                    hp: 1350,
                                    roles: new List<RoleRequirement>()
                                )
                                {
                                    JutsuSpecialty = "Hiramekarei Release",
                                    ElementBoost = 0.75
                                }
                            }
                        }
                    }
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
        VillageFactory kiriFactory = new KiriFactory();
        VillageFactory iwaFactory = new IwaFactory();

        Ninja rogueSwordsman = kiriFactory.CreateJonin(
            name: "Zabuza (Rogue)",
            chakraNature: ChakraType.Water,
            attack: 160,
            heal: 0,
            hp: 4500,
            jutsuSpecialty: "Hidden Mist Jutsu",
            elementBoost: 0.9
        );

        Decorator tankRogueSwordman = new Tank(rogueSwordsman, 100);
        
        Ninja rogueCommander = iwaFactory.CreateKage(
            name: "Rogue Tsuchikage",
            chakraNature: ChakraType.Earth,
            attack: 200,
            heal: 0,
            hp: 8000,
            bijuuPool: 1500
        );

        Decorator tankRogueCommander = new Tank(rogueCommander, 200);

        // 6. Combat Simulation
        Console.WriteLine("\n================ BATTLE START ================");

        if (konohaTeam?.Members[0] is Decorator kakashi)
        {
            
            Console.WriteLine($"\n--- Weapon Inspection: {kakashi.Name} (Equipped: {kakashi.Weapons.Count} weapons) ---");
            foreach (var weapon in kakashi.Weapons)
            {
                weapon.Display();
            }

            Client(kakashi, tankRogueCommander);
            Client(0, kakashi, tankRogueSwordman);
        }

        Console.WriteLine($"\n--- {konohaTeam?.SquadName} engages {rogueSwordsman.Name} (HP: {rogueSwordsman.HP}) ---");
        konohaTeam?.AttackTarget(rogueSwordsman);
        Console.WriteLine($"Result -> {rogueSwordsman.Name} Remaining HP: {Math.Max(0, rogueSwordsman.HP)}");

        Console.WriteLine($"\n--- {allianceTeam?.SquadName} engages {rogueCommander.Name} (HP: {rogueCommander.HP}) ---");
        allianceTeam?.AttackTarget(rogueCommander);
        Console.WriteLine($"Result -> {rogueCommander.Name} Remaining HP: {Math.Max(0, rogueCommander.HP)}");

        // Enemy Counter-Attack against a target inside the squad
        if (konohaTeam != null && konohaTeam.Members.Count > 0 && konohaTeam.Members[0] is Decorator vanguardLead)
        {
            Console.WriteLine($"\n--- Enemy Counter-Attack ---");
            rogueCommander.AttackTarget(vanguardLead);
            Console.WriteLine($"Result -> {vanguardLead.Name} Remaining HP: {Math.Max(0, vanguardLead.HP)}");
        }

        Console.WriteLine("\n================ BATTLE END ================");
    }
}