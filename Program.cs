/*
Dungeon Crawler Starter Code
This template provides the foundational structure for a text-based dungeon crawler.
*/
/* Test of Rules
*/
using DungeonGame;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
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
        List<Room> rooms = Room.InitializeRooms(); // Use the static method to set up rooms
        Tileset tileset = new Tileset(); // Create an instance of Tileset

        Console.Clear();
        GameData gameData = GameData.LoadGame(rooms);
        Player player = new Player(gameData);
        Room.InitializeItems(rooms, gameData);
        
        // Name prompt only runs if gameData is not resuming a save file
        if (!gameData.IsResuming)
        {
            Console.WriteLine("What is your name?");
            string Name;
            while (true)
            {
                Name = Console.ReadLine() ?? string.Empty;
                if (Name == null)
                {
                    Console.WriteLine("Input stream closed. Exiting...");
                    return;
                }
                if (!string.IsNullOrEmpty(Name))
                {
                    gameData.PlayerName = Name;
                    break;
                }
                Console.WriteLine("Name cannot be empty. Please enter your name:");
            }
            player.ClassChoice();
        }
        else
        {
            // Reset the game if the player chooses not to resume
            GameData.ResetGame();
            gameData = new GameData();
            gameData.CurrentRoom = rooms.Find(room => room.Name == "Foyer");
            gameData.PlayerInventory = new Inventory(); // Ensure a new inventory is created
            player = new Player(gameData);
        }
        
        System.Console.WriteLine();

        Graphics.Type(player.fastMode, "Welcome to..."); //temporary name
        Graphics.Title();
        Graphics.Menu(player, "start");
        if (!gameData.IsResuming) Graphics.Prolouge(player); // Prolouge only plays if gameData is not resuming a save file
        //Graphics.Type(player.fastMode, "Type 'go north', 'go south', 'go east', or 'go west' to move in any of the cardinal directions.");

        while (true)
        {
            if (gameData.PlayerInventory.Contains("end"))
            {
                gameData.EndingUnlocked = true;
            }
            GameData.SaveGame(gameData); // Saves the game at the the start of command loop
            Console.Write("\n> ");
            string input = Console.ReadLine() ?? string.Empty;
            if (input == null)
            {
                Graphics.Type(player.fastMode, "Input stream closed. Exiting...");
                return;
            }
            input = input.ToLower(); //detects player input
            string[] command = input.Split(' '); // splits the input into two separate inputs (command) to create an array within command

            if (moveCommand.Contains(command[0])) // if the first word (command[0]) is any of the movement words, then the following body of code will excute
            {
                player.Move(command[1]); // Removed redundant player parameter.
                
                if (gameData.EndingUnlocked == true && gameData.CurrentRoom.Name == "Living Room") // intiates game ending
                {
                    Graphics.Type(player.fastMode, "A small kitty walks out from the corner of the room. It stands and stares into your soul.");

                    if (gameData.PlayerInventory.Contains("collar")) // enables route 1 ending
                    {
                        Graphics.Type(player.fastMode, "It notices that you have a collar clipped onto your belt.");
                        Graphics.Type(player.fastMode, "Slowly, the kitty creeps up to you.");
                        Graphics.Type(player.fastMode, "Beady eyes peer into your soul.");
                        Graphics.Type(player.fastMode, "A soft paw brushes up against your hand, as if it's asking for something.");

                        if (gameData.PlayerInventory.Contains("milk")) // good ending
                        {
                            Graphics.Type(player.fastMode, "You offer it the milk you found in the kitchen");
                            Graphics.Type(player.fastMode, "It bows down and accepts you as a apprentice.");
                            Graphics.Type(player.fastMode, "Congratulations! You got the good ending!How boring...", "green");
                            Graphics.Type(player.fastMode, "Press any key to quit.", "green");
                            Console.ReadKey();
                            Environment.Exit(0);                                                  
                        }
                        else // bad ending
                        {
                            Graphics.Type(player.fastMode, "You have nothing else to offer to Lich Kitty");
                            Graphics.Type(player.fastMode, "It seems disappointed and ushers you to the door.");
                            Graphics.Type(player.fastMode, "You watch as Lich Kitty puts out the fires you started, and you decide that you've disappointed it.");
                            Graphics.Type(player.fastMode, "You leave the house.");
                            Graphics.Type(player.fastMode, "You got the ok ending. Do better...", "green");
                            Graphics.Type(player.fastMode, "Press any key to quit.", "green");
                            Console.ReadKey();
                            Environment.Exit(0);                                                  
                        }
                    }

                    else // worst ending
                    {
                    Graphics.Type(player.fastMode, "It thinks of you as a sneaky scoundrel and startles you with a sassy, squinty, slightly suspicious stare.");
                    Graphics.Type(player.fastMode, "All of a sudden, it barrels towards you."); 
                    Enemy LichKitty = new LichKitty(default, default); // create Lich Kitty 
                    Enemy.Battle(LichKitty, player); 
                    //if player wins the battle, this happens v
                    Graphics.Type(player.fastMode, "You peer down the lifeless soul of Lich Kitty.", "red", 200, 50);
                    Graphics.Type(player.fastMode, "GAME OVER. AHAHAHA", "red", 200, 50);      
                    Graphics.Type(player.fastMode, "Press any key to quit.", "green");
                    Console.ReadKey();             
                    Environment.Exit(0);                                                  
                    }
                } 
            }

            else if (input == "menu") // if the first word (command[0]) is any of the movement words, then the following body of code will excute
            {
                Graphics.Menu(player); //method that accepts the inputted value and then excutes for whatever happens
            }
            
            else if (input == "help") // if the first word (command[0]) is any of the movement words, then the following body of code will excute
            {
                Graphics.Help(player); //method that accepts the inputted value and then excutes for whatever happens
            }

            else if (grabCommand.Contains(command[0])) // grab method
            {
                if (!string.IsNullOrEmpty(command[1]) && gameData.CurrentRoom.Items.Contains(command[1]))
                {
                    if (!gameData.PlayerInventory.Contains(command[1])) // if the player doesn't have the item, they are able to grab the item
                    {
                        gameData.PlayerInventory.AddItem(command[1]);
                        gameData.CurrentRoom.Items.Remove(command[1]);
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
            
            else if (fightCommand.Contains(command[0])) // fight method
            {
                if (gameData.CurrentRoom.Name == "Kitchen")
                {
                Graphics.Type(player.fastMode, "The apple contains a terrible curse. From its core springs an Acid Worm."); //this is a temporary example of the battle function
                Enemy AcidWorm = new AcidWorm(default, default); // create acid worm
                Enemy.Battle(AcidWorm, player);  //method to initiate battle
                }
            }

             else if (fightCommand.Contains(command[0])) // fight method
            {
                if (gameData.CurrentRoom.Name == "Bedroom")
                {
                Graphics.Type(player.fastMode, "The master of this household rises in an etheral form"); //battle function
                Graphics.Type(player.fastMode, "and begins to attack you with a barrage of pillows."); //
                Enemy Spirit = new Spirit(default, default); // create spirit
                Enemy.Battle(Spirit, player);  //method to initiate battle
                }
            }

            else if (talkCommand.Contains(command[0])) // talk method
            {
                if (gameData.CurrentRoom.Name == "Kitchen")
                {
                    Console.WriteLine("You see a wrinkly lych sitting by the stove. He seems to be petting one of those white rat dogs.\nHe smiles at you as his dog gives you THAT stare and asks:");
                    Console.WriteLine("'Welcome, adventurer. Would you like to pet my sickly pup? His name is Coconut.\nOh! Also, why are you here?'");
                    Console.WriteLine("'Take this key, I believe it's supposed to help you.'");
                    if (!gameData.PlayerInventory.Contains("key")) //if the player doesn't have the item, they are able to grab the item
                    {
                        gameData.PlayerInventory.AddItem("key");
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

            else if (examineCommand.Contains(command[0])) // look method
            {
                Console.WriteLine($"Room: {gameData.CurrentRoom.Name}"); // Display the room name
                Console.WriteLine(gameData.CurrentRoom.GetStateBasedDescription()); // Display state-based description

                Console.WriteLine("\nItems in this room:");
                if (gameData.CurrentRoom.Items.Count > 0)
                {
                    foreach (var item in gameData.CurrentRoom.Items)
                    {
                        Console.WriteLine($"- {item}");
                    }
                }
                else
                {
                    Console.WriteLine("None.");
                }

                Console.WriteLine("\nExits:");
                foreach (var exit in gameData.CurrentRoom.Exits.Keys)
                {
                    Console.WriteLine($"- {exit}");
                }

                Console.WriteLine("\nRoom Map:");
                tileset.RenderDungeon(gameData.CurrentRoom.RoomMap); // Render the relevant tile map for the current room

                gameData.CurrentRoom.IncrementVisitState(); // Increment the visit state for the room
            }

            else if (useCommand.Contains(command[0])) // use method
            {
                if (!gameData.PlayerInventory.Contains(command[1]) /*&& !Room.Objects.Contains(command[1])*/)  // if the target doesn't exist in the inventory and the room, then it will return a invalid message || currently has the room objects checker OFF
                {
                    Graphics.Type(player.fastMode, "You can't use this because you don't have it!");
                }
                else if (gameData.PlayerInventory.Contains(command[1])) //if player has the item, they are able to use it
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

            else if (command.Length > 1 && inventoryCommand.Contains(command[0])) // check inventory
            {
                gameData.PlayerInventory.ShowInventory();
            }

            else if (input == "quit") //if the input is 'quit', then the game will break the continuous loop
            {
                Graphics.Type(player.fastMode, "Until we meet again...!\n");
                break;
            }

            else
            {
                Graphics.Type(player.fastMode, "Invalid command.\n", "green");
                Graphics.Type(player.fastMode, "that's too bad! It's not like there's some convenient 'help' command or anything.'\n", "green");
            }
        }
    }
}

