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

        public void AddItem(string name)
        {
            Item item = new Item(name);
            if (!Items.Contains(item.Name))
            {
                // Treasure room items
                Items.Add(item.Name);
                Console.WriteLine($"You aggressively shove the {item.Name} into your bag.");
            }
            else
            {
                Console.WriteLine("Check your inventory lately? You already have that item!");
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
                Console.WriteLine("It's as empty in here as your wallet.");
            }
            else
            {
                Console.WriteLine("Is that a...? The items in your... Lich Kitty merchandise bag are as follows:");
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }
    }
}