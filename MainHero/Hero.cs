using System;
using System.Collections;

namespace mini_RPG;

public class Hero
{
    public bool strengthUsed = false;
    public bool defenseUsed = false;

    private string name;
    private int health = 0;
    private int attackPower;
    private int defense;

    private List<Potion> potions = new List<Potion>();

    public int Health 
    {
        get { return health; }
        private set
        {
            if (value < 0) 
                health = 0;
            else if (value > 100)
                health = 100;
            else
                health = value;
        }
    }

    public int GetPotionCount() { return potions.Count; }

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
        Console.WriteLine($"\n{name} атакує {enemy.GetName()}!");
        enemy.TakeDamage(GameUtils.RandomDamage(attackPower));
    }

    public bool IsAlive() { return health > 0; }

    public void ShowStatus()
    {
        Console.WriteLine($"\n{name} - Здоров'я: {health}, Сила атаки: {attackPower}, Захист: {defense}");
    }

    public void addPotion(Potion potion)
    {
        potions.Add(potion);
    }

    public void ShowPotions()
    {
        Console.WriteLine("Зілля в інвентарі:");
        for (int i = 0; i < potions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Назва: {potions[i].GetPotionName()}");
        }
        Console.WriteLine("\n\nЗілля зцілення, відновлює 50 здоров'я");
        Console.WriteLine("Зілля сили, збільшує атаку на 15");
        Console.WriteLine("Зілля захисту, збільшує захист на 10\n\n");
    }

    public void UsePotion(int index)
    {
        if (index < 0 || index >= potions.Count)
        {
            Console.WriteLine("Невірний індекс зілля.");
            return;
        }
        Potion potion = potions[index];

        if (potion.GetPotionType() == PotionType.Heal)
        {
            if (health == 100)
            {
                Console.WriteLine("Ваше здоров'я вже повне. Ви не можете використати зілля зцілення.");
                return;
            }
            Health += 50;
            Console.WriteLine($"{name} використав зілля зцілення і відновив 50 здоров'я. Поточне здоров'я: {health}");
        }
        else if (potion.GetPotionType() == PotionType.Strength)
        {
            if (strengthUsed)
            {
                Console.WriteLine("Ви вже використали зілля сили. Ефект не може складатися.");
                return;
            }
            attackPower += 15;
            Console.WriteLine($"{name} використав зілля сили і збільшив атаку на 15. Поточна атака: {attackPower}");
            strengthUsed = true;
        }
        else if (potion.GetPotionType() == PotionType.Defense)
        {
            if (defenseUsed)
            {
                Console.WriteLine("Ви вже використали зілля захисту. Ефект не може складатися.");
                return;
            }
            defense += 10;
            Console.WriteLine($"{name} використав зілля захисту і збільшив захист на 10. Поточний захист: {defense}");
            defenseUsed = true;
        }
        else
        {
            Console.WriteLine("Невідомий тип зілля.");
            return;
        }

        potions.RemoveAt(index);
    }

    public void ResetTemporaryEffects()
    {
        if (strengthUsed)
        {
            attackPower -= 15;
            strengthUsed = false;
            Console.WriteLine($"{name} втратив ефект зілля сили. Поточна атака: {attackPower}");
        }
        if (defenseUsed)
        {
            defense -= 10;
            defenseUsed = false;
            Console.WriteLine($"{name} втратив ефект зілля захисту. Поточний захист: {defense}");
        }
    }
}
