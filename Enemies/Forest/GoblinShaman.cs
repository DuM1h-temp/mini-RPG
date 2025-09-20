using System;

namespace mini_RPG;

public class GoblinShaman : Enemy
{
    public GoblinShaman()
    {
        base.name = "Гоблін-шаман";
        base.health = 40;
        base.attackPower = 15;
        base.type = EnemyType.GoblinShaman;
    }

    override public void AttackHero(Hero hero)
    {
        Console.WriteLine($"{name} вдаряє героя отруйним посохом!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));
        int chance = GameUtils.random.Next(0, 11);
        if (chance <= 3 && !hero.IsPoisoned()) // 30% chance to poison the hero
        {
            hero.SetPoisoned(true);
            Console.WriteLine($"{name} отруїв героя!");
        }
        if (hero.IsPoisoned())
        {
            hero.PoisonDamage(5); // Poison deals 5 damage each turn
            Console.WriteLine("Герой отримав 5 шкоди від отруєння!");
        }
    }
}
