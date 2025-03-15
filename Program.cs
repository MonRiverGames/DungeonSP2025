/*
Dungeon Crawler Starter Code
This template provides the foundational structure for a text-based dungeon crawler.
*/
/* Test of Rules
*/
using DungeonGame;
using System;
using System.Collections.Generic;
// Main Program
class Program
{
    static string [] moveCommand = { "go", "explore", "travel", "move" }; //array of movement commands
    static string [] grabCommand = { "get", "grab", "take" }; //array of grab commands

    static string [] useCommand = { "use", "utilize", "operate" }; //array of use commands
    static string [] inventoryCommand = { "bag", "inventory", "backpack", "pockets", "items"}; // array of inventory commands

    static string [] fightCommand = { "fight", "punch", "probe", "kick", "annoy", "stab", "flick", "kill", "touch", "slap", "hurt", "yell", "splash", "poke", "shoot" }; //array of fight commands

    static string [] talkCommand = { "talk", "speak", "greet", "address", "say", "hi", "hello", "hey" }; //array of talk commands

    static string [] examineCommand = { "look", "check", "examine", "inspect", "view", "find", "investigate", "scan", "survey" }; //array of examine commands

    // To make change to cloud branch, work locally and save. Then, commit to branch --> push to branch (don't push at the same time!) Then, other person pulls to stay up to date.
    static void Main()
    {
        // Initialize Rooms
        Room startRoom = new Room("Entrance Hall", "A grand entrance with torches lining the walls.");
        Room darkRoom = new Room("Dark Chamber", "A pitch-black room with an eerie silence.");
        Room mirrorRoom = new Room("Mirror Room", "A room filled with mirrors in every direction.");

        // Connect Rooms
        startRoom.Exits["north"] = darkRoom;
        darkRoom.Exits["south"] = startRoom;
        darkRoom.Exits["east"] = mirrorRoom;

        // Create Player
        Player player = new Player(startRoom);

        Console.WriteLine("Welcome to the Dungeon Crawler!");
        Console.WriteLine("Type 'go north' to move north or 'go south' to move south or 'go east' to move east.");

        // Game Loop!
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine().ToLower(); //detects player input
            string[] command = input.Split(' '); // splits the input into two separate inputs (command) to create an array within command

            if (command.Length > 1 && moveCommand.Contains(command[0])) // if the first word (command[0]) is any of the movement words, then the following body of code will excute
            {
                player.Move(command[1]); //method that accepts the inputted value and then excutes for whatever happens
            }

            else if (command.Length > 1 && grabCommand.Contains(command[0]))
            {
                if(!player.Inventory.Contains(command[1])) // if the player doesn't have the iten, they are able grab the item
                {
                //grab method executes
                //  player.Grab(command[1]);
                }
                else if (player.Inventory.Contains(command[1])) // if player has item, game tells them that they already have the item
                {
                    System.Console.WriteLine("You already have this item!");
                }
                else
                {
                    System.Console.WriteLine($"You can't pick up {command[1]}.");
                }
            }

            else if (command.Length >1 && fightCommand.Contains(command[0]))
            {
                //player.Fight(command[1]);  this can be used for a fighting method, delete slashes and modify when needed 
            }
            else if (command.Length >1 && talkCommand.Contains(command[0]))
            {
                //player.Talk(command[1]);  this is for dialogue options (delete slashes & modify)
            }
            else if (command.Length >1 && examineCommand.Contains(command[0]))
            {
                //player.Examine(command[1]);  this is for examining areas/objects (delete slashes & modify)
            }
            else if (command.Length > 1 && useCommand.Contains(command[0]))
            {
                if(!player.Inventory.Contains(command[1]) /*&& !Room.Objects.Contains(command[1])*/)  // if the target doesn't exist in the inventory and the room, then it will return a invalid message || currently has the room objects checker OFF
                {
                    System.Console.WriteLine("You can't use this. It doesn't exist.");
                }
                else if(player.Inventory.Contains(command[1])) //if player has the item, they are able to use it
                {
                    // use object method goes here
                }
                /* //if the room has the object, they are able to use it | separate method
                else if(Room.Objects.Contains(command[1]) 
               {
                    // use room object method goes here
                }*/
                else
                {
                    System.Console.WriteLine("Invalid use command."); //placeholder text
                }
            }
            
            else if (command.Length > 1 && inventoryCommand.Contains(command[0]))
            {
                // inventory loop goes here
            }

            else if (input == "quit") //if the input is 'quit', then the game will break the continuous loop
            {
                Console.WriteLine("Until we meet again...!");
                break;
            }
            else if (input == "menu")
            {
                //method for menu goes here
            }

            else
            {
                Console.WriteLine("Invalid command.");
            }
        } 
    }
}

