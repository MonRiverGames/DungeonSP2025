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
                
                Graphics.Type(player.fastMode, $"\nWhat do you do?", "green");
                Graphics.Type(player.fastMode, $"1. Attack", "green");
                Graphics.Type(player.fastMode, $"2. Defend", "green");
                Graphics.Type(player.fastMode, $"3. Grab\n", "green");

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

                    Random rng = new Random(); //random number generator

                    string[] actions = { "attack", "defend", "grab" }; //enemy action options

                    // Pick a random index between 0 and 2
                    int index = rng.Next(actions.Length); 

                    enemyAction = actions[index];

                    Graphics.Type(player.fastMode, $"Enemy chose to {enemyAction}!");
                
                if (playerAction == enemyAction)
                {
                    Graphics.Type(player.fastMode, $"\nBoth sides chose to do the same thing! Everything cancels out!");
                }
                else if (playerAction == "attack" && enemyAction == "defend")
                {
                    Graphics.Type(player.fastMode, $"\nYou lunge at {enemy.Name}, but {enemy.Name} defends itself. You leave yourself open to an opportunity attack!\n");
                    enemy.Attack(player);
                }
                else if (playerAction == "attack" && enemyAction == "grab")
                {
                    Graphics.Type(player.fastMode, $"\nYou lunge at {enemy.Name}, and {enemy.Name} tried to grab you! You take this opportunity to attack!\n");
                    player.Attack(enemy);
                } 
                else if (playerAction == "defend" && enemyAction == "attack")
                {
                    Graphics.Type(player.fastMode, $"\n{enemy.Name} lunges at you, but you defended yourself! You take this opportunity to attack!\n");
                    player.Attack(enemy);
                }    
                else if (playerAction == "defend" && enemyAction == "grab")
                {
                    Graphics.Type(player.fastMode, $"\nYou go to defend yourself, but {enemy.Name} grabs you! Breaking you out of your defense, it gets a chance to attack.\n");
                    enemy.Attack(player);
                }   
                else if (playerAction == "grab" && enemyAction == "attack")
                {
                    Graphics.Type(player.fastMode, $"\nYou go to grab your opponent, but {enemy.Name} attacks you! As you lunge towards it, it has a moment of oppportunity.\n");
                    enemy.Attack(player);
                }       
                else if (playerAction == "grab" && enemyAction == "defend")
                {
                    Graphics.Type(player.fastMode, $"\n{enemy.Name} tried to defend itself, and you take this opportunity to grab it! It gives you a moment of oppportunity.\n");
                    player.Attack(enemy);
                }
                else
                {
                    Graphics.Type(player.fastMode, "\nSomething wrong happened. You should never get this message!\n");
                }                                                         
            }
        }
    }
}
