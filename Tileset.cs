using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace DungeonGame
{
    public class Tileset
    {
        // List of usable tiles, can be expanded later
        List<string[]> tilesets = new List<string[]>([
        [ // 0
        @"          ",
        @"          ",
        @"          ",
        @"          ",
        @"          "
        ]
        ,
        [ // 1
        @"    ||    ",
        @"    ||    ",
        @"    ||    ",
        @"    ||    ",
        @"    ||    "
        ]
        ,
        [ // 2
        "          ",
        "          ",
        "==========",
        "          ",
        "          "
        ]
        ,
        [ // 3
        @"          ",
        @"          ",
        @"    []====",
        @"    ||    ",
        @"    ||    "
        ]
        ,
        [ // 4
        @"          ",
        @"          ",
        @"====[]    ",
        @"    ||    ",
        @"    ||    "
        ]
        ,
        [ // 5
        @"    ||    ",
        @"    ||    ",
        @"====[]    ",
        @"          ",
        @"          "
        ]
        ,
        [ // 6
        @"    ||    ",
        @"    ||    ",
        @"    []====",
        @"          ",
        @"          "
        ]
        ,
        [ // 7
        @"    ||    ",
        @"    ||    ",
        @"    []====",
        @"    ||    ",
        @"    ||    "
        ]
        ,
        [ // 8
        @"          ",
        @"          ",
        @"====[]====",
        @"    ||    ",
        @"    ||    "
        ]
        ,
        [ // 9
        @"    ||    ",
        @"    ||    ",
        @"====[]    ",
        @"    ||    ",
        @"    ||    "
        ]
        ,
        [ // 10
        @"    ||    ",
        @"    ||    ",
        @"====[]====",
        @"          ",
        @"          "
        ]
        ,
        [ // 11
        @"    ||    ",
        @"    ||    ",
        @"====[]====",
        @"    ||    ",
        @"    ||    "
        ]
        ,
        [ // 15: Dragon Couch
        @"  ____    ",
        @" /    \__ ",
        @"/  🐉   | ",
        @"\_______/ ",
        @"          ",
        ]
        ,
        [ // 4: Goblin Chair
        @"   ⬤⬤⬤    ",
        @" |  O O | ",
        @" |______| ",
        @" /  😂  \ ",
        @"/________\"
        ]
        ,
        [ // 5: Cauldron Bed
        @"  ~~~~~   ",
        @" /~~~~~~\ ",
        @"|        |",
        @"|  🥴    |",
        @"|________|"
        ]
        ,
        [ // 6: Treasure Chest Table
        @" ________ ",
        @"|  💰  | |",
        @"|________|",
        @"|________|",
        @" |______| "
        ]
        ,
        [ //  Potion Shelf
        @" ________ ",
        @"|💚💙 💛|",
        @"|________|",
        @"|  🧪    |",
        @"|________|"
        ]
        //,
        //[ // 8: Window
        //@"  [] []   ",
        //@"  [] []   ",
        //@"          ",
        //@"          ",
        //@"          "
        //]
        //,
        //[ // 9: Door
        //@"  ____    ",
        //@" |    |   ",
        //@" |____|   ",
        //@"          ",
        //@"          "
        //]
        ]);

        // Method to print a map given a 2D array containing the tile numbers
        public void RenderDungeon(int[,] dungeonMap)
        {
            for (int row = 0; row < dungeonMap.GetLength(0); row++)
            {
                for (int line = 0; line < 4; line++)
                {
                    for (int col = 0; col < dungeonMap.GetLength(1); col++)
                    {
                        Console.Write((tilesets[ dungeonMap[row,col] ])[line]);
                    }
                    Console.Write("\n");
                }
            }
        }
    }
}