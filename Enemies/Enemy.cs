using System;
using System.Reflection.Metadata.Ecma335;

namespace mini_RPG
{
    abstract public class Enemy
    {
        protected string name;
        protected int health = 0;
        protected int attackPower;
        protected EnemyType type;

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

        public Enemy() { }

        public string GetName() { return name; }
        public EnemyType GetEnemyType() { return type; }
        virtual public void AttackHero(Hero hero)
        {
            hero.TakeDamage(GameUtils.RandomDamage(attackPower));
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{name} отримав {damage} шкоди! Здоров'я залишилось: {health}");
        }

        public bool IsAlive() { return health > 0; }


    }
}