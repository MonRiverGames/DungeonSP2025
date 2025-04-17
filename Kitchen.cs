using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame;

namespace DungeonGame
{
    class Return_Room
    {
        static void Kitchen()
        {
            int Room = 1;

            switch (Room)
            {
                case 1:
                    Console.WriteLine("You come back into the kitchen to find some cat-nip..." +
                        "\nYou're not sure what it's for but you just decide to pick it up.");
                    break;
                case 2:
                    Console.WriteLine("When entering the room again you find a open can of Feline Feast on the marble counter." +
                        "\nYou wonder if there's someone else in the dungeon with you.");
                    break;
                case 3:
                    Console.WriteLine("After going back into the kitchen for more clues you find a piece of paper that says a few words on it." +
                        "\nUpon further inspection you see it has the Hello Cat showtimes for today..." +
                        "\nIt makes you want to sit down and watch the show.");
                    break;
                case 4:
                    Console.WriteLine("Upon your scramble for hints in the kitchen you see a cat collar that says 'Kitty' on it..." +
                        "\nYou decide to pick it up.");
                    break;
                case 5:
                    Console.WriteLine("You hope to find another clue in the kitchen, one that would help more this time. " +
                        "\nWhen going in for the last time you decide to feel around to see if you can find ANYTHING that would help." +
                        "\nYou feel a square dip on the oak China cabinet, it seems to resemble a button." +
                        "\nYou decide to push it." +
                        "\nIt opens up a dark room and you decide to go in." +
                        "\nIn the room you see a picture of a mysterious and fuzzy stranger, it seems to be holding a... freshly hatched human." +
                        "\nThe small being appears to have a set of pointy feline ears.  " +
                        "\nWhile you were inspecting the dark room, you smell smoke." +
                        "\nYou go to see what it is, and see a blaze of orange and yellow in front of you." +
                        "\nIt seems to becoming from the stove..." +
                        "\nYou decide it's best to get out of there because the fire is destroying the room.");
                    break;

            }
        }
    }
}




