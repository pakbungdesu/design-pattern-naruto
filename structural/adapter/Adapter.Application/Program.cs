using ElementTypes;
using BattleFields;
using Ninjas;
using ElementalJutsus;
using ChakraAdapters;

public class Program
{
    public static void Main()
    {
        BattleField waterField = new BattleField(ElementType.Water, naturalChakraPool: 100);

        Ninja kisame = new Ninja("Kisame", ElementType.Water, personalChakra: 20);
        Ninja sasuke = new Ninja("Sasuke", ElementType.Fire, personalChakra: 20);

        ElementalJutsu waterDragon = new ElementalJutsu("Water Dragon Bullet", ElementType.Water, requiredChakra: 50);

        ChakraAdapter kisameAdaptedJutsu = new ChakraAdapter(waterField, waterDragon);
        ChakraAdapter sasukeAdaptedJutsu = new ChakraAdapter(waterField, waterDragon);

        kisame.Jutsus.Add(kisameAdaptedJutsu);
        sasuke.Jutsus.Add(sasukeAdaptedJutsu);

        // Kisame benefits from Water field (1.5x bonus) -> succeeds
        kisame.Cast(0, sasuke);

        // Sasuke suffers penalty from Water field (0.4x penalty) -> fails
        sasuke.Cast(0, kisame);
    }
}
