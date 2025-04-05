using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonGame
{
    public class Room
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Dictionary<string, Room> Exits { get; private set; }
        public List<string> Items { get; private set; }
        public Dictionary<string, string> Actions { get; private set; }

        // Constructor
        public Room(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Exits = new Dictionary<string, Room>();
            Items = new List<string>();
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

        public static void Battle(Enemy enemy, Player player)
        {
            Graphics.Type(player.fastMode, $"You are now battling {enemy.Name}.", "none");
            Graphics.Type(player.fastMode, $"[You are unable to interact with the room until you finish off {enemy.Name} or if you die. Good luck!]", "green", 0, 15);

            string playerAction = "none";
            string enemyAction = "none";

            while(true)
            {
                if (player.Health.current <= 0)
                {
                    Graphics.Type(player.fastMode, "You start to feel woozy. Your breaths become shallower, and your vision begins to darken. Eventually, you can't see anything. You can't feel anything.", "green", 200, 50);
                    Graphics.Type(player.fastMode, "YOU DIED.", "green", 200, 50);
                    break;
                }
                else if (enemy.Health.current <= 0)
                {
                    Graphics.Type(player.fastMode, $"You deliver the final blow to the {enemy.Name}. It shrieks in pain. You sigh, it's over.", "none", 200, 50);
                    Graphics.Type(player.fastMode, "YOU HAVE SLAIN YOUR ENEMY.", "green", 200, 50);
                    break;
                }
                
                Graphics.Type(player.fastMode, $"What do you do?");
                Graphics.Type(player.fastMode, $"1. Attack");
                Graphics.Type(player.fastMode, $"2. Defend");
                Graphics.Type(player.fastMode, $"3. Grab");

                while (true) // run determine what the player does
                {
                        Console.Write("> ");
                        string input = Console.ReadLine() ?? string.Empty;
                        input = input.ToLower(); //detects player input

                    if (input == "1" || input == "attack")
                    {
                        playerAction = "attack"; // set the player action to attack
                        Graphics.Type(player.fastMode, "You chose to attack!");    
                        break;
                    }

                    else if (input == "2" || input == "defend")
                    {
                        playerAction = "defend"; // set the player action to defend
                        Graphics.Type(player.fastMode, "You chose to defend!");    
                        break;
                    }

                    else if (input == "3" || input == "grab")
                    {
                        playerAction = "grab"; // set the action to grab
                        Graphics.Type(player.fastMode, "You chose to grab!");    
                        break;
                    }
                    else
                    {
                        Graphics.Type(player.fastMode, "Invalid action");
                    }
                }
                

            }
        }
    }
}
