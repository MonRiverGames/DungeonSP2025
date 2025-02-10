// Player Class
using DungeonGame;

class Player
{
    public Room CurrentRoom { get; set; }
    public List<string> Inventory { get; set; }

    public Player(Room startingRoom)
    {
        CurrentRoom = startingRoom;
        Inventory = new List<string>();
    }

    public void Move(string direction)
    {
        if (CurrentRoom.Exits.ContainsKey(direction))
        {
            CurrentRoom = CurrentRoom.Exits[direction];
            Console.WriteLine("You moved to: " + CurrentRoom.Name);
        }
        else
        {
            Console.WriteLine("You can't go that way!");
        }
    }
}