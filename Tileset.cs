using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace DungeonGame
{
    public class Tileset
    {
        List<string[]> tilesets = new List<string[]>([
        [
        "|       ",
        "|       ",
        "|       ",
        "|       "
        ]
        ,
        [
        "--------",
        "        ",
        "        ",
        "        "
        ]
        ,
        [
        "       |",
        "       |",
        "       |",
        "       |"
        ]
        ,
        [
        "        ",
        "        ",
        "        ",
        "--------"
        ]
        ,
        [
        "p-------",
        "|       ",
        "|       ",
        "|       "
        ]
        ,
        [
        "-------q",
        "       |",
        "       |",
        "       |"
        ]
        ,
        [
        "       |",
        "       |",
        "       |",
        "-------d"
        ]
        ,
        [
        "|       ",
        "|       ",
        "|       ",
        "b-------"
        ]
        ,
        [
        "p-------",
        "|       ",
        "|       ",
        "b-------"
        ]
        ,
        [
        "p------q",
        "|      |",
        "|      |",
        "|      |"
        ]
        ,
        [
        "-------q",
        "       |",
        "       |",
        "-------d"
        ]
        ,
        [
        "|      |",
        "|      |",
        "|      |",
        "b------d"
        ]
        ,
        [
        "|      |",
        "|      |",
        "|      |",
        "|      |"
        ]
        ,
        [
        "--------",
        "        ",
        "        ",
        "--------"
        ]
        ,
        [
        "        ",
        "        ",
        "        ",
        "        "
        ]
        ]);

        void renderDungeon(int[,] dungeonMap)
        {
            for (int i = 0; i < dungeonMap.GetLength(0); i++)
            {
                for (int j = 0; j < dungeonMap.GetLength(1); j++)
                {
                    for(int k = 0; k < 4; k++)
                    {
                        Console.Write(tilesets[dungeonMap[i,j]][k]);
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}