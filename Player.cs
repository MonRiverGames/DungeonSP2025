using System;
using System.Collections.Generic;

namespace DungeonGame
{
    // Player Class
    public class Player // Changed from internal (default) to public
    {
        public string Name { get; private set; }
        public Room CurrentRoom { get; set; }
        public Inventory Inventory { get; private set; }

        public Player(string name, Room startingRoom)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CurrentRoom = startingRoom ?? throw new ArgumentNullException(nameof(startingRoom));
            Inventory = new Inventory();
        }

        public void Move(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                Console.WriteLine($"You move {direction} to the {CurrentRoom.Name}.");
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }
        }
    }
}