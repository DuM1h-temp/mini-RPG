using System;

namespace mini_RPG;

public class Dragon : Enemy
{

    public Dragon()
    {
        base.name = "Дракон";
        base.health = 100;
        base.attackPower = 25;
        base.type = EnemyType.Dragon;
    }

}
