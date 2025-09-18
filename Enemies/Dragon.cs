using System;

namespace mini_RPG;

public class Dragon : Enemy
{
    public int Health
    {
        get { return health; }
        private set
        {
            if (value < 0)
                health = 0;
            else
                health = value;
        }
    }

    public Dragon(string name, int health, int attackPower, EnemyType type) : base(name, health, attackPower, type)
    {
    }

    override public void AttackHero(Hero hero)
    {
        hero.TakeDamage(GameUtils.RandomDamage(attackPower));
    }

    override public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{name} отримав {damage} шкоди! Здоров'я залишилось: {health}");
    }
}
