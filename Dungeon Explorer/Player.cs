using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item.ToLower());
            Console.WriteLine($"{item} added to inventory.");
        }

        public void UseItem(string item)
        {
            if (!inventory.Contains(item))
            {
                Console.WriteLine("You don't have that item right now!");
                return;
            }

            switch (item.ToLower())
            {
                case "potion":
                    if (Health == 100)
                    {
                        Console.WriteLine("Your health is already 100 - no need for the potion.");
                        return;
                    }
                    Heal(10);
                    Console.WriteLine("The potion healed 10 health.");
                    inventory.Remove(item);
                    break;

                case "wooden sword":
                    Console.WriteLine("There are no enemies to fight right now.");
                    break;

                default:
                    Console.WriteLine("You can't use that right now.");
                    break;
            }
        }
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Your inventory has nothing in it!";
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"You took {damage} damage. Current health = {Health}");
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;
        }
    }
}