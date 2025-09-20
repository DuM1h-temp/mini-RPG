using System;

namespace mini_RPG;

public static class GameUtils
{
    public static Random random = new Random();

    public static Enemy ForestRandomEnemy(Hero hero)
    {
        if ((hero.GetMonstersDefeated() % 4 == 0) && hero.GetMonstersDefeated() != 0)
            return new Troll();
        int check = random.Next(0, 11);
        if (check <= 8)
            return new Goblin();
        else
            return new GoblinShaman();
    }

    public static Enemy CaveRandomEnemy(Hero hero)
    {
        if ((hero.GetMonstersDefeated() % 4 == 0) && hero.GetMonstersDefeated() != 0)
            return new SkeletonGroup();
        int check = random.Next(0, 11);
        if (check <= 8)
            return new Skeleton();
        else
            return new SkeletonArcher();
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

    public static int GoldReward(Enemy enemy)
    {
        int minGold=0;
        int maxGold = 0;
        switch (enemy.GetEnemyType())
        {
            case EnemyType.Goblin:
                minGold = 5;
                maxGold = 10;
                break;
            case EnemyType.GoblinShaman:
                minGold = 10;
                maxGold = 20;
                break;
            case EnemyType.Troll:
                minGold = 30;
                maxGold = 40;
                break;
            case EnemyType.Skeleton:
                minGold = 20;
                maxGold = 30;
                break;
            case EnemyType.SkeletonArcher:
                minGold = 30;
                maxGold = 40;
                break;
            case EnemyType.SkeletonGroup:
                minGold = 50;
                maxGold = 70;
                break;
            case EnemyType.Dragon:
                minGold = 100;
                maxGold = 200;
                break;
        }
        return random.Next(minGold, maxGold);
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
