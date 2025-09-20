using System;
using System.Collections;

namespace mini_RPG;

public class Hero
{
    private int location = 1;
    private int monstersDefeated = 0;
    public int GetMonstersDefeated() { return monstersDefeated; }
    public int GetLocation() { return location; }

    public bool strengthUsed = false;
    public bool defenseUsed = false;

    private bool poisoned = false;
    public bool IsPoisoned() { return poisoned; }
    public void SetPoisoned(bool value) { poisoned = value; }

    private bool stunned = false;
    public bool IsStunned() { return stunned; }
    public void SetStunned(bool value) { stunned = value; }

    private string name;
    private int health = 0;
    private int attackPower;
    private int defense;

    private int gold = 0;

    private List<Potion> potions = new List<Potion>();
    public int GetPotionsCount() { return potions.Count; }

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
    public int Defense 
    { 
        get { return defense; }
        private set
        {
            if (value < 0)
                defense = 0;
            else
                defense = value;
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
        if (damageTaken == 0)
        {
            Console.WriteLine("Герой відбив удар");
        }
        else
        {
            Health -= damageTaken;
            Console.WriteLine($"{name} отримав {damageTaken} шкоди! Здоров'я залишилось: {health}");
        }
    }
    public void PoisonDamage(int damage)
    {
        Health -= damage;
    }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"\n{name} атакує {enemy.GetName()}!");
        enemy.TakeDamage(GameUtils.RandomDamage(attackPower));
    }

    public bool IsAlive() { return health > 0; }

    public void ShowStatus()
    {
        Console.WriteLine($"\n{name} - Здоров'я: {health} \nСила атаки: {attackPower} \nЗахист: {defense} \nЗолото: {gold}");
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
            potions[index].Use(this);
        }
        else if (potion.GetPotionType() == PotionType.Strength)
        {
            if (strengthUsed)
            {
                Console.WriteLine("Ви вже використали зілля сили. Ефект не може складатися.");
                return;
            }
            potions[index].Use(this);
            strengthUsed = true;
        }
        else if (potion.GetPotionType() == PotionType.Defense)
        {
            if (defenseUsed)
            {
                Console.WriteLine("Ви вже використали зілля захисту. Ефект не може складатися.");
                return;
            }
            potions[index].Use(this);
            defenseUsed = true;
        }
        else
        {
            Console.WriteLine("Невідомий тип зілля.");
            return;
        }

        potions.RemoveAt(index);
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{name} відновив {amount} здоров'я! Поточне здоров'я: {health}");
    }

    public void IncreaseAttack(int amount)
    {
        attackPower += amount;
        Console.WriteLine($"{name} збільшив атаку на {amount}! Поточна атака: {attackPower}");
    }

    public void IncreaseDefense(int amount)
    {
        defense += amount;
        Console.WriteLine($"{name} збільшив захист на {amount}! Поточний захист: {defense}");
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

    public void Victory(Enemy enemy)
    {
        Console.WriteLine("Ви перемогли у бою!");
        GameUtils.ChanceToGetItem(this);
        monstersDefeated++;
        int reward = GameUtils.GoldReward(enemy);
        gold += reward;
        Console.WriteLine($"Ви отримали {reward} золота!");
        if (monstersDefeated % 5 == 0)
        {
            location++;
            Console.WriteLine($"Ви просунулись до наступної локації!");
        }
    }

    
}
