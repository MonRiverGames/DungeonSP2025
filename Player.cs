using System;
using System.Collections.Generic;

namespace DungeonGame
{
    // Player Class
    class Player
    {
        public string Name { get; private set; }
        public Room CurrentRoom { get; set; }
        public Inventory Inventory { get; private set; }
        public bool fastMode { get; set; }

        public Player(string name, Room startingRoom)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CurrentRoom = startingRoom ?? throw new ArgumentNullException(nameof(startingRoom));
            Inventory = new Inventory();
        }

        public void Move(string direction, Player player)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                Graphics.TypeEffectColor(player.fastMode, $"You move {direction} to the {CurrentRoom.Name}.", "green");
            }
            else
            {
                Graphics.TypeEffectColor(player.fastMode, "You can't go that way.", "green");
            }
        }
        
    }
}