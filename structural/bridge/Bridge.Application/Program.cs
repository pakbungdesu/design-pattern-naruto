using Builders;
using Chakras;
using CombatGears;
using Directors;
using GearMakings;
using Ninjas;

public class Program
{
    // Client helper to create combat gear using the Factory Method pattern
    public static CombatGear GearMakingClient(GearMaking gearMaking, Chakras.Chakra chakra, string modelName, double multiplier = 1.0)
    {
        return gearMaking.ComposeCombatGear(chakra, modelName, multiplier);
    }

    public static void Main()
    {
        // 1. Initialize Director and Builders
        var director = new Director();
        var standardBuilder = new StandardNinjaBuilder();
        var premiumBuilder = new PremiumNinjaBuilder();

        // 2. Build Konoha Ninja via Director
        Console.WriteLine("========================================");
        Console.WriteLine("        BUILDING KONOHA NINJA          ");
        Console.WriteLine("========================================");
        director.MakeKonohaNinja(standardBuilder, "Uchiha Sasuke");
        Ninja sasuke = standardBuilder.GetResult();

        // 3. Build Suna Ninja via Director
        Console.WriteLine("\n========================================");
        Console.WriteLine("         BUILDING SUNA NINJA           ");
        Console.WriteLine("========================================");
        director.MakeSunaNinja(premiumBuilder, "Temari");
        Ninja temari = premiumBuilder.GetResult();

        // 4. Equip custom gear manually using Factory Method (GearMaking)
        Console.WriteLine("\n--- CRAFTING & EQUIPPING CUSTOM GEAR ---");
        GearMaking weaponFactory = new WeaponMaking();
        GearMaking defenceFactory = new DefenceMaking();

        // Craft Wind Shuriken and equip directly
        Chakra windChakra = new WindChakra(armorPenetration: 0.25, chakraCost: 50);
        Weapon customWindBlade = (Weapon)GearMakingClient(weaponFactory, windChakra, "Giant Wind", 2.5);
        temari.Weapons.Add(customWindBlade);

        // Craft Fire Shield and equip directly
        Chakra fireChakra = new FireChakra(burnDamage: 40, burnDuration: 3, chakraCost: 30);
        Defence customFireShield = (Defence)GearMakingClient(defenceFactory, fireChakra, "Flame Formation Wall", 1.5);
        temari.Defences.Add(customFireShield);

        // 5. Display Initial Statuses
        sasuke.DisplayInfo();
        temari.DisplayInfo();

        // 6. Simulate Combat
        Console.WriteLine("\n========================================");
        Console.WriteLine("             COMBAT START               ");
        Console.WriteLine("========================================");

        Console.WriteLine("\n--- Round 1: Naruto attacks Temari ---");
        sasuke.UseWeapon(0, temari);

        Console.WriteLine("\n--- Round 2: Temari defends and counters ---");
        temari.UseDefence(0, incomingDamage: 120);
        temari.UseWeapon(0, sasuke);

        // 7. Final Statuses
        Console.WriteLine("\n========================================");
        Console.WriteLine("             COMBAT END                 ");
        Console.WriteLine("========================================");
        sasuke.DisplayInfo();
        temari.DisplayInfo();
    }
}