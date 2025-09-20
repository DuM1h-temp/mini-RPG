using System;

namespace mini_RPG;

public class SkeletonArcher : Enemy
{
    public SkeletonArcher()
    {
        base.name = "Скелет-лучник";
        base.health = 25;
        base.attackPower = 15;
        base.type = EnemyType.SkeletonArcher;
    }

    override public void AttackHero(Hero hero)
    {
        int chance = GameUtils.random.Next(0, 11);
        if (chance <= 5) // 50% chance to damage through the hero's defense
        {
            Console.WriteLine($"{name} пробиває броню стрілою!");
            hero.TakeDamage(GameUtils.RandomDamage(attackPower)+hero.Defense);
            return;
        }
        Console.WriteLine($"{name} випустив стрілу в героя!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));        
    }
}