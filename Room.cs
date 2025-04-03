namespace DungeonGame
{
    // Room Class
    class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Room> Exits { get; set; }
        public List<string> Events { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Room>();
            Events = new List<string>();
        }

        public void Enter()
        {
            Console.WriteLine($"{Name}: {Description}");
            TriggerEvents();
        }

        private void TriggerEvents()
        {
            foreach (var roomEvent in Events)
            {
                Console.WriteLine($"Event Triggered: {roomEvent}");
            }
        }
    }

    // Player Class
    class Player
    {
        public string Name { get; set; }
        public Room CurrentRoom { get; private set; }

        public Player(string name, Room startingRoom)
        {
            Name = name;
            CurrentRoom = startingRoom;
        }

        public void MoveTo(string direction)
        {
            if (CurrentRoom.Exits.TryGetValue(direction, out Room nextRoom))
            {
                CurrentRoom = nextRoom;
                CurrentRoom.Enter();
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }
        }
    }

    // Example Usage
    class Program
    {
        static void Main()
        {
            Room hall = new Room("Hall", "A vast and echoing chamber.");
            Room dungeon = new Room("Dungeon", "A dark, cold prison cell.");

            hall.Exits["down"] = dungeon;
            dungeon.Exits["up"] = hall;

            dungeon.Events.Add("You hear chains rattling in the darkness.");

            Player player = new Player("Explorer", hall);
            player.CurrentRoom.Enter();

            player.MoveTo("down"); // Triggers dungeon event
        }
    }
}
