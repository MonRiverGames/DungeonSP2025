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

        // Debugging: Print room details to ensure no circular references
        startRoom.PrintRoomDetails();
        darkRoom.PrintRoomDetails();
        mirrorRoom.PrintRoomDetails();

        Console.WriteLine("Welcome to the Dungeon Crawler!");
        Console.WriteLine("What is your name adventurer?");
        string playerName;
        while (true)
        {
            playerName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrEmpty(playerName))
            {
                break;
            }
            Console.WriteLine("Name cannot be empty. Please enter your name:");
        }
        Player player = new Player(playerName, startRoom);  // Read response and create Player
        Console.WriteLine($"Welcome {player.Name}!");
        Graphics.TypeEffectColor(player.fastMode, "Welcome to..."); //temporary name
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine();
        Thread.Sleep(100);System.Console.WriteLine(@" _   _         _  _          _   __ _");
        Thread.Sleep(100);System.Console.WriteLine(@"| | | |  ___  | || |  ___   | | / /(_)  _     _");
        Thread.Sleep(100);System.Console.WriteLine(@"| |_| | / _ \ | || | / _ \  | |/ /  _ _| |_ _| |_  _  _");
        Thread.Sleep(100);System.Console.WriteLine(@"|  _  |/ /_\ \| || |/ / \ \ |   /  | |_   _|_   _|| |/ /");
        Thread.Sleep(100);System.Console.WriteLine(@"| | | |\ ,___/| || |\ \_/ / | |\ \ | | | |_  | |_ | / /");
        Thread.Sleep(100);System.Console.WriteLine(@"|_| |_| \___/ |_||_| \___/  |_| \_\|_| \___| \___||  /");
        Thread.Sleep(100);System.Console.WriteLine(@"                       _           _              / /");
        Thread.Sleep(100);System.Console.WriteLine(@"                      / \_______ /|_\             \/");
        Thread.Sleep(100);System.Console.WriteLine(@"                     /          /_/ \__");
        Thread.Sleep(100);System.Console.WriteLine(@"                    /             \_/ /");
        Thread.Sleep(100);System.Console.WriteLine(@"                  _|_              |/|_");
        Thread.Sleep(100);System.Console.WriteLine(@"                  _|_  O    _    O  _|_");
        Thread.Sleep(100);System.Console.WriteLine(@"                  _|_      (_)      _|_");
        Thread.Sleep(100);System.Console.WriteLine(@"                   \                 /");
        Thread.Sleep(100);System.Console.WriteLine(@"                    _\_____________/_");
        Thread.Sleep(100);System.Console.WriteLine(@"                   /  \/  (___)  \/  \");
        Thread.Sleep(100);System.Console.WriteLine(@"                   \__(  o     o  )__/");
        Thread.Sleep(100);System.Console.WriteLine(@"      ___     _                 _             ");        
        Thread.Sleep(100);System.Console.WriteLine(@"     |_ _|___| | __ _ _ __   __| |            ");
        Thread.Sleep(100);System.Console.WriteLine(@"      | |/ __| |/ _` | '_ \ / _` |                ");    
        Thread.Sleep(100);System.Console.WriteLine(@"      | |\__ \ | (_| | | | | (_| |                   "); 
        Thread.Sleep(100);System.Console.WriteLine(@"     |___|___/_|\__,_|_| |_|\__,_|_                  ");
        Thread.Sleep(100);System.Console.WriteLine(@"       / \   __| |_   _____ _ __ | |_ _   _ _ __ ___ ");
        Thread.Sleep(100);System.Console.WriteLine(@"      / _ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \");
        Thread.Sleep(100);System.Console.WriteLine(@"     / ___ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/");
        Thread.Sleep(100);System.Console.WriteLine(@"    /_/   \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|");
        System.Console.WriteLine();
        Console.ResetColor();
        System.Console.WriteLine();
        Console.WriteLine("Type 'go north', 'go south', 'go east', or 'go west' to move in any of the cardinal directions.");
        Graphics.Menu(player, "start");

       // Game Loop!
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine() ?? string.Empty;
            input = input.ToLower(); //detects player input
            string[] command = input.Split(' '); // splits the input into two separate inputs (command) to create an array within command

            if (command.Length > 1 && moveCommand.Contains(command[0])) // if the first word (command[0]) is any of the movement words, then the following body of code will excute
            {
                player.Move(command[1], player); //method that accepts the inputted value and then excutes for whatever happens
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
                        Console.WriteLine("You already have this item!");
                    }
                }
                else
                {
                    Console.WriteLine($"There is no {command[1]} here to grab.");
                }
            }
            else if (command.Length > 1 && fightCommand.Contains(command[0]))
            {
                //player.Fight(command[1]);  this can be used for a fighting method, delete slashes and modify when needed 
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
                    System.Console.WriteLine("You can't use this. It doesn't exist.");
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
                    System.Console.WriteLine("Invalid use command."); //placeholder text
                }
            }

            else if (command.Length > 1 && inventoryCommand.Contains(command[0]))
            {
                player.Inventory.ShowInventory();
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