using System;
using System.Collections.Generic;

namespace DungeonGame
{
    public class Room
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Dictionary<string, Room> Exits { get; private set; }
        public List<string> Items { get; private set; }

        public Room(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Exits = new Dictionary<string, Room>();
            Items = new List<string>();
        }
        public void PrintRoomDetails()
        {
            Console.WriteLine($"Room: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine("Exits:");
            foreach (var exit in Exits)
            {
                Console.WriteLine($"- {exit.Key}: {exit.Value.Name}");
            }
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}