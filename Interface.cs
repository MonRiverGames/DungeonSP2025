using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonGame
{
    public class Graphics
    {
        public static void Menu(Player player, string menuType = "default") // method for the menu
        {
            while (true)
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
                
                if (menuType == "default")
                {
                Type(player.fastMode, "3. The Story So Far...", "green");
                Type(player.fastMode, "4. Save", "green");
                Type(player.fastMode, "5. Save and Quit", "green");
                }

                if (menuType == "start")
                {
                Type(player.fastMode, "3. Quit", "green");
                }

                Console.Write("\n> ");
                string input = Console.ReadLine() ?? string.Empty;
                input = input.ToLower(); //converts input to lowercase

                if (menuType == "default")
                {
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

                if (menuType == "start")
                {
                    if (input.Contains("1") || input.Contains("continue")) //exits menu
                    {
                        Type(player.fastMode, "You chose to start your adventure.\n");
                        return;
                    }
                    else if (input.Contains("2") || input.Contains("fast")) //toggles fast mode
                    {
                        player.fastMode = !player.fastMode;
                        Type(player.fastMode, player.fastMode ? "You're now in fast mode." : "You've turned off fast mode.");
                    }
                    else if (input.Contains("3") || input.Contains("quit"))
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
        }
        public static void Type(bool fastMode, string text, string color = "none", int sleep = 0, int delay = 30) // method allows for easy color switching and accounts for fast mode, modifable/optional sleep and delay features
        {
            if (fastMode == true) // if fast mode is on, it will remove the delay and sleep no matter then input
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
            else if (color == "none")
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
        public void Sword()
        {
            Console.ForegroundColor = ConsoleColor.Blue; System.Console.WriteLine(@"            
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

        public void Shield()
        {
            Console.ForegroundColor = ConsoleColor.Blue; System.Console.WriteLine(@"
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

        public void Potion()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta; System.Console.WriteLine(@"
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

        public void BookShelf()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; System.Console.WriteLine(@"
                                                                                                                       
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


        public void DrawHealthBar(string name, int currentHP, int maxHP)
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
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\n");
            Thread.Sleep(100); System.Console.WriteLine(@" ░      █   ░   █      ░     ██▓     ██▓ ▄████▄   ██░ ██     ██ ▄█▀ ██▓▄▄▄█████▓▄▄▄█████▓▓██   ██▓ ██ ██████ ");
            Thread.Sleep(100); System.Console.WriteLine(@" ░     █    █    █     ░    ▓██▒    ▓██▒▒██▀ ▀█  ▓██░ ██▒    ██▄█▒ ▓██▒▓  ██▒ ░▒▓  ██▒ ░▒ ▒██  ██ ██▒▒██    ▒ ");
            Thread.Sleep(100); System.Console.WriteLine(@"      ░░█   ▓    █ ░        ▒██░    ▒██▒▒▓█    ▄ ▒██▀▀██░   ▓███▄░ ▒██▒▒ ▓██░ ▒░▒ ▓██░ ▒░  ▒██ ██░░     ▓██▄   ");
            Thread.Sleep(100); System.Console.WriteLine(@"   ░░░   █ █▓█▓ █   ░░      ▒██░    ░██░▒▓▓▄ ▄██▒░▓█ ░██    ▓██ █░ ░██░░ ▓██░ ░ ░ ▓██░ ░   ░ ▐██▓░    ▒   ██▒");
            Thread.Sleep(100); System.Console.WriteLine(@"  ░  █  █ ██▓█▓█ ██   ░    ░██████▒░██░▒ ▓███▀ ░░▓█▒░██▓   ▒██▒ █▄░██░  ▒██▒ ░   ▒██▒ ░   ░ ██▒▓░  ▒██████▒▒");
            Thread.Sleep(100); System.Console.WriteLine(@"  ░ █▒█  █ █▓██▓ █  █  ░    ░ ▒░▓  ░░▓  ░ ░▒ ▒  ░ ▒ ░░▒░▒   ▒ ▒▒ ▓▒░▓ ░  ▒ ░░     ▒ ░▓      ██▒▒▒ ▒ ▒▓▒ ▒ ░");
            Thread.Sleep(100); System.Console.WriteLine(@"  ░ █▒█▄█▄████▓▄█    █ ░    ▗▄▄▄▒▗▖░▗▖▗▖░ ▗▖ ▗▄▄▖▗▄▄▄▖▒▗▄▖ ▗▖  ▗▖ ▓░  ▗▄▖ ▗▄▄▄▖░    ▓░    ▓██ ░▒░ ░ ░▒  ▓ ░");
            Thread.Sleep(100); System.Console.WriteLine(@" ░ █▒                █░░    ▐▌░ █▐▌░▐▌▐▛▚▖▐▌▐▌  ░▐▌  ░▐▌ ▐▌▐▛▚▖▐▌░░  ▐▌ ▐▌▐▌░░  ░░        ░░        ░       ");
            Thread.Sleep(100); System.Console.WriteLine(@" ░░█▒                 █     ▐▌  █▐▌ ▐▌▐▌ ▝▜▌▐▌▝▜▌▐▛▀▀▘▐▌ ▐▌▐▌ ▝▜▌ ░  ▐▌ ▐▌▐▛▀▀▘░  ▀▀▀▀▀▀▀▀▄▀▀▀▄▄      ▄▄▄▄▄▀▀▀▀");
            Thread.Sleep(100); System.Console.WriteLine(@"  █▒   █          █    █    ▐▙▄▄▀▝▚▄▞▘▐▌░ ▐▌▝▚▄▞▘▐▙▄▄▖▝▚▄▞▘▐▌  ▐▌ ░  ▝▚▄▞▘▐▌      ░░░░░░░░  ░ ░░▀▀▀▀▀▀ ░ ░ ░");
            Thread.Sleep(100); System.Console.WriteLine(@" ▄█▒    █        █      █▄    ");           
            Thread.Sleep(100); System.Console.WriteLine(@" ▄█▒  ▄    ▄▄    ▄      █▄  ▓█████▄  ▒█████   ▒█████   ███▄ ▄███▓     ▒█▒       ▓█████▄ ▓█████   ██████  ██▓███     ██      ██▓ ██▀███  ");
            Thread.Sleep(100); System.Console.WriteLine(@" ▄█▒    ▄▄▄▄▄▄▄▄       ▒█▄  ▒██▀ ██▌▒██▒  ██▒▒██▒  ██▒▓██▒▀█▀ ██▒     ▓█▓       ▒██▀ ██▌▓█   ▀ ▒██    ▒ ▓██░  ██▒▒█████    ▓██▒▓██ ▒ ██▒");
            Thread.Sleep(100); System.Console.WriteLine(@"   ██▒               ▒██    ░██   █▌▒██░  ██▒▒██░  ██▒▓██    ▓██░   ▄▄████▄▄    ░██   █▌▒███   ░ ▓██▄   ▓██░ ██▓▒▒██  ▀██  ▒██▒▓██ ░▄█ ▒");
            Thread.Sleep(100); System.Console.WriteLine(@"     █████████████████      ░██▄  █▌▒██   ██░▒██   ██░▒██    ▒██    ░ ▓█▓░      ░▓█▄   █▒▓█  ▄   ▒   ██▒▒██▄█▓▒ ▒░██▄▄▄▄██ ░██░▒██▀▀█▄  ");
            Thread.Sleep(100); System.Console.WriteLine(@"      ▓▓▒▒▒▒▒█▒▒▒ ▒▒▓      ░▒██████░ ████▓▒░░ ████▓▒░▒██▒   ░██▒     ▒██▒ ░    ░▒███████▒████▒▒██████▒▒▒██▒ ░  ░ ▓█   ▓██▒░██░░██▓ ▒██▒");
            Thread.Sleep(100); System.Console.WriteLine(@"     ▓▓░ ▒▒▒▒▒▒ ▒▒▒░▒▒      ▒▒▓  ▒ ░ ▒░▒░▒░ ░ ▒░▒░▒░ ░ ▒░   ░  ░     ▒ ░░       ▒▒▓  ▒ ░░ ▒░ ░▒ ▒▓▒ ▒ ░▒▓▒░ ░  ░ ▒▒   ▓▒█░░▓  ░ ▒▓ ░▒▓░");
            Thread.Sleep(100); System.Console.WriteLine(@"    ▒▓░░ ░ ░░▒░░░ ░ ░░▒▒     ░ ▒  ▒   ░ ▒ ▒░   ░ ▒ ▒░ ░  ░      ░       ░        ░ ▒  ▒  ░ ░  ░░ ░▒  ░ ░░▒ ░       ▒   ▒▒ ░ ▒ ░  ░▒ ░ ▒░");
            Thread.Sleep(100); System.Console.WriteLine(@"    ▒  ░ ░░  ░░   ░░  ░░▒    ░ ░  ░ ░ ░ ░ ▒  ░ ░ ░ ▒  ░      ░        ░          ░ ░  ░    ░   ░  ░  ░  ░░         ░   ▒    ▒ ░  ░░   ░ ");
            Thread.Sleep(100); System.Console.WriteLine(@"    ░    ░░    ░░ ░    ░     ░        ░ ░      ░ ░         ░                ░       ░  ░      ░                 ░  ░ ░     ░     ");
            Thread.Sleep(100); System.Console.WriteLine(@"           ░  ░░       ░     ░                                            ░                                                      ");
            System.Console.WriteLine();
            Console.ResetColor();
        }

        public static void Prolouge(Player player)
        {
        // PROLOGUE ⬇️
        Type(player.fastMode, "It's a gloomy night, but amid the treacherous downpour, " + $"{player.gameData.PlayerName} pushes on.");
        Type(player.fastMode, "You trudge through the soggy terrain, your shoes repeatedly submerged in the deep mud.");
        Type(player.fastMode, "I have to find my cat,' you whisper to yourself."); // Cat can be changed to dad, but I feel like the story has changed based on the name lol
        Type(player.fastMode, "As you shiver in soaked clothes, you become desperate for shelter.");
        Type(player.fastMode, "You've walked so far that you seem to be off the grid, though... No trace of your cat's paw prints anymore either...");
        Type(player.fastMode, "You continue to walk, and eventually light becomes visible in the distance.\n");
        Type(player.fastMode, "You finally reach a mansion consumed in ivy and surrounded by overgrown weeds.");
        Type(player.fastMode, $"{player.gameData.PlayerName} tugs on the front door, and it creaks open.");
        Type(player.fastMode, "The door is cracked, and on it, there's a sign.");
        Type(player.fastMode, "As you step in, the door creaks shut behind you -- and latches. It's locked.");
        Type(player.fastMode, "You have no other choice but to look around, but as you do, you realize just how big this mansion is.\n");
        }

        public static void Help(Player player)
        {
            Type(player.fastMode, "Certain phrases allow you to interact with the world. When in doubt, try looking around! You can also type in 'menu' to adjust settings.");
        }

    }
}