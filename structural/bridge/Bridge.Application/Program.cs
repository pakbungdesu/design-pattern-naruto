using System;
using Builders;
using Chakras;
using CombatGears;
using Directors;
using Ninjas;

class Program
{
    static void BattleTurn(Ninja attacker, int weaponIndex, Ninja defender, int defenceIndex)
    {
        Console.WriteLine($"\n--- Turn: {attacker.Name} attacks {defender.Name} ---");

        int rawDamage = attacker.UseWeapon(weaponIndex, defender);
        int damageTaken = defender.UseDefence(defenceIndex, rawDamage);
        defender.ModifyChakra(damageTaken);
    }

    static void Main(string[] args)
    {
        Chakra fireEffect = new FireChakra();
        Chakra windEffect = new WindChakra();

        // Sasuke
        Director director = new Director();
        NinjaBuilder builder = new StandardNinjaBuilder();

        Console.WriteLine("================ BUILDING NINJAS ================");
        Console.WriteLine("\n[Building Konoha Ninja...]");
        director.MakeKonohaNinja(builder, "sasuke");
        Ninja sasuke = builder.GetResult();

        Console.WriteLine("\n[Building Suna Ninja...]");
        director.MakeSunaNinja(builder, "temari");
        Ninja temari = builder.GetResult();
    
        Weapon standardBlade = new Weapon(fireEffect, "Standard Blade");
        Weapon shuriken = new Weapon(fireEffect, "Standard Shuriken");
        Defence uchihaShield = new Defence (fireEffect, "Crest Shield");

        sasuke.Weapons.Add(standardBlade);
        sasuke.Weapons.Add(shuriken);
        sasuke.Defences.Add(uchihaShield);
        Weapon standardKunai = new Weapon(windEffect, "Flying Kunai");
        Defence armor = new Defence(windEffect, "Defender Armor");

        temari.Weapons.Add(standardKunai);
        temari.Defences.Add(armor);

        // Display Initial Profiles
        sasuke.DisplayInfo();
        temari.DisplayInfo();

        // Combat Simulation
        Console.WriteLine("======================= ROUND 1 =======================");
        BattleTurn(sasuke, 0, temari, 0);

        Console.WriteLine("\n======================= ROUND 2 =======================");
        BattleTurn(temari, 0, sasuke, 0);

        Console.WriteLine("\n========== DYNAMIC BINDING (SWAPPING IMPLEMENTOR) ==========");
        Console.WriteLine($"⚡ Sasuke re-infuses '{sasuke.Weapons[0].ModelName}' with Wind Chakra!");
        sasuke.Weapons[0].Effect = windEffect;
        temari.Weapons[1].Effect = fireEffect;

        sasuke.DisplayInfo();
        temari.DisplayInfo();

        // Passive Recovery
        Console.WriteLine("\n======================= POST-BATTLE RECOVERY =======================");
        temari.HealChakra(5);
        sasuke.HealChakra(5);
    }
}