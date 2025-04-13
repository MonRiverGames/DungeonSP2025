using Microsoft.Win32.SafeHandles;
using System.Text.Json;

var PlayerSave = new
{
    Player = new
    {
        Class = PlayerClass,
        Health = Health
    }
};

string jsonString = JsonSerializer.Serialize(playerData);
Console.WriteLine(jsonString);

namespace DungeonGame;

// Player Class
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



    static int Health = 10;
    static String PlayerClass = "Unset";
    static void ClassChoice()
    {
        Console.WriteLine("Choose a Class, this can determine your healthpoints as well as skills and abilities.");
        Console.WriteLine("1: Knight: Heavy Armor & Heavy Weapons. Health = 20");
        Console.WriteLine("2: Rogue: Light Armor & Small Weapons. Health = 12");
        Console.WriteLine("3: Wizard: Staffs & Damaging Magic/Spells. Health = 10");
        Console.WriteLine("4: Cleric: Healing Spells & Blunt Weapons. Health = 15");

        int classChoice;
        while (true)
        {
            Console.Write("Choose a class from 1-4");
            if (int.TryParse(Console.ReadLine(), out classChoice) && classChoice >= 1 && classChoice <= 4)
            {
                switch (classChoice)
                {
                    case 1:
                        Console.WriteLine("Knight");
                        Health = 20;
                        break;
                    case 2: 
                        Console.WriteLine("Rogue");
                        Health = 12;
                        break;
                    case 3:
                        Console.WriteLine("Wizard");
                        Health = 10;
                        break;
                    case 4:
                        Console.WriteLine("Cleric");
                        Health = 15;
                        break;
                }
                Console.WriteLine($"You chose: {PlayerClass} with {Health} HP.");
                break;
            }

            else
            {
            Console.WriteLine("Invalid choice, please enter a number between 1 and 4.");
            }


            
        }
    }

    static void PlayerHealthCheck()
    {
        Console.WriteLine("Your health is: " + Health);
    }


    static void DeathCheck(Health) //this check should be ran after every turn in combat
    {

        while (true)
        {
            if (Health == 0)
            {
                 DeathScene(); //placeholder
            }
            else 
            {
                break;
            }

 

        }
    }
}