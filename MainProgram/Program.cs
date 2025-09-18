using System;

namespace mini_RPG;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Hero hero = null;
        int choice = 0;
        Console.WriteLine("Вітаємо у міні RPG грі!");
        do
        {
            Console.Clear();
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
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                        Console.ReadKey();
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
        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey();
        return hero;
    }
    public static void Fight(Hero hero, Enemy enemy)
    {
        Console.WriteLine($"З'явився ворог: {enemy.GetName()}!");
        do
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Початок раунду бою!");
            Console.WriteLine($"Поточний стан героя: {hero.Health} HP");
            Console.WriteLine("Ви наносите удар ворогу.");
            hero.Attack(enemy);
            if (!enemy.IsAlive())
            {
                Console.WriteLine($"{enemy.GetName()} повалений!");
                break;
            }
            Console.WriteLine($"{enemy.GetName()} атакує вас!");
            enemy.AttackHero(hero);
            if (!hero.IsAlive())
            {
                Console.WriteLine("Ваш герой повалений! Гра закінчена.");
                break;
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Кінець раунду бою.");
            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        } while (hero.IsAlive() && enemy.IsAlive());
        if (hero.IsAlive())
            Console.WriteLine("Ви перемогли у бою!");
        else
            Console.WriteLine("Ви програли у бою...");
        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey();
    }
}