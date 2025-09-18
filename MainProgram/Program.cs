using System;

namespace mini_RPG;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Hero hero = null;
        int choice = 0;
        Console.WriteLine("Вітаємо у міні RPG грі!");
        do
        {
            Console.Clear();
            if (hero != null)
                hero.ResetTemporaryEffects();
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Створити героя");
            Console.WriteLine("2. Почати бій з випадковим ворогом");
            Console.WriteLine("3. Вийти з гри");
            do
            {
                choice = int.Parse(Console.ReadLine());
            }while (choice < 1 || choice > 3);
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    hero = CreateHero();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Починаємо бій з випадковим ворогом...");
                    if (hero == null)
                    {
                        Console.WriteLine("Спочатку створіть героя!");
                        GameUtils.PressAnyKeyToContinue();
                        break;
                    }
                    if (!hero.IsAlive())
                    {
                        Console.WriteLine("Ваш герой мертвий! Створіть нового героя, щоб продовжити.");
                        Console.ReadKey();
                        break;
                    }
                    Fight(hero, GameUtils.RandomEnemy());
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Вихід з гри. До побачення!");
                    break;
            }
        } while (choice != 3);
    }

    public static Hero CreateHero()
    {
        string name;
        Console.WriteLine("Введіть ім'я героя:");
        do 
        {
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));
        Hero hero = new Hero(name, 100, 10, 5);
        Console.WriteLine($"Герой {name} створений!");
        GameUtils.PressAnyKeyToContinue();
        return hero;
    }
    public static void Fight(Hero hero, Enemy enemy)
    {
        Console.WriteLine($"З'явився ворог: {enemy.GetName()}!");
        do
        {
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Початок раунду бою!");
            HeroAction(hero, enemy);
            
            if (!enemy.IsAlive())
            {
                Console.WriteLine($"{enemy.GetName()} повалений!");
                break;
            }

            Console.WriteLine($"\n{enemy.GetName()} атакує вас!");
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
            Console.WriteLine("Ви перемогли у бою!");
            GameUtils.ChanceToGetItem(hero);
        }
        else
            Console.WriteLine("Ви програли у бою...");

        GameUtils.PressAnyKeyToContinue();
    }

    public static void HeroAction(Hero hero, Enemy enemy)
    {
        int choice;
        for (int i= 0;i<=1;)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Атакувати ворога");
            Console.WriteLine("2. Переглянути статус героя");
            Console.WriteLine("3. Переглянути інвентар");
            Console.Write("Ваш вибір: ");
            do
            {
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
            if (choice != 2)
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
                hero.ShowPotions();
                Console.WriteLine("Оберіть номер зілля для використання:");
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