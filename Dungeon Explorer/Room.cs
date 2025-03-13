using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;
        public Enemy Enemy { get; private set; }

        public Room(string description, Enemy enemy = null)
        {
            this.description = description;
            items = new List<string>();
            Enemy = enemy;
        }

        public string GetDescription()
        {
            return description;
        }

        public void AddItem(string item)
        {
            items.Add(item.ToLower());
        }

        public string GetItems()
        {
            return items.Count > 0 ? string.Join(", ", items) : "No items.";
        }

        public bool HasItem(string item)
        {
            return items.Contains(item.ToLower());
        }

        public bool RemoveItem(string item)
        {
            return items.Remove(item.ToLower());
        }

        public bool HasEnemy()
        {
            return Enemy != null && Enemy.IsAlive();
        }

        public void RemoveEnemy()
        {
            Enemy = null;
        }
    }
}