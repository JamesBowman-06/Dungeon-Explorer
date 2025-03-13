using System;

namespace DungeonExplorer
{
    public class Enemy
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Power { get; private set; }

        public Enemy(string name, int health, int power)
        {
            Name = name;
            Health = health;
            Power = power;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public int Attack()
        {
            return Power;
        }
    }
}
