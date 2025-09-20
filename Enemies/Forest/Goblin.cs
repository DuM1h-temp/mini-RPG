using System;

namespace mini_RPG;

public class Goblin : Enemy
{
    public Goblin()
    {
        base.name = "Гоблін";
        base.health = 30;
        base.attackPower = 10;
        base.type = EnemyType.Goblin;
    }

    override public void AttackHero(Hero hero)
    {
        Console.WriteLine($"{name} вдаряє пазурями героя!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));
    }
}
