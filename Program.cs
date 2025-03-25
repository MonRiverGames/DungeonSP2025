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

        Console.WriteLine("Welcome to the Dungeon Crawler!");
        Console.WriteLine("What is your name adventurer?");
        Player player = new Player(Console.ReadLine(), startRoom);  // Read response and create Player
        Console.WriteLine($"Welcome {player.Name}!");
        Console.WriteLine("Type 'go north', 'go south', 'go east', or 'go west' to move in any of the cardinal directions.");

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