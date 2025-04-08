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
        "|       ",
        "|       ",
        "|       ",
        "|       "
        ]
        ,
        [ // 1
        "--------",
        "        ",
        "        ",
        "        "
        ]
        ,
        [ // 2
        "       |",
        "       |",
        "       |",
        "       |"
        ]
        ,
        [ // 3
        "        ",
        "        ",
        "        ",
        "--------"
        ]
        ,
        [ // 4
        "p-------",
        "|       ",
        "|       ",
        "|       "
        ]
        ,
        [ // 5
        "-------q",
        "       |",
        "       |",
        "       |"
        ]
        ,
        [ // 6
        "       |",
        "       |",
        "       |",
        "-------d"
        ]
        ,
        [ // 7
        "|       ",
        "|       ",
        "|       ",
        "b-------"
        ]
        ,
        [ // 8
        "p-------",
        "|       ",
        "|       ",
        "b-------"
        ]
        ,
        [ // 9
        "p------q",
        "|      |",
        "|      |",
        "|      |"
        ]
        ,
        [ // 10
        "-------q",
        "       |",
        "       |",
        "-------d"
        ]
        ,
        [ // 11
        "|      |",
        "|      |",
        "|      |",
        "b------d"
        ]
        ,
        [ // 12
        "|      |",
        "|      |",
        "|      |",
        "|      |"
        ]
        ,
        [ // 13
        "--------",
        "        ",
        "        ",
        "--------"
        ]
        ,
        [ // 14
        "        ",
        "        ",
        "        ",
        "        "
        ]
        ]);

        // Example map
        public int[,] sampleMap = {
            {14, 14, 14,  4,  1,  5},
            { 4,  5,  9,  0, 14,  2},
            { 0, 14, 14, 14, 14,  2},
            { 7,  6, 12,  7,  3,  6},
            { 8, 13, 14,  1,  1, 10},
            {14, 14, 11,  7,  3, 10}
        };

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