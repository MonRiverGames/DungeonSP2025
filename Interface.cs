using System;

static class Graphics
{
    public static void TypeEffectColor(bool fastMode, string text, string color = "none", int sleep = 0, int delay = 30)
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
}