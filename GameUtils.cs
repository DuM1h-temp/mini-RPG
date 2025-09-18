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
}
