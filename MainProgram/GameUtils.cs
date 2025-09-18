using System;

namespace mini_RPG;

public static class GameUtils
{
    public static Random random = new Random();

    public static Enemy RandomEnemy()
    {
        int check = random.Next(0, 11);
        if (check <= 5)
            return new Goblin("Гоблін", 30, 10, EnemyType.Goblin);
        else if (check == 10)
            return new Dragon("Дракон", 100, 30, EnemyType.Dragon);
        else
            return new Orc("Орк", 50, 20, EnemyType.Orc);
    }

    public static int RandomDamage(int damagePower)
    {
        int minDamage, maxDamage;
        if (damagePower <= 20)
        {
            minDamage = damagePower - 2;
            maxDamage = damagePower + 2;
        }
        else if (damagePower <= 50)
        {
            minDamage = damagePower - 3;
            maxDamage = damagePower + 3;
        }
        else
        {
            minDamage = damagePower - 5;
            maxDamage = damagePower + 5;
        }
        return random.Next(minDamage, maxDamage + 1);
    }

    public static Potion RandomPotion()
    {
        int check = random.Next(0, 11);
        if (check <= 5)
            return new Potion("Зілля зцілення", PotionType.Heal, 50);
        else if (check == 10)
            return new Potion("Зілля сили", PotionType.Strength, 15);
        else
            return new Potion("Зілля захисту", PotionType.Defense, 10);
    }

    public static void ChanceToGetItem(Hero hero)
    {
        int chance = random.Next(0, 11);
        if (chance <= 4) // 40% chance to get an item
        {
            Potion potion = RandomPotion();
            hero.addPotion(potion);
            Console.WriteLine($"Ви отримали нове зілля: {potion.GetPotionName()}!");
        }
        else if (chance == 10) // 10% chance to get a rare item
        {
            // empty for now
        }
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey();
    }
}
