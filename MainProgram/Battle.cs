using System;

namespace mini_RPG;

public static class Battle
{
    public static void Fight(Hero hero, Enemy enemy)
    {
        Console.Clear();
        Console.WriteLine($"З'явився ворог: {enemy.GetName()}!");
        do
        {
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Початок раунду бою!");
            if (!hero.IsStunned())
                HeroAction(hero, enemy);

            if (!enemy.IsAlive())
            {
                Console.WriteLine($"{enemy.GetName()} повалений!");
                break;
            }

            enemy.AttackHero(hero);
            if (!hero.IsAlive())
            {
                Console.WriteLine("Ваш герой повалений! Гра закінчена.");
                break;
            }

            Console.WriteLine("Кінець раунду бою.");
            Console.WriteLine("-------------------------");
            Console.ReadKey();
        } while (hero.IsAlive() && enemy.IsAlive());
        if (hero.IsAlive())
        {
            hero.Victory(enemy);
        }
        else
            Console.WriteLine("Ви програли у бою...");

        GameUtils.PressAnyKeyToContinue();
    }

    public static void HeroAction(Hero hero, Enemy enemy)
    {
        int choice;
        for (int i = 0; i <= 1;)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Атакувати ворога");
            Console.WriteLine("2. Переглянути статус героя");
            Console.Write("3. Переглянути інвентар");
            do
            {
                Console.Write("\nВаш вибір: ");
                choice = int.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 3);
            switch (choice)
            {
                case 1:
                    hero.Attack(enemy);
                    break;
                case 2:
                    hero.ShowStatus();
                    break;
                case 3:
                    ShowInvontory(hero);
                    break;
            }
            if ((choice == 1) || ((choice == 3) && (hero.defenseUsed || hero.strengthUsed)))
                break;
        }
        Console.ReadKey();
    }

    public static void ShowInvontory(Hero hero)
    {
        Console.WriteLine("\n1. Переглянути предмети (в розробці)");
        Console.WriteLine("2. Використати зілля");
        Console.WriteLine("3. Повернутись назад");
        int choice;
        do
        {
            choice = int.Parse(Console.ReadLine());
        } while (choice < 2 || choice > 3);
        switch (choice)
        {
            case 1:

                break;
            case 2:
                if (hero.GetPotionCount() == 0)
                {
                    Console.WriteLine("У вас немає зілля в інвентарі.");
                    return;
                }
                hero.ShowPotions();
                Console.Write("Оберіть номер зілля для використання:");
                int potionChoice;
                do
                {
                    potionChoice = int.Parse(Console.ReadLine());
                } while (potionChoice < 1 || potionChoice > hero.GetPotionCount());
                hero.UsePotion(potionChoice - 1);
                break;
            case 3:
                break;
        }
    }
}
