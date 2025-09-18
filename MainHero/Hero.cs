using System;

namespace mini_RPG;

public class Hero
{
    private string name;
    private int health = 0;
    private int attackPower;
    private int defense;

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

    public Hero(string name, int health, int attackPower, int defense)
    {
        this.name = name;
        this.health = health;
        this.attackPower = attackPower;
        this.defense = defense;
    }

    public void TakeDamage(int damage)
    {
        int damageTaken = Math.Max(damage - defense, 0);
        Health -= damageTaken;
        Console.WriteLine($"{name} отримав {damageTaken} шкоди! Здоров'я залишилось: {health}");
    }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"{name} атакує {enemy.GetName()} з силою {attackPower}!");
        enemy.TakeDamage(attackPower);
    }

    public bool IsAlive() { return health > 0; }

    public void useItem(Item item)
    {
        // Implement item usage logic here
    }
}
