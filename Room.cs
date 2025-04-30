using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace DungeonGame
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Room> Exits { get; set; } = new Dictionary<string, Room>();
        public List<string> Items { get; set; } = new List<string>();
        public Dictionary<string, string> Actions { get; private set; }
        public int[,] RoomMap { get; private set; } // Stores ascii map reference array

        Tileset tileset = new Tileset();

        private int visitState = 1; // Tracks the number of visits to this room

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

            tileset.RenderDungeon(RoomMap);

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
            Room startRoom = new Room("Foyer", "A kinda spooky black and red hall with barely any lighting. These torches seem on their last legs.. or wick I suppose.");
            Room livingRoom = new Room("Living Room", "A room fully lit by table lamps. Seems kind of impractical.\nThe first thing you see upon entrance is a Victorian table painted darker than the inside of your head.");
            Room libraryRoom = new Room("Library", "A library filled with books of all kind, not that you would know how to read.\nIn your peripheral vision you can see an alchemy station.");
            Room bedRoom = new Room("Master bedroom", "A huge room fit for a king.\nYou notice all the stuffed animals on the pink frilly bed, seemingly reminicent of something you would have.");
            Room kitchenRoom = new Room("Kitchen", "A black and white tiled kitchen.\nYou see a singular apple on the marble island. Not that you've ever eaten something healthy.");

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
            startRoom.Items.Add("collar");
            startRoom.Items.Add("end");
            livingRoom.Items.Add("key");
            libraryRoom.Items.Add("potion");
            bedRoom.Items.Add("note");
            kitchenRoom.Items.Add("apple");
            kitchenRoom.Items.Add("milk");
            libraryRoom.Items.Add("gold");
            startRoom.Items.Add("rubies");
            livingRoom.Items.Add("emeralds");
            kitchenRoom.Items.Add("diamonds");



            // Add map arrays to rooms
            startRoom.RoomMap = new int[,]{
            { 03, 02, 00, 00, 00, 02, 04},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 06, 02, 02, 02, 02, 02, 05},
            };
            livingRoom.RoomMap = new int[,]{
            { 03, 00, 00, 02, 02, 02, 04},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 00},
            { 00, 00, 00, 00, 00, 00, 00},
            { 01, 00, 00, 00, 00, 00, 00},
            { 01, 00, 00, 00, 00, 00, 01},
            { 06, 02, 00, 00, 00, 02, 05},
            };
            libraryRoom.RoomMap = new int[,]{
            { 03, 02, 02, 02, 02, 02, 04},
            { 01, 00, 00, 00, 00, 00, 01},
            { 00, 00, 02, 02, 02, 00, 01},
            { 00, 00, 00, 00, 00, 00, 01},
            { 00, 00, 02, 02, 02, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 06, 02, 02, 02, 02, 02, 05},
            };
            bedRoom.RoomMap = new int[,]{
            { 03, 02, 02, 02, 02, 02, 04},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 00},
            { 01, 00, 00, 00, 00, 00, 01},
            { 06, 04, 02, 00, 00, 03, 05},
            { 00, 06, 02, 02, 02, 05, 00},
            };
            kitchenRoom.RoomMap = new int[,]{
            { 03, 02, 02, 02, 02, 02, 04},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 02, 02, 02, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 01, 00, 00, 00, 00, 00, 01},
            { 06, 00, 00, 02, 02, 02, 05},
            };

            // Adds Enemies to the rooms
            livingRoom.Enemies.Add("Spirit");
            kitchenRoom.Enemies.Add("Acid Worm");
            libraryRoom.Enemies.Add("Lich");
            bedRoom.Enemies.Add("Spirit");






            return startRoom; // Return the starting room
        }

        // Method to get the room description based on the visit state
        public string GetStateBasedDescription()
        {
            if (Name == "Kitchen")
            {
                switch (visitState)
                {
                    case 1:
                        return "A black and white tiled kitchen.\nYou see an apple on the counter as well as a smart-fridge with those big freezer drawers and everything. What time period is this?";
                    case 2:
                        return "You come back into the kitchen to find some cat-nip...\nYou're not sure what it's for but you just decide to pick it up.";
                    case 3:
                        return "When entering the room again you find an open can of Feline Feast on the marble counter.\nYou wonder if there's someone else in the dungeon with you.";
                    case 4:
                        return "After going back into the kitchen for more clues you find a piece of paper that says a few words on it.\nUpon further inspection you see it has the Hello Cat showtimes for today...\nIt makes you want to sit down and watch the show.";
                    case 5:
                        return "Upon your scramble for hints in the kitchen you see a cat collar that says 'Kitty' on it...\nYou decide to pick it up.";
                    case 6:
                        return "You hope to find another clue in the kitchen, one that would help more this time.\nWhen going in for the last time you decide to feel around to see if you can find ANYTHING that would help.\nYou feel a square dip on the oak China cabinet, it seems to resemble a button.\nYou decide to push it.\nIt opens up a dark room and you decide to go in.\nIn the room you see a picture of a mysterious and fuzzy stranger, it seems to be holding a... freshly hatched human.\nThe small being appears to have a set of pointy feline ears.\nWhile you were inspecting the dark room, you smell smoke.\nYou go to see what it is, and see a blaze of orange and yellow in front of you.\nIt seems to be coming from the stove...\nYou decide it's best to get out of there because the fire is destroying the room.";
                    default:
                        return "The kitchen seems unfamiliar. Are you lost?";
                }
            }
            else if (Name == "Master bedroom")
            {
                switch (visitState)
                {
                    case 1:
                        return "You enter a bedroom. Virtually everything including the ornate bed is colored pink, and Lich Kitty memorabilia can be seen everywhere you look.";
                    case 2:
                        return "You return to the gaudy pink bedroom. You forgot how offensive the decor is.";
                    case 3:
                        return "You return to the bedroom. Maybe you missed something.";
                    case 4:
                        return "You're back in the pink bedroom. Do you hate yourself?";
                    case 5:
                        return "There is nothing left for you here. Try something else.";
                    default:
                        return "The bedroom seems unfamiliar. Are you lost?";
                }
            }
            else if (Name == "Library")
            {
                switch (visitState)
                {
                    case 1:
                        return "You have entered the library. Accents of pink adorn each shelf.";
                    case 2:
                        return "You return to the place where one must read. READ.";
                    case 3:
                        return "You return to the place of books. Maybe you missed something Chicken Jockey.";
                    case 4:
                        return "You're back in the stacks. You could get lost here.";
                    case 5:
                        return "There is nothing left for you here. Try something else.";
                    default:
                        return "The library room seems unfamiliar. Are you lost?";
                }
            }
            else if (Name == "Living Room")
            {
                switch (visitState)
                {
                    case 1:
                        return "A room fully lit by table lamps. Seems kind of impractical.\nThe first thing you see upon entrance is a Victorian table painted darker than the inside of your head.";
                    case 2:
                        return "You head back into the living room. Could be a safe place to hide from any ghosts.";
                    case 3:
                        return "You go back to the living room. Not even a TV in here...";
                    case 4:
                        return "As you walk back into the living room you resist the urge to rub your feet on the shag carpeting";
                    case 5:
                        return "Nope, no ghosts in here... Why are you here again?";
                    default:
                        return "The library room seems unfamiliar. Are you lost?";
                }
            }

            // Default description for other rooms
            return Description;
        }

        // Method to increment the visit state
        public void IncrementVisitState()
        {
            if (visitState < 5)
            {
                visitState++;
            }
        }

        public override string ToString()
        {
            return GetStateBasedDescription();
        }
    }
}
