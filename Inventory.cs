using System;
using System.Collections.Generic;

namespace DungeonGame
{
    public class Inventory
    {
        public List<string> Items { get; private set; }

        public Inventory()
        {
            Items = new List<string>();
        }

        public void AddItem(string item)
        {
            if (!Items.Contains(item))
            {
                // Treasure room items
                Items.Add(item);
                item = "Rubies";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
            }

            if (!Items.Contains(item))
            {
                Items.Add(item);
                item = "Gold";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
            }
            if (!Items.Contains(item))
            {
                Items.Add(item);
                item = "Emeralds";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
            }
            if (!Items.Contains(item))
            {
                Items.Add(item);
                item = "Diamonds";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
                // Spell room items
            }
            if (!Items.Contains(item))
            {
                Items.Add(item);
                item = "Poison spell";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
            }
            if (!Items.Contains(item))
            {
                Items.Add(item);
                item = "Fire spell";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
            }
            if (!Items.Contains(item))
            {
                Items.Add(item);
                item = "Regen spell";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
            }
            if (!Items.Contains(item))
            {
                Items.Add(item);
                item = "Ice spell";
                Console.WriteLine($"You have grabbed {item}.");
            }
            else
            {
                Console.WriteLine("You already have this item!");
            }

        }

        public void RemoveItem(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }

        public bool Contains(string item)
        {
            return Items.Contains(item);
        }

        public void ShowInventory()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("You have the following items in your inventory:");
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }
    }
}