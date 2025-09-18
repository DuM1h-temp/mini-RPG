using System;

namespace mini_RPG;

public class Goblin : Enemy
{
    public Goblin(string name, int health, int attackPower, EnemyType type) : base(name, health, attackPower, type)
    {
    }

    override public void AttackHero(Hero hero)
    {
        hero.TakeDamage(attackPower);
    }
    override public void TakeDamage(int damage)
    {
        health -= damage;
        Console.WriteLine($"{name} отримав {damage} шкоди! Здоров'я залишилось: {health}");
    }
}
