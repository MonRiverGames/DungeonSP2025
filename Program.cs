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
    static string[] moveCommand = { "go", "explore", "travel", "move" }; //array of movement commands
    static string[] grabCommand = { "get", "grab", "take" }; //array of grab commands

    static string[] useCommand = { "use", "utilize", "operate" }; //array of use commands
    static string[] inventoryCommand = { "bag", "inventory", "backpack", "pockets", "items" }; // array of inventory commands

    static string[] fightCommand = { "fight", "punch", "probe", "kick", "annoy", "stab", "flick", "kill", "touch", "slap", "hurt", "yell", "splash", "poke", "shoot" }; //array of fight commands

    static string[] talkCommand = { "talk", "speak", "greet", "address", "say", "hi", "hello", "hey" }; //array of talk commands

    static string[] examineCommand = { "look", "check", "examine", "inspect", "view", "find", "investigate", "scan", "survey" }; //array of examine commands

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
        mirrorRoom.Exits["west"] = darkRoom;

        // Add Items to Rooms
        startRoom.Items.Add("torch");
        darkRoom.Items.Add("key"); 
        mirrorRoom.Items.Add("mirror shard");

        Console.WriteLine("What is your name adventurer?");
        string playerName;
        while (true)
        {
            playerName = Console.ReadLine() ?? string.Empty;
            if (playerName == null)
            {
                Console.WriteLine("Input stream closed. Exiting...");
                return;
            }
            if (!string.IsNullOrEmpty(playerName))
            {
                break;
            }
            Console.WriteLine("Name cannot be empty. Please enter your name:");
        }
        Player player = new Player(playerName, startRoom); // Pass both playerName and startRoom
        Graphics.Type(player.fastMode, $"Welcome {player.Name}!");
        Graphics.Type(player.fastMode, "Welcome to..."); //temporary name
        Graphics.Title();
        Graphics.Type(player.fastMode, "Type 'go north', 'go south', 'go east', or 'go west' to move in any of the cardinal directions.");
        Graphics.Menu(player, "start");

       // Game Loop!
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine() ?? string.Empty;
            if (input == null)
            {
                Graphics.Type(player.fastMode, "Input stream closed. Exiting...");
                return;
            }
            input = input.ToLower(); //detects player input
            string[] command = input.Split(' '); // splits the input into two separate inputs (command) to create an array within command

            if (command.Length > 1 && moveCommand.Contains(command[0])) // if the first word (command[0]) is any of the movement words, then the following body of code will excute
            {
                player.Move(command[1]); // Removed redundant player parameter.
            }

            else if (input == "menu") // if the first word (command[0]) is any of the movement words, then the following body of code will excute
            {
                Graphics.Menu(player); //method that accepts the inputted value and then excutes for whatever happens
            }
            else if (command.Length > 1 && grabCommand.Contains(command[0]))
            {
                if (!string.IsNullOrEmpty(command[1]) && player.CurrentRoom.Items.Contains(command[1]))
                {
                    if (!player.Inventory.Contains(command[1])) // if the player doesn't have the item, they are able to grab the item
                    {
                        player.Inventory.AddItem(command[1]);
                        player.CurrentRoom.Items.Remove(command[1]);
                    }
                    else
                    {
                        Graphics.Type(player.fastMode, "You already have this item!");
                    }
                }
                else
                {
                    Graphics.Type(player.fastMode, $"There is no {command[1]} here to grab.");
                }
            }
            
            else if (command.Length > 1 && fightCommand.Contains(command[0]))
            {
                Graphics.Type(player.fastMode, "This is a test battle."); //this is a temporary example of the battle function
                Enemy AcidWorm = new AcidWorm(default, default); // create acid worm
                Room.Battle(AcidWorm, player);  //method to initiate battle
            }
            else if (command.Length > 1 && talkCommand.Contains(command[0]))
            {
                //player.Talk(command[1]);  this is for dialogue options (delete slashes & modify)
            }
            else if (command.Length > 1 && examineCommand.Contains(command[0]))
            {
                //player.Examine(command[1]);  this is for examining areas/objects (delete slashes & modify)
            }
            else if (command.Length > 1 && useCommand.Contains(command[0]))
            {
                if (!player.Inventory.Contains(command[1]) /*&& !Room.Objects.Contains(command[1])*/)  // if the target doesn't exist in the inventory and the room, then it will return a invalid message || currently has the room objects checker OFF
                {
                    Graphics.Type(player.fastMode, "You can't use this. It doesn't exist.");
                }
                else if (player.Inventory.Contains(command[1])) //if player has the item, they are able to use it
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
                    Graphics.Type(player.fastMode, "Invalid use command."); //placeholder text
                }
            }

            else if (command.Length > 1 && inventoryCommand.Contains(command[0]))
            {
                player.Inventory.ShowInventory();
            }

            else if (input == "talk") // Story-driven interaction test case of loop
            {
                if (player.CurrentRoom.Name == "Entrance Hall")
                {
                    Graphics.Type(player.fastMode, "You see a wrinkly lych sitting by the fire. He smiles mischeviously at you and says:");
                    Graphics.Type(player.fastMode, "'Welcome, adventurer. You sure you want to be here?'");
                    Graphics.Type(player.fastMode, "'Take this key, if you dare to enter.'");
                    if (!player.Inventory.Contains("key")) //if the player doesn't have the item, they are able to grab the item
                    {
                        player.Inventory.AddItem("key");
                        Graphics.Type(player.fastMode, "You received a key!");
                    }
                    else
                    {
                        Graphics.Type(player.fastMode, "You already have a key.");
                    }
                }
                else
                {
                    Graphics.Type(player.fastMode, "There is no one here to talk to.");
                }
            }

            else if (input == "quit") //if the input is 'quit', then the game will break the continuous loop
            {
                Graphics.Type(player.fastMode, "Until we meet again...!");
                break;
            }

            else
            {
                Graphics.Type(player.fastMode, "Invalid command.");
            }
        }
    }
}

