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
                Items.Add(item);
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