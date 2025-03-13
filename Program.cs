/*
Dungeon Crawler Starter Code
This template provides the foundational structure for a text-based dungeon crawler.
*/
/* Test of Rules
*/
using DungeonGame;
using System;
using System.Collections.Generic;
// Main Program
class Program
{

    // To make change to cloud branch, work locally and save. Then, commit to branch --> push to branch. Then, other person pulls to stay up to date.
    static void Main()
    {
        // Initialize Rooms
        Room startRoom = new Room("Entrance Hall", "A grand entrance with torches lining the walls.");
        Room darkRoom = new Room("Dark Chamber", "A pitch-black room with an eerie silence.");
        Room mirrorRoom = new Room("Mirror Room", "A room filled with mirrors in every direction.");

        // Connect Rooms
        startRoom.Exits["north"] = darkRoom;
        darkRoom.Exits["south"] = startRoom;
        darkRoom.Exits["east"] = mirrorRoom;

        // Create Player
        Player player = new Player(startRoom);

        Console.WriteLine("Welcome to the Dungeon Crawler!");
        Console.WriteLine("Type 'go north' to move north or 'go south' to move south or 'go east' to move east.");

        // Game Loop
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine().ToLower();
            string[] command = input.Split(' ');

            if (command.Length > 1 && command[0] == "go")
            {
                player.Move(command[1]);
            }
            else if (input == "quit")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        } 
    }
}

