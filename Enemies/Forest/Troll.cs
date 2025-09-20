using System;

namespace mini_RPG;

public class Troll : Enemy
{
    public Troll()
    {
        base.name = "Троль";
        base.health = 50;
        base.attackPower = 25;
        base.type = EnemyType.Troll;
    }

    override public void AttackHero(Hero hero)
    {
        Console.WriteLine($"{name} вдаряє героя важкою дубиною!");
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));
        int chance = GameUtils.random.Next(0, 11);
        if (chance <= 4 && !hero.IsStunned()) // 40% chance to stun the hero
        {
            hero.SetStunned(true);
            Console.WriteLine($"{name} приголомшив героя!");
            return;
        }
        if (hero.IsStunned())
        {
            hero.SetStunned(false); // Stun lasts for one turn
        }
    }
}
