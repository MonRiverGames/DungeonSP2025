using System;
using System.Threading;

class HauntedDungeon
{
    static void Main()
    {
        Console.Title = "Intro to Dungeon";

        // Prologue
        string[] prologueLines = {
            "Legends whisper of a forsaken dungeon, buried deep beneath the earth...",
            "Once home to a powerful sorcerer, it now lies abandoned—except for the souls that never escaped.",
            "Many have entered, none have returned.",
            "Tonight... you find yourself at its gates."
        };

        foreach (string line in prologueLines)
        {
            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(50); // Typewriter effect
            }
            Console.WriteLine();
            Thread.Sleep(500);
        }

        Console.WriteLine("\nA heavy mist swirls at your feet, and the ancient doors groan as they creak open...");
        Thread.Sleep(1000);

        // Dungeon Intro
        string[] dungeonLines = {
            "Darkness engulfs you as the dungeon door slams shut behind...",
            "A chilling wind whispers through the hollow corridors...",
            "The torches flicker, casting long shadows that twist and writhe...",
            "The walls... damp and cracked, are lined with faded engravings—warnings from those who never made it out.",
            "Moss creeps over the stone like grasping fingers, hiding secrets beneath centuries of decay.",
            "Deep within the crevices, something skitters—a rat, or perhaps something far worse.",
            "The scent of mold and blood hangs heavy in the air."
        };

        foreach (string line in dungeonLines)
        {
            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(50); // Typewriter effect
            }
            Console.WriteLine();
            Thread.Sleep(500);
        }

        Console.WriteLine("\nYou see three pathways before you:\n");
        Console.WriteLine("1. The Shadow Chamber — a place of whispers and unseen horrors.");
        Console.WriteLine("2. The Hall of Echoes — where distant voices never seem to fade.");
        Console.WriteLine("3. The Bloodstone Vault — rumored to house treasures... and curses.");
        Console.Write("\nWhich room do you enter? (1/2/3): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("\nYou step into the Shadow Chamber...");
                Console.WriteLine("Something moves in the darkness, but the source remains unseen.");
                break;
            case "2":
                Console.WriteLine("\nYou tread cautiously into the Hall of Echoes...");
                Console.WriteLine("The walls murmur ancient words—you swear they speak your name.");
                break;
            case "3":
                Console.WriteLine("\nYou venture into the Bloodstone Vault...");
                Console.WriteLine("Gold glimmers in the dim torchlight, but are those coins... or teeth?");
                break;
            default:
                Console.WriteLine("\nHesitation grips you. The dungeon does not take kindly to indecision...");
                Console.WriteLine("The walls seem to breathe, pressing in around you.");
                break;
        }
    }
}
