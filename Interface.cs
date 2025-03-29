using System;
using DungeonGame;

static class Graphics
{
    public static void Menu(Player player, string menuType = "default") // method for the menu
    {
        while(true)
        {
            if (menuType == "default") //if menuType is default (when the game is running), 1. will be Continue instead of start
            {
                TypeEffectColor(player.fastMode, "1. Continue", "green");
            }
            else if (menuType == "start") // if menuType is start menu, 1 will be start
            {
                TypeEffectColor(player.fastMode, "1. Start", "green");
            }
                TypeEffectColor(player.fastMode, "2. Toggle Fast Mode", "green");
                TypeEffectColor(player.fastMode, "3. The Story So Far...", "green");                
                TypeEffectColor(player.fastMode, "4. Save", "green");
                TypeEffectColor(player.fastMode, "5. Save and Quit", "green");
                Console.Write("\n> ");
                string input = Console.ReadLine() ?? string.Empty;
                input = input.ToLower(); //converts input to lowercase
                
                if (input.Contains("1") || input.Contains("continue")) //exits menu
                {
                    TypeEffectColor(player.fastMode, "You chose to continue.\n"); 
                    return;
                }
                else if (input.Contains("2") || input.Contains("fast")) //toggles fast mode
                {
                    player.fastMode = !player.fastMode;
                    TypeEffectColor(player.fastMode, player.fastMode ? "You're now in fast mode." : "You've turned off fast mode.");
                }
                else if (input.Contains("3") || input.Contains("story")) // reads out the story so far , should only be major story points
                {
                    TypeEffectColor(player.fastMode, "Here is what you've done so far!", "cyan");
                    //method for displaying the story beats, should be uploaded to log
                }
                else if (input.Contains("4") || input.Contains("save")) // saves the game
                {
                    TypeEffectColor(player.fastMode, "You saved your game.", "green");
                    //method for saving the game
                }
                else if (input.Contains("5") || input.Contains("quit"))
                {
                    TypeEffectColor(player.fastMode, "You have chose to quit the game. Press any key to exit."); // saves the game and then quits the program
                    //method for save
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    TypeEffectColor(player.fastMode, "This is an invalid input."); // for invalid inputs
                }
        }
    }
    public static void TypeEffectColor(bool fastMode, string text, string color = "none", int sleep = 0, int delay = 30) // method allows for easy color switching and accounts for fast mode, modifable/optional sleep and delay features
    {
        if(fastMode == true) // if fast mode is on, it will remove the delay and sleep no matter then input
        {
            delay = 0;
            sleep = 0;
        }

        Console.WriteLine();
        Thread.Sleep(sleep);

            if (color == "magenta") //depending on what is inputted from the computer, it will change the text color of the important verbs
            {
                foreach (char c in text)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(c);
                    Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
            else if (color == "yellow")
            {
                foreach (char c in text)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(c);
                    Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
            else if (color == "cyan")
            {
                foreach (char c in text)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(c);
                    Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
            else if (color == "green")
            {
                foreach (char c in text)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                    Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
            else if (color == "red")
            {
                foreach (char c in text)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c);
                    Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
            else if(color == "none")
            {
                foreach (char c in text)
                {
                Console.ResetColor();
                Console.Write(c);
                Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
            else
            {
                foreach (char c in text)
                {
                Console.ResetColor();
                Console.Write(c);
                Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
        Console.ResetColor();
    }
    static public void Sword()
    {
        Console.ForegroundColor = ConsoleColor.Blue;System.Console.WriteLine(@"            
             █      
            ██      
           ███      
          ███       
          ███       
         ███        
         ██         
        ███         
    ██  ██          
       █████        
      ███           
      ██            
                 
    ");

    }
}