using System;

namespace mini_RPG;

public struct Potion
{
    private string potionName;
    private int power;
    private PotionType type;

    public string GetPotionName() { return potionName; }
    public int GetPower() { return power; }
    public PotionType GetPotionType() { return type; }

    public Potion(string potionName, PotionType type, int power)
    {
        this.potionName = potionName;
        this.power = power;
        this.type = type;
    }

    public void Use(Hero hero)
    {
        switch (type)
        {
            case PotionType.Heal:
                hero.Heal(power);
                Console.WriteLine($"Герой використав {potionName} і відновив {power} здоров'я!");
                break;
            case PotionType.Strength:
                hero.IncreaseAttack(power);
                Console.WriteLine($"Герой використав {potionName} і збільшив атаку на {power}!");
                break;
            case PotionType.Defense:
                hero.IncreaseDefense(power);
                Console.WriteLine($"Герой використав {potionName} і збільшив захист на {power}!");
                break;
        }
    }
}
