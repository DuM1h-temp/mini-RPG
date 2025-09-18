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

}
