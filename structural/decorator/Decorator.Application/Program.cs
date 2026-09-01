using Ninjas;
using OffensiveGears;
using DefensiveGears;

public class Program
{
    public static void Client(Ninja attacker, Ninja target)
    {
        int totalDmg = attacker.Attack(target);
        target.Defend(totalDmg);
    }

    public static void Main()
    {
        var sasuke = new Ninja("Sasuke");
        var naruto = new Ninja("Naruto");

        // Sasuke: Kunai -> Poison -> Explosive Tag
        OffensiveGear kunai = new Kunai();
        OffensiveGear poisonedKunai = new Poison(kunai);
        OffensiveGear explosivePoisonedKunai = new ExplosiveTag(poisonedKunai);
        sasuke.EquipOffensive(explosivePoisonedKunai);

        // Naruto: Vest -> Barrier -> Disguising
        DefensiveGear vest = new Vest();
        DefensiveGear auraBarrierVest = new AuraBarrier(vest);
        DefensiveGear disguiseAuraBarrier = new Disguising(auraBarrierVest);
        naruto.EquipDefensive(disguiseAuraBarrier);

        sasuke.DisplayGearInfo();
        naruto.DisplayGearInfo();

        Console.WriteLine("\n--- Turn 1 ---");
        Client(sasuke, naruto);

        sasuke.DisplayGearInfo();
        naruto.DisplayGearInfo();

        Console.WriteLine("\n--- Turn 2 ---");
        Client(naruto, sasuke);

        sasuke.DisplayGearInfo();
        naruto.DisplayGearInfo();

    }
}
