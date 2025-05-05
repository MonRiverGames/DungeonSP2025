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

        public void AddItem(string name, Player player)
        {
            Item item = new Item(name, player);
            if (!Items.Contains(item.Name))
            {
                // Treasure room items
                Items.Add(item.Name);
                Graphics.Type(player.fastMode, $"You aggressively shove the {item.Name} into your bag.");
            }
            else
            {
                Graphics.Type(player.fastMode, "Check your inventory lately? You already have that item!");
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

        public void ShowInventory(Player player)
        {
            if (Items.Count == 0)
            {
                Graphics.Type(player.fastMode, "It's as empty in here as your wallet.");
            }
            else
            {
                Graphics.Type(player.fastMode, "Is that a...? The items in your... Lich Kitty merchandise bag are as follows:");
                foreach (var item in Items)
                {
                    Graphics.Type(player.fastMode, $"- {item}");
                }
            }
        }

        public void ClearInventory(Player player)
        {
            Items.Clear();
            Graphics.Type(player.fastMode, "Your inventory has been cleared.");
        }
    }
}