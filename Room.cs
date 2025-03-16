using System.ComponentModel.Design;

namespace DungeonGame;
// Room Class
class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, Room> Exits { get; set; }

    public Room(string name, string description)
    {
        Name = name;
        Description = description;
        Exits = new Dictionary<string, Room>();

    

        Room Caverns = new Room("Creepy Caverns", "A dark cave with dripping stalactites.");

        {
            Exits["forward"]= Caverns;
      
                Console.WriteLine("You are in: Creepy Caverns");
                Console.WriteLine(Caverns.Description);

            string direction = "forward";

            if (direction == "forward") 
            {
                Console.WriteLine("You have found a sword!");
            }
            else
            {
                Console.WriteLine("Not allowed to go that way.");
            }


        }




    }
}