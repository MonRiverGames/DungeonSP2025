using System;
using System.Collections.Generic;
using DungeonGame;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsConsumable { get; set; }

    Player player;
    
    public Item(string name, Player player)
    {
        Name = name;
        this.player = player;
        if (name == "rubies"){
            Description = " dazzling red ruby the color of human blood";
            IsConsumable = false;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Rubies1(player);
            else
                Rubies2(player);
        }
        
        else if (name == "gold"){
            Description = " Solid bar weighing almost as much as your ego.";
            IsConsumable = false;
            Graphics.Type(player.fastMode, "\nAs you struggle to lift the chunk of gold, you wonder how you will take it home with you.");
            Graphics.Type(player.fastMode,"\nYou manage to finally get it into your convenient bag of holding.");
            Graphics.Type(player.fastMode, "\nYou feel richer already. Also very hurt as you feel the weight of the bag press on your shoulder.");
            Graphics.Type(player.fastMode, "\n'Maybe I can use this as a weapon?' You say.");
            Graphics.Type(player.fastMode, "\nYou think about whether to give it a test swing.");
            Graphics.Type(player.fastMode, "\nDo you try to swing the bag? (TYPE '1') or do you put it back? (TYPE '2')\n> ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Contains("1"))
                {
                    Graphics.Type(player.fastMode, "\nYou swing the heavy bag, and as it gains velocity, you hear a loud RIP followed by a thunderous crash.");
                    Graphics.Type(player.fastMode, "\nIt appears the gold was so heavy, it ripped through a seam in the bag, knocked over a lamp, and smashed a sizable hole in the wall.");
                    Graphics.Type(player.fastMode, "\nPerhaps it might be best to leave the scene quickly.");
                }
                else if (input.Contains("2"))
                {
                    Console.WriteLine("\nDespite the greed in your mind telling you to take the gold, your better judgement decides to leave it where it was.");
                    Console.WriteLine("\nSuch a shame considering how much it is probably worth.");
                    Console.WriteLine("\nYour shoulder however, is much happier.");
                }
                else
                {
                    Graphics.Type(player.fastMode, "\nPlease type '1' or '2'!");
                }
        }

        else if (name == "milk"){
            Description = "a nice, cold glass of milk";
            IsConsumable = true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Milk1(player);
            else
                Milk2(player);
        }

        else if (name=="emeralds"){
            Description=" You see several shiney, crisp looking green gems resting on a desk. ";
            IsConsumable=false;
            Console.WriteLine("\nThey look rather almost juicy...");
            Console.WriteLine("\n'You are incredibly tempted to take a bit out of one.");
            Console.WriteLine("\n'Against your better judgement, you attempt to take a bite out of the crispiest looking one.");
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Emeralds1(player);
            else
                Emeralds2(player);
        }
        else if (name=="diamonds"){
            Description=" 32k diamond with no imperfections, an almost perfect contrast to your soul.";
            IsConsumable=false;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Diamonds1(player);
            else
                Diamonds2(player);
        }
        else if (name=="Poison Spell"){
            Description="n old parchment that stinks of sulfur and death";
            IsConsumable=true;
        }
        else if (name == "torch"){
            Description="a burning stick that illuminates your surroundings flawlessly"; //this was formally the fire spell, but the wizard can't use it so I just recycled it into torch stories.
            IsConsumable=false;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Fire1(player);
            else
                Fire2(player);
        }
        else if (name == "milk"){
            Description = "a cold glass of milk";
            IsConsumable = true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Milk1(player);
            else
                Milk2(player);
        }
        else if (name == "apple"){
            Description = "a perfectly delicious fruit";
            IsConsumable = true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Apple1(player);
            else
                Apple2(player);
        }
        else if (name=="potion"){
            Description="a bubbling red liquid in a round bottom flask";
            IsConsumable=true;
            Potion1(player);
        }
        else if (name == "Regen Spell"){
            Description = "n old paper that feels like a bandage and has the aroma of an emergency room";
            IsConsumable=true;
        }
        else if (name == "Ice Spell"){
            Description = " cold sheet of papyrus that has frost on the corners";
            IsConsumable = true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Ice1(player);
            else
                Ice2(player);
        }
        else if (name == "key"){
            Description = "an old copper key";
            IsConsumable = true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Key1(player);
            else
                Key2(player);
        }
        else
        {
            Description="";
            IsConsumable=false;
        }
    }

    // EVENTS FOR ITEMS (Some of these are very unusual but they're meant to be in line with the satire theme)
    
    // RUBIES
    static void Rubies1(Player player)
    {
        Graphics.Type(player.fastMode, "\nThe rubies begin to glow...");
        Graphics.Type(player.fastMode, "\nBrighter and brighter, the rubies luminescence spreads into your hands... up your arms...");
        Graphics.Type(player.fastMode, "\nYou feel fantastic. Better than when you entered the dungeon.");
        Graphics.Type(player.fastMode, "\nYou feel powerful.");
        player.Buff("rage", 1, 0.1f);
    }

    static void Rubies2(Player player)
    {
            Graphics.Type(player.fastMode, "\nThe rubies begin to glow...");
            Graphics.Type(player.fastMode, "\nThey grow warm, and the light looks as if it's seeping into your skin...");
            Graphics.Type(player.fastMode, "\nDo you drop the rubies (TYPE '1') or wait to see what happens? (TYPE '2')\n> ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Contains("1"))
                {
                    Graphics.Type(player.fastMode, "\nYou drop the rubies, and they shatter as they hit the ground, emitting rancid smoke.");
                    Graphics.Type(player.fastMode, "\nGood thing you dropped those, I guess.");
                    Graphics.Type(player.fastMode, "\nYou notice a few rubies still lying on the table.");
                }
                else if (input.Contains("2")) 
                {
                    Graphics.Type(player.fastMode, "\nYou continue to hold the rubies, but they get even warmer... until they're scalding hot.");
                    Graphics.Type(player.fastMode, "\nBefore you get the chance to drop them, they explode in your hands, leaving horrible burns.");
                    player.Debuff("vulnerability", 2, 0.1f);
                }
            
    }

    // EMERALDS
    static void Emeralds1(Player player)
    {
        Console.WriteLine("\nYou take a large bite into this emerald, only to hear a loud 'CRUNCH'.");
        Console.WriteLine("\nYou look down at the intact emerald, before realization sets in.");
        Console.WriteLine("\nThat crunch was your teeth cracking against the hard mineral surface.");
        Console.WriteLine("\nNow sufficiently regretting your actions, you steal a pair of false teeth from a nearby desk.");
    }

    static void Emeralds2(Player player)
    {
        Console.WriteLine("\nYou bite down onto the emerald and feel your teeth sink into its chewy surface.");
        Console.WriteLine("\nYour curiosity is rewarded with a chewy texture and the flavor of green apple.");
        Console.WriteLine("\nYou propmtly grab the rest and shove them into your bag for later.");
    }

    // DIAMONDS
    static void Diamonds1(Player player)
    {
        Console.WriteLine("\nYou kneel down and pick up a diamond.");
        Console.WriteLine("\nAs you pick it up and hold it to the light, you feel almost... mezmerized.");
        Console.WriteLine("\nYou begin to notice small details, like the angles of the facets, the frosted edges leading to the tip.");
        Console.WriteLine("\nThe pattern that dances in the light as you look down through the head of the diamond.");
        Console.WriteLine("\nThe passage of time seems to slow as you admire all the little details.");
        Console.WriteLine("\nHow long has it been? A few minutes? A day? A week? The answer eludes you as you stare endlessly at perfection.");
        Console.WriteLine("\nIt is only after you feel a nudge on your shoulder that you break free from this trance. You look up to see a horse gazing into your eyes.");
        Console.WriteLine("\nStupified, you put the diamonds back, and wait just long enough to realize there is no one here but you.");
    }

    static void Diamonds2(Player player)
    {
        Graphics.Type(player.fastMode, "\nAs you pick up the diamonds, they sparkle in the light.");
        Graphics.Type(player.fastMode, "\nThe longer you hold them, the more energized they make you feel.");
        Graphics.Type(player.fastMode, "\nYou're ready to fight whatever comes your way.");
        player.Buff("rage", 1, 0.1f);
    }

    // KEY
    static void Key1(Player player)
    {
        Graphics.Type(player.fastMode, "\nYou feel like this key has got to be useful in some way.");
        Graphics.Type(player.fastMode, "\n*ACHOO*");
        Graphics.Type(player.fastMode, "\nHmm... your allergies seem to be acting up.");
        Graphics.Type(player.fastMode, "\nYour eyes start watering heavily, your throat feels constricted, and hives start to appear on your arms.");
        Graphics.Type(player.fastMode, "\nYou quickly tuck the key into your pocket, immediately using the free hand to scratch your arm.");
        Graphics.Type(player.fastMode, "\nWell, that key must've been copper.");
        Graphics.Type(player.fastMode, "\nYou're allergic to copper.");
    }

    static void Key2(Player player)
    {
        Console.WriteLine("\nAs you go to grab the key, you feel your body halt as you are overcome with this feeling of intense dread.");
        Console.WriteLine("\nThe feeling dissapates as you retract your hand.");
        Console.WriteLine("\nSomething isn't right. It takes you a moment to realize that there is no curse, this is your body's base instincts to keep you alive.");
        Console.WriteLine("\nReaching for it a second time, the feeling washes over you, more intense than the last.");
        Console.WriteLine("\nWhatever this key is, or whatever it unlocks, is clearly not to be messed with. Better to just leave it be.");
    }

    static void Fire1(Player player)
    {
        Console.WriteLine("\nThe fire begins to dance atop the lit torch. It's... beautiful.");
        Console.WriteLine("\nYou draw the torch closer to yourself, bathing in the warmth and soft glow.");
        Console.WriteLine("\nYou then begin to feel a stinging pain and the smell of burnt hair as you have brought it a little too close.");
        Console.WriteLine("\nYou quickly splash some water on yourself and leave the torch alone.");
    }

    static void Fire2(Player player)
    {
        Console.WriteLine("\nYou pick up the torch, but it slips out of your hands.");
        Console.WriteLine("\nIt manages to land in a crate labeled 'Inconvinently Placed Explosives'.");
        Console.WriteLine("\nYou hear a faint sizzle, and after a few moments, nothing happens.");
        Console.WriteLine("\n'These must be expired' you say to yourself. 'Thank goo-' A thunderous *BOOM* echoes throughout the house.");
        Console.WriteLine("\nThe room manages to stay completely intact and you find yourself mostly unharmed. The only evidence of an explosion is the thick layer of soot covering the floor and yourself.");
    }

    static void Ice1(Player player)
    {
        Graphics.Type(player.fastMode, "\nYou recite the ice spell, but it doesn't seem to work.");
        Graphics.Type(player.fastMode, "\nYou try it over and over, to no avail. You finally give up.");
        Graphics.Type(player.fastMode, "\nAs you start to explore the room a bit more, you hear a funny jingle.");
        Graphics.Type(player.fastMode, "\nIt's a very familiar jingle. But what is it?");
        Graphics.Type(player.fastMode, "\nAll of a sudden, an ice cream truck bursts into the room, leaving stray ice cream bars strewn everywhere.");
        Graphics.Type(player.fastMode, "\nAt least you get a sweet treat!");
    }

    static void Ice2(Player player)
    {
        Graphics.Type(player.fastMode, "\nYou attempt to freeze a candle with your newly learned ice spell.");
        Graphics.Type(player.fastMode, "\nThe candle won't freeze for some reason.");
        Graphics.Type(player.fastMode, "\nYou keep trying, but you suddenly slip and hit your face on a table.");
        Graphics.Type(player.fastMode, "\nThe floor is ice.");
        Graphics.Type(player.fastMode, "\nThis would be fun if you could skate!");
    }

    static void Milk1(Player player)
    {
        Graphics.Type(player.fastMode, "\nYou pick up the milk and take a sip.");
        Graphics.Type(player.fastMode, "\nIt's nice and refreshing, and reminds you of childhood.");
        Graphics.Type(player.fastMode, "\nThe only thing that would make this better is a freshly baked chocolate chip cookie.");
    }

    static void Milk2(Player player)
    {
        Graphics.Type(player.fastMode, "\nYou take a sip of the milk...");
        Graphics.Type(player.fastMode, "\nIt's absolutely disgusting.");
        Graphics.Type(player.fastMode, "\nYou take a closer look at it. It's spoiled.");
    }

    static void Apple1(Player player)
    {
        Graphics.Type(player.fastMode, "\nAs you grab the apple, a worm crawls out of it.");
        Graphics.Type(player.fastMode, "\nYou gasp out of disgust, but the worm looks at you desperately.");
        Graphics.Type(player.fastMode, "\n'Help! He's coming after me!' says the worm.");
        Graphics.Type(player.fastMode, "\n'Who's coming after--?'");
        Graphics.Type(player.fastMode, "\nAll of a sudden, a hawk swoops down from nowhere and grabs the worm by its head.");
    }

    static void Apple2(Player player)
    {
        Graphics.Type(player.fastMode, "\nA crisp, unblemished apple.");
        Graphics.Type(player.fastMode, "\nIf you had a knife and some peanut butter, this would make a great snack.");
    }
    
    static void Potion1(Player player)
    {
        Console.WriteLine("\n'Everyone know this is a healing potion.' You think to yourself.");
        Console.WriteLine("\nA quick sip however, reveals it was, in fact, NOT a healing potion.");
        Console.WriteLine("\nThis is a flask of boiling hot cranberry juice kept hot by magic.");
    }
}