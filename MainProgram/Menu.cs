using System;

namespace mini_RPG;

class Menu
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
            Console.WriteLine("2. Переглянути мапу");
            Console.WriteLine("3. Вийти з гри");
            do
            {
                choice = int.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 3);
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    if (hero != null)
                        hero = CreateHero(hero);
                    else
                        hero = CreateHero();
                    break;
                case 2:
                    Console.Clear();
                    if (hero == null)
                    {
                        Console.WriteLine("Спочатку створіть героя!");
                        GameUtils.PressAnyKeyToContinue();
                        break;
                    }
                    if (!hero.IsAlive())
                    {
                        Console.WriteLine("Ваш герой мертвий! Створіть нового героя, щоб почати нову гру.");
                        Console.ReadKey();
                        break;
                    }
                    ShowMap(hero);
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
            if (string.IsNullOrWhiteSpace(name))
                return null;
        } while (string.IsNullOrWhiteSpace(name));
        Hero hero = new Hero(name, 100, 10, 5);
        Console.WriteLine($"Герой {name} створений!");
        GameUtils.PressAnyKeyToContinue();
        return hero;
    }

    public static Hero CreateHero(Hero hero)
    {
        string name;
        Console.WriteLine("Введіть ім'я героя:");
        do
        {
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                return hero;
        } while (string.IsNullOrWhiteSpace(name));
        Hero newHero = new Hero(name, 100, 10, 5);
        Console.WriteLine($"Герой {name} створений!");
        GameUtils.PressAnyKeyToContinue();
        return newHero;
    }

    public static void ShowMap(Hero hero)
    {
        int choice;
        int currentLocation = hero.GetLocation();

        string[] locations = { "Ліс", "Печера", "Гори" };

        Console.WriteLine("Мапа гри:");

        for (int i = 0; i < locations.Length; i++)
        {
            if (i + 1 < currentLocation)
                Console.WriteLine("---Пройдено---");
            else if (i + 1 == currentLocation)
                Console.WriteLine($"[{i + 1}] - {locations[i]}");
            else
                Console.WriteLine("---Заблоковано---");
        }

        Console.WriteLine("Виберіть місце для дослідження:");
        do
        {
            Console.Write("Ваш вибір: ");
            choice = int.Parse(Console.ReadLine());
        } while (choice < 1 || choice > locations.Length);

        switch (choice)
        {
            case 1:
                Console.WriteLine("Ви направляєтесь до лісу...");
                GameUtils.PressAnyKeyToContinue();
                Battle.Fight(hero, GameUtils.ForestRandomEnemy(hero));
                break;
            case 2:
                if (currentLocation < 2)
                {
                    Console.WriteLine("Ця локація ще недоступна. Спочатку пройдіть Ліс.");
                    GameUtils.PressAnyKeyToContinue();
                }
                else
                {
                    Console.WriteLine("Ви досліджкєте печеру...");
                    GameUtils.PressAnyKeyToContinue();
                }
                break;
            case 3:
                if (currentLocation < 3)
                {
                    Console.WriteLine("Ця локація ще недоступна. Спочатку пройдіть Печеру.");
                    GameUtils.PressAnyKeyToContinue();
                }
                else
                {
                    Console.WriteLine("Ви вирушаєте у гори...");
                    GameUtils.PressAnyKeyToContinue();
                }
                break;
        }
    }
}