using System;

namespace mini_RPG
{
    abstract public class Enemy
    {
        protected string name;
        protected int health = 0;
        protected int attackPower;
        protected EnemyType type;

        public Enemy(string name, int health, int attackPower, EnemyType type)
        {
            this.name = name;
            this.health = health;
            this.attackPower = attackPower;
            this.type = type;
        }

        public string GetName() { return name; }
        abstract public void AttackHero(Hero hero);
        abstract public void TakeDamage(int damage);

        public bool IsAlive() { return health > 0; }
    }
}