using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Random random = new Random();

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("James", 100);

            if (random.Next(1, 3) == 1)
            {
                new Enemy("Small Ogre", 30, 10);
            }
            currentRoom = new Room("You are in a dark cold dungeon with cobwebs everywhere. There are some items laying around. You spot an old wooden sword in one corner. There is a red potion on a table to your left");
            currentRoom.AddItem("Potion");
            currentRoom.AddItem("Wooden Sword");
        }

        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here


                Console.Clear();
                Console.WriteLine("Current Room: " + currentRoom.GetDescription());
                Console.WriteLine("Items in this room: " + currentRoom.GetItems());
                Console.WriteLine("Your inventory: " + player.InventoryContents());
                Console.WriteLine("Your health: " + player.Health);

                if (currentRoom.HasEnemy())
                {
                    Console.WriteLine($"An enemy appears! It's a {currentRoom.Enemy.Name} with {currentRoom.Enemy.Health} HP!");
                    Console.WriteLine("What will you do?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Run");

                    string choice = Console.ReadLine().ToLower();
                    if (choice == "1")
                    {
                        Fight();
                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You died...");
                            playing = false;
                            continue;
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("You fled the enemy!");
                        playing = false;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice!");
                    }
                }
                else
                {
                    Console.WriteLine("\nWhat would you like to do?");
                    Console.WriteLine("1. Pick up an item");
                    Console.WriteLine("2. Use an item");
                    Console.WriteLine("3. Exit the dungeon");

                    string choice = Console.ReadLine().ToLower();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Which item would you like to pick up?");
                            string itemToPick = Console.ReadLine().ToLower();

                            if (currentRoom.HasItem(itemToPick))
                            {
                                player.PickUpItem(itemToPick);
                                currentRoom.RemoveItem(itemToPick);
                            }
                            else
                            {
                                Console.WriteLine("That item is not in the room!");
                            }
                            break;

                        case "2":
                            Console.WriteLine("Which item would you like to use?");
                            string itemToUse = Console.ReadLine();
                            player.UseItem(itemToUse);
                            break;

                        case "3":
                            playing = false;
                            Console.WriteLine("Exiting the dungeon...");
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void Fight()
        {
            Enemy enemy = currentRoom.Enemy;

            while (player.Health > 0 && enemy.IsAlive())
            {
                Console.WriteLine($"You attack the {enemy.Name}!");

                int damage = player.InventoryContents().Contains("wooden sword") ? 15 : 5;
                enemy.TakeDamage(damage);
                Console.WriteLine($"You dealt {damage} damage! Enemy HP: {enemy.Health}");

                if (!enemy.IsAlive())
                {
                    Console.WriteLine($"You defeated the {enemy.Name}!");
                    currentRoom.RemoveEnemy();
                    break;
                }

                Console.WriteLine($"{enemy.Name} attacks you!");
                player.TakeDamage(enemy.Attack());
                Console.WriteLine($"You took {enemy.Power} damage! Your HP: {player.Health}");

                if (player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated...");
                    break;
                }

                Console.WriteLine("Press any key for the next round...");
                Console.ReadKey();
            }
        }
    }
}