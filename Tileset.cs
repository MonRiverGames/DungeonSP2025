using System;
using System.Collections.Generic;
using System.Drawing; // Note: Not utilized in this example.
using System.Text.Json.Serialization; // Note: Not utilized in this example.

namespace DungeonGame
{
    public class Tileset
    {
        // List of usable tiles with silly dungeon-themed furniture
        public List<string[]> tilesets = new List<string[]>
        {
            [ // 0: Empty space
            @"          ",
            @"          ",
            @"          ",
            @"          ",
            @"          "
            ],
            [ // 1: Wall
            @"    ||    ",
            @"    ||    ",
            @"    ||    ",
            @"    ||    ",
            @"    ||    "
            ],
            [ // 2: Floor
            @"          ",
            @"          ",
            @"==========",
            @"          ",
            @"          "
            ],
            [ // 3: Dragon Couch
            @"   ____    ",
            @"  /    \__ ",
            @" /  🐉    |",
            @" \_______/ ",
            @"            "
            ],
            [ // 4: Goblin Chair
            @"   ⬤⬤⬤   ",
            @"  |  O O |  ",
            @"  |_______| ",
            @"  /  😂   \  ",
            @" /_________\ "
            ],
            [ // 5: Cauldron Bed
            @"   ~~~~~   ",
            @"  /~~~~~~\ ",
            @" |        |",
            @" |  🥴   | ",
            @" |________|"
            ],
            [ // 6: Treasure Chest Table
            @"  ________  ",
            @" |  💰  | | ",
            @" |________| ",
            @" |________| ",
            @"  |______|  "
            ],
            [ //  Potion Shelf
            @"   ________  ",
            @"  |💚  💙  💛| ",
            @"  |________|  ",
            @"  |  🧪   |  ",
            @"  |________|  "
            ],
            [ // 8: Window
            @"  [] []  ",
            @"  [] []  ",
            @"          ",
            @"          ",
            @"          "
            ],
            [ // 9: Door
            @"  ____   ",
            @" |    |  ",
            @" |____|  ",
            @"          ",
            @"          "
            ]
        };

        // Properties to get the dimensions of a tile
        public int TileHeight => tilesets[0].Length; // Assumes all tiles have the same height
        public int TileWidth => tilesets[0][0].Length; // Assumes all tiles have the same width

        // Method to access a tile by index safely
        public string[] GetTile(int tileIndex)
        {
            if (tileIndex < 0 || tileIndex >= tilesets.Count)
            {
                throw new IndexOutOfRangeException("Invalid tile index.");
            }
            return tilesets[tileIndex];
        }

        // Method to print a map given a 2D array of tile indices
        public void RenderDungeon(int[,] dungeonMap)
        {
            // Loop through each row of the dungeon map
            for (int row = 0; row < dungeonMap.GetLength(0); row++)
            {
                // Loop through each line of tile height
                for (int line = 0; line < TileHeight; line++)
                {
                    // Loop through each column of the dungeon map
                    for (int col = 0; col < dungeonMap.GetLength(1); col++)
                    {
                        // Get the corresponding tile and print the correct line
                        Console.Write(GetTile(dungeonMap[row, col])[line]);
                    }
                    Console.WriteLine(); // Move to the next line after printing one line of tiles
                }
                Console.WriteLine(); // Add a blank line between rows for better visibility
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example of a dungeon layout with silly furniture
            int[,] dungeonMap =
            {
                { 1, 1, 1, 1, 1, 1, 1 }, // Wall row
                { 1, 0, 0, 3, 0, 0, 1 }, // Row with Dragon Couch
                { 1, 0, 4, 5, 0, 0, 1 }, // Row with Goblin Chair and Cauldron Bed
                { 1, 0, 0, 7, 0, 0, 1 }, // Row with Potion Shelf
                { 1, 1, 1, 1, 1, 1, 1 }  // Wall row
            };

            // Create the tileset object
            Tileset tileset = new Tileset();

            // Render the dungeon map
            tileset.RenderDungeon(dungeonMap);
        }
    }
}