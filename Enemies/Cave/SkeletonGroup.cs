using System;

namespace mini_RPG;

public class SkeletonGroup : Enemy
{
    public SkeletonGroup()
    {
        base.name = "Група скелетів";
        base.health = 105;
        base.attackPower = 15;
        base.type = EnemyType.SkeletonGroup;
    }

    override public void AttackHero(Hero hero)
    {
        Console.WriteLine($"{name} наніс удар мечем по герою!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));
        Console.WriteLine($"{name} наніс удар мечем по герою!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));
        int chance = GameUtils.random.Next(0, 11);
        if (chance <= 5) // 50% chance to damage through the hero's defense
        {
            Console.WriteLine($"{name} пробиває броню стрілою!");
            hero.TakeDamage(GameUtils.RandomDamage(attackPower) + hero.Defense);
            return;
        }
        Console.WriteLine($"{name} випустив стрілу в героя!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));        
    }
}