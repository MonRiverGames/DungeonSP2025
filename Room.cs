using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonGame
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Room> Exits { get; set; } = new Dictionary<string, Room>();
        public List<string> Items { get; set; } = new List<string>();
        public Dictionary<string, string> Actions { get; private set; }

        public List  <string> Enemies {get; set; } = new List<string>();

        // Constructor
        public Room(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Actions = new Dictionary<string, string>(); // Stores room-specific actions, e.g., "push lever -> Opens secret door."
        }

        // Add an exit to this room
        public void AddExit(string direction, Room room)
        {
            if (string.IsNullOrWhiteSpace(direction)) throw new ArgumentException("Direction cannot be null or empty.", nameof(direction));
            if (room == null) throw new ArgumentNullException(nameof(room));

            Exits[direction.ToLower()] = room;
        }

        // Add an item to this room
        public void AddItem(string item)
        {
            if (string.IsNullOrWhiteSpace(item)) throw new ArgumentException("Item cannot be null or empty.", nameof(item));
            Items.Add(item);
        }

        public void AddEnemy (string enemy)
        {
            if (string.IsNullOrWhiteSpace(enemy)) throw new ArgumentException("Item cannot be null or empty.", nameof(enemy));
            Enemies.Add(enemy);
        }

        // Remove an item from this room
        public bool RemoveItem(string item)
        {
            return Items.Remove(item);
        }

        // Add a room-specific action
        public void AddAction(string actionKey, string actionDescription)
        {
            if (string.IsNullOrWhiteSpace(actionKey)) throw new ArgumentException("Action key cannot be null or empty.", nameof(actionKey));
            if (string.IsNullOrWhiteSpace(actionDescription)) throw new ArgumentException("Action description cannot be null or empty.", nameof(actionDescription));

            Actions[actionKey.ToLower()] = actionDescription;
        }

        // Perform an action
        public string PerformAction(string actionKey)
        {
            if (Actions.TryGetValue(actionKey.ToLower(), out string result))
            {
                return result; // Result is guaranteed to be non-null here.
            }
            return "Nothing happens."; // Default message for invalid actions.
        }

        // Display room information
        public void DisplayRoomInfo()
        {
            Console.WriteLine($"Room: {Name}");
            Console.WriteLine($"Description: {Description}");

            Console.WriteLine("Exits:");
            foreach (var exit in Exits.Keys)
            {
                Console.WriteLine($"- {exit}");
            }

            Console.WriteLine("Items:");
            if (Items.Count > 0)
            {
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("None.");
            }

            Console.WriteLine("Actions:");
            if (Actions.Count > 0)
            {
                foreach (var action in Actions)
                {
                    Console.WriteLine($"- {action.Key}: {action.Value}");
                }
            }
            else
            {
                Console.WriteLine("None.");
            }
        }
        public void PrintRoomDetails()
        {
            Console.WriteLine($"Room: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine("Exits:");
            foreach (var exit in Exits)
            {
                // Check if exit.Value is null before accessing its Name property
                string exitRoomName = exit.Value != null ? exit.Value.Name : "Unknown";
                Console.WriteLine($"- {exit.Key}: {exitRoomName}");
            }
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item}");
            }
        }

        

        public static Room InitializeRooms()
        {
            // Initialize Rooms
            Room startRoom = new Room("Foyer", "A grand black and red dimly lit hall, room is lit by some torches.");
            Room livingRoom = new Room("Living Room", "A room lit only by table lamps.\nThe first thing you see upon entrance is a jet black Victorian table.");
            Room libraryRoom = new Room("Library", "A library filled with books of all kind.\nIn your peripheral vision you can see a potion station.");
            Room bedRoom = new Room("Master bedroom", "A huge room fit for a king.\nYou notice all the stuffed animals on the pink frilly bed.");
            Room kitchenRoom = new Room("Kitchen", "A black and white tiled kitchen.\nYou see a singular apple on the marble island.");

            // Connect Rooms
            startRoom.Exits["north"] = livingRoom;
            livingRoom.Exits["south"] = startRoom;
            livingRoom.Exits["east"] = libraryRoom;
            livingRoom.Exits["north"] = kitchenRoom;
            livingRoom.Exits["west"] = bedRoom;
            libraryRoom.Exits["west"] = livingRoom;
            kitchenRoom.Exits["south"] = livingRoom;
            bedRoom.Exits["east"] = livingRoom;

            // Add Items to Rooms
            startRoom.Items.Add("torch");
            livingRoom.Items.Add("key");
            libraryRoom.Items.Add("potion");
            bedRoom.Items.Add("note");
            kitchenRoom.Items.Add("apple");

            // Adds Enemies to the rooms
            livingRoom.Enemies.Add("Spirit");
            kitchenRoom.Enemies.Add("AcidWorm");
            libraryRoom.Enemies.Add("Lich");
            bedRoom.Enemies.Add("Spirit");






            return startRoom; // Return the starting room
        }
    }
}
