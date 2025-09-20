using System;

namespace mini_RPG;

public class Skeleton : Enemy
{
    public Skeleton()
    {
        base.name = "Скелет";
        base.health = 40;
        base.attackPower = 15;
        base.type = EnemyType.Skeleton;
    }

    override public void AttackHero(Hero hero)
    {
        Console.WriteLine($"{name} наніс удар мечем по герою!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));        
    }
}