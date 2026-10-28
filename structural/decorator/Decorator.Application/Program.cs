using Ninjas;
using OffensiveGears;
using DefensiveGears;

public class Program
{
    public static void Client(Ninja ninjaA, Ninja ninjaB)
    {
        int round = 1;
        
        while (round <= 5)
        {
            Console.WriteLine($"\n================== ROUND {round++} ==================");
            Console.WriteLine($"\nActive Ninja: {ninjaA.Name} | Opponent Ninja: {ninjaB.Name}");
            ninjaA.DisplayInfo();
            ninjaB.DisplayInfo();

            ExecuteTurn(active: ninjaA, opponent: ninjaB);
            if (ninjaB.IsDead) break;

            Console.WriteLine($"\nActive Ninja: {ninjaB.Name} | Opponent Ninja: {ninjaA.Name}");
            ExecuteTurn(active: ninjaB, opponent: ninjaA);
        }

        Ninja winner = ninjaA.Chakra > ninjaB.Chakra ? ninjaA : ninjaB;
        Console.WriteLine($"\n[Victory] {winner.Name} wins the battle!");
    }

    private static void ExecuteTurn(Ninja active, Ninja opponent)
    {
        Console.WriteLine($"\n--- Turn: {active.Name} ---");
        
        // Phase 1: Upkeep / Status Ticks
        active.StartTurn();
        if (active.IsDead)
        {
            Console.WriteLine($"  -> {active.Name} succumbed to effects.");
            return;
        }

        // Phase 2: Action Phase
        if (!opponent.CanBeSeen)
        {
            Console.WriteLine($"  -> {active.Name} cannot target {opponent.Name} (Invisible).");
        }
        else
        {
            int damageDealt = active.Attack(opponent);
            opponent.Defend(damageDealt);
        }

        // Phase 3: Cleanup / Cooldowns
        active.EndTurn();
    }

    public static void Main()
    {
        Console.WriteLine("======================= MATCH 1 =======================");
        Ninja sasuke = new Ninja("Sasuke");
        Ninja naruto = new Ninja("Naruto");

        // Sasuke
        OffensiveGear katana = new Katana { CriticalMultiplier = 2.0, AddDamage = 25 };
        OffensiveGear poisonedKatana = new Poison(katana);
        OffensiveGear explosivePoisonedKatana = new ExplosiveTag(poisonedKatana);

        DefensiveGear vest = new Vest{ VitalDurability = 40, AbsorbDamage = 20 };
        DefensiveGear disguiseVest = new Disguising(vest);


        sasuke.EquipOffensive(explosivePoisonedKatana);
        sasuke.EquipDefensive(disguiseVest);

        // Naruto
        OffensiveGear kunai = new Kunai{ AddDamage = 25, PiercingBonus = 10 };
        OffensiveGear poisonedKunai = new Poison(kunai);
        OffensiveGear explosivePoisonedKunai = new ExplosiveTag(poisonedKunai);
        
        DefensiveGear cloak = new Cloak { CamouflageEvasion = 20, AbsorbDamage = 20 };
        DefensiveGear auraBarrierCloak = new AuraBarrier(cloak);


        naruto.EquipOffensive(explosivePoisonedKunai);
        naruto.EquipDefensive(auraBarrierCloak);

        Client(sasuke, naruto);

        Console.WriteLine("\n\n======================= MATCH 2 =======================");
        Ninja itachi = new Ninja("Itachi");
        Ninja minato = new Ninja("Minato");

        OffensiveGear shuriken = new Shuriken { ProjectileCount = 4, AddDamage = 8 };
        OffensiveGear explosiveShuriken = new ExplosiveTag(shuriken);
        OffensiveGear poisonedExplosiveShuriken = new Poison(explosiveShuriken);
      
        itachi.EquipOffensive(poisonedExplosiveShuriken);
        itachi.EquipDefensive(disguiseVest);

        DefensiveGear shield = new Shield { AbsorbDamage = 20 };
        DefensiveGear auraBarrierShield = new AuraBarrier(shield);

        minato.EquipDefensive(auraBarrierShield);
        minato.EquipOffensive(explosivePoisonedKunai);

        Client(itachi, minato);
    }
}
