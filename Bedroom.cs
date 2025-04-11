using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame;

using System;

namespace DungeonGame
{
    internal class Bedroom
    {
    }

    class Program
    {
        static void Main()
        {
            int bedroomState = 1; // Represents the state or visit count of the bedroom.

            switch (bedroomState)
            {
                case 1:
                    Console.WriteLine("You enter a bedroom. Virtually everything including the ornate bed is colored pink, and Hello Kitty memorabilia can be seen everywhere you look.");
                    break;
                case 2:
                    Console.WriteLine("You return to the gaudy pink bedroom. You forgot how offensive the decor is.");
                    break;
                case 3:
                    Console.WriteLine("You return to the bedroom. Maybe you missed something.");
                    break;
                case 4:
                    Console.WriteLine("You're back in the pink bedroom. Do you hate yourself?");
                    break;
                case 5:
                    Console.WriteLine("There is nothing left for you here. Try something else.");
                    break;
                default:
                    Console.WriteLine("The room seems unfamiliar. Are you lost?");
                    break;
            }
        }
    }
}