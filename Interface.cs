using System;
using System.Collections.Generic;
using DungeonGame;
class Program
{ 
     static List<string> choices = new List<string>();

    static void Main()
    {
        bool keepPlaying = true; // Flag to control the game loop

        while (keepPlaying)
        {
            Console.WriteLine("Do you want to load a saved game? (yes/no)");
            Console.Write("> ");
            string loadGameChoice = (Console.ReadLine() ?? string.Empty).ToLower();

            if (loadGameChoice == "yes")
            {
                LoadGame();
            }
         else
            {
             StartNewGame();
            }

            // After the game ends, ask the player if they want to play again
            Console.WriteLine("\nDo you want to play again? (yes/no)");
            Console.Write("> ");
            string playAgainChoice = (Console.ReadLine() ?? string.Empty).ToLower();

            if (playAgainChoice.ToLower() != "yes")
            {
                keepPlaying = false; // Exit the loop if the player does not want to play again
                Console.WriteLine("Thanks for playing!");
            }
            else
            {
                Console.WriteLine("Starting a new game...");
            }
     }
 }

 // Placeholder method for loading a saved game
 static void LoadGame()
 {
      Console.WriteLine("Loading saved game...");
 }

 // Start a new game from the beginning
 static void StartNewGame()
 {
     Console.WriteLine("Starting a new game...");
     choices.Clear(); // Clears previous choices
 }
 
static class Graphics
{
    public static void Menu(Player player, string menuType = "default") // method for the menu
    {
        while(true)
        {
            if (menuType == "default") //if menuType is default (when the game is running), 1. will be Continue instead of start
            {
                Type(player.fastMode, "1. Continue", "green");
            }
            else if (menuType == "start") // if menuType is start menu, 1 will be start
            {
                Type(player.fastMode, "1. Start", "green");
            }
                Type(player.fastMode, "2. Toggle Fast Mode", "green");
                Type(player.fastMode, "3. The Story So Far...", "green");                
                Type(player.fastMode, "4. Save", "green");
                Type(player.fastMode, "5. Save and Quit", "green");
                Console.Write("\n> ");
                string input = Console.ReadLine() ?? string.Empty;
                input = input.ToLower(); //converts input to lowercase
                
                if (input.Contains("1") || input.Contains("continue")) //exits menu
                {
                    Type(player.fastMode, "You chose to continue.\n"); 
                    return;
                }
                else if (input.Contains("2") || input.Contains("fast")) //toggles fast mode
                {
                    player.fastMode = !player.fastMode;
                    Type(player.fastMode, player.fastMode ? "You're now in fast mode." : "You've turned off fast mode.");
                }
                else if (input.Contains("3") || input.Contains("story")) // reads out the story so far , should only be major story points
                {
                    Type(player.fastMode, "Here is what you've done so far!", "cyan");
                    //method for displaying the story beats, should be uploaded to log
                }
                else if (input.Contains("4") || input.Contains("save")) // saves the game
                {
                    Type(player.fastMode, "You saved your game.", "green");
                    //method for saving the game
                }
                else if (input.Contains("5") || input.Contains("quit"))
                {
                    Type(player.fastMode, "You have chose to quit the game. Press any key to exit."); // saves the game and then quits the program
                    //method for save
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Type(player.fastMode, "This is an invalid input."); // for invalid inputs
                }
        }
    }
    public static void Type(bool fastMode, string text, string color = "none", int sleep = 0, int delay = 30) // method allows for easy color switching and accounts for fast mode, modifable/optional sleep and delay features
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
                Console.ResetColor(); // Reset color only once before the loop.
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(delay); // Controls speed of the typing effect
                }
            }
        Console.ResetColor(); // Ensure color is reset after the loop.
    }
    static public void Sword()
    {
        Console.ForegroundColor = ConsoleColor.Blue;System.Console.WriteLine(@"            
                                     #-.                
                                  .@+@              
                                .:-:+.              
                              .--*:%                
                             #:@:%                  
                           %:%-+                    
                         =:+:+.                     
                       ..=-+#                       
                     .=-#:@                         
               .    %#@-*.                          
              #%=.@:#:+                             
              @@@@%:=*                              
              .%@@@@@.                              
             +*@%%@@@*                              
           .*#@#......                              
         .%@@*..                                    
          .=.                                       
    ");
    Console.ResetColor();
    }

    static public void Shield()
    {
        Console.ForegroundColor = ConsoleColor.Blue;System.Console.WriteLine(@"
                 .---==---       
            .------%##@.......   
         -----%#######%####@.:===   
        :--##=############%%%%%==:   
        .+-#==##########%%%%%%%=*    
        ..-#==#########%%%%%%%%+=    
         ..#+=########%%%%%%%%%==  
         ...#=####%##%%%%%%%%%+**    
         ...#+###%#%%%%%%%%%%%**:  
          ..#+#####%%%%%%%%%%%**  
           .--####%@%%%%@%%%+**.  
            :--.#%%@%%%%@%:**=  
               ++%+%@%%%%+%+*   
                 .++++++++    
                    ==     
    ");
    Console.ResetColor();
    }

    static public void Potion()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;System.Console.WriteLine(@"
               @***@               
               .***.               
              .@@+@@.              
               @:::@               
               .::::               
              :.:::::              
           ..@+=-+===@..           
           @++=+++=++.+@           
          #+.+==++++++ +#          
          :+ +++++++==++:          
          .:+++=++++++++.          
            %:@:::::+.@       
        ");
        Console.ResetColor();
    }

    public static void BookShelf()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;System.Console.WriteLine(@"
                                                                                                                       
         %%%%%%%                                                  %%%%%%%     %%%%%%%.        %%                  
       %%%%%%%%%%%                                                        + %%%%%%%%%%% %%%%%%%%%%                
       %%%%%%%%%+%                                               %        + %%%%%%%%% %%%%%%%%%%.%                
       %%       +%                                               %        + %%        % %%%%%%   %%               
       %%       +%                                               %%%%%%%% + %%        % %%      +-%               
       %%%%%%%%%+%                                               %        + %%%%%%%%% %  %%%%%%%%%%%              
       %%%%%%%%%+%                                               %        + %%%%%%%%% %  %+%%%%%%%=%              
       %%%%%%%%%+%                                               %        + %%%%%%%%% %  :%%%%%%%%%%%             
       %%%%%%%%%+%                                               %        + %%%%%%%%% %   %-%%%%%%%#%             
       %%%%%%%%%+%                                               %        + %%%%%%%%% %   +%%%%%%%%%%%            
       %%%%%%%%%+%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%     %        + %%%%%%%%% %    %:%%%%%%%%%            
       %%%%%%%%%+%   %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %        + %%%%%%%%% %    *%%%%%%%%%%%           
       %%%%%%%%%+%   %%%%%                              %%%%%    %        + %%%%%%%%% %     % %%%%%%%%%           
       %%%%%%%%%+%   %%%%%                              %%%%%    %        + %%%%%%%%% %     #%%%%%%%%%%%          
       %%%%%%%%%+%   %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %        + %%%%%%%%% %      % %%%%%%%%%          
       %%%%%%%%%+%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%     %        + %%%%%%%%% %      %%%%%%%%%@%%         
       %%%%%%%%%+%                                               %        + %%%%%%%%% %       % %%%%%%%%%         
       %%       +%                                          %    %        + %%        %       %%#       %%        
       %%.......+%                                          %    %%%%%%%% + %%....... %        %   %%%%%%%        
       %%%%%%%%%+%                                          %    %        + %%%%%%%%% %        %%%%%%%%%%%%       
       %%%%%%%%%%%                                          %             + %%%%%%%%%%%         %%%%%%%%%.        
         %%%%%%%      %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%       %%%%%%%     %%%%%%%.            %%              
                                                                                                                  
        ");
        Console.ResetColor();
    }

    
    public static void DrawHealthBar(string name, int currentHP, int maxHP)
    {
        int totalBlocks = 20;
        int filledBlocks = (int)((double)currentHP / maxHP * totalBlocks);
        string filledBar = new string('█', filledBlocks);
        string emptyBar = new string('-', totalBlocks - filledBlocks);
        string bar = filledBar + emptyBar;
        Console.WriteLine($"{name}: [{bar}] {currentHP}/{maxHP} HP");
    }
    public static void Title()
    {
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
    }
}
}