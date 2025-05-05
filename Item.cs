using System;
using System.Collections.Generic;
using DungeonGame;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsConsumable { get; set; }
    
    public Item(string name)
    {
        Name = name;
        if (name=="rubies"){
            Description=" dazzling red ruby the color of human blood";
            IsConsumable=false;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Rubies1();
            else
                Rubies2();
        }
        
        else if (name=="gold"){
            Description=" Solid bar weighing almost as much as your ego.";
            IsConsumable=false;
            Console.WriteLine("\nAs you struggle to lift the chunk of gold, you wonder how you will take it home with you.");
            Console.WriteLine("\nYou manage to finally get it into your convenient bag of holding.");
            Console.WriteLine("\nYou feel richer already. Also very hurt as you feel the weight of the bag press on your shoulder.");
            Console.WriteLine("\n'Maybe I can use this as a weapon?' You say.");
            Console.WriteLine("\nYou think about whether to give it a test swing.");
            Console.WriteLine("\nDo you try to swing the bag? (TYPE '1') or do you put it back? (TYPE '2')");
            Console.Write("\n> ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Contains("1"))
                {
                    Console.WriteLine("\nYou swing the heavy bag, and as it gains velocity, you hear a loud RIP followed by a thunderous crash.");
                    Console.WriteLine("\nIt appears the gold was so heavy, it ripped through a seam in the bag, knocked over a lamp, and smashed a sizable hole in the wall.");
                    Console.WriteLine("\nPerhaps it might be best to leave the scene quickly.");
                }
                else if (input.Contains("2"))
                {
                    Console.WriteLine("\nDespite the greed in your mind telling you to take the gold, your better judgement decides to leave it where it was.");
                    Console.WriteLine("\nSuch a shame considering how much it is probably worth.");
                    Console.WriteLine("\nYour shoulder however, is much happier.");
                }
                else
                {
                    Console.WriteLine("\nPlease type '1' or '2'!");
                }
        }

        else if (name=="milk"){
            Description="a nice, cold glass of milk";
            IsConsumable=true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Milk1();
            else
                Milk2();
        }

        else if (name=="emeralds"){
            Description=" You see several shiney, crisp looking green gems resting on a desk. ";
            IsConsumable=false;
            Console.WriteLine("\nThey look rather almost juicy...");
            Console.WriteLine("\n'You are incredibly tempted to take a bit out of one.");
            Console.WriteLine("\n'Against your better judgement, you attempt to take a bite out of the crispiest looking one.");
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Emeralds1();
            else
                Emeralds2();
        }
        else if (name=="diamonds"){
            Description=" 32k diamond with no imperfections, an almost perfect contrast to your soul.";
            IsConsumable=false;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Diamonds1();
            else
                Diamonds2();
        }
        else if (name=="Poison Spell"){
            Description="n old parchment that stinks of sulfur and death";
            IsConsumable=true;
        }
        else if (name=="torch"){
            Description="a burning stick that illuminates your surroundings flawlessly"; //this was formally the fire spell, but the wizard can't use it so I just recycled it into torch stories.
            IsConsumable=false;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Fire1();
            else
                Fire2();
        }
        else if (name=="milk"){
            Description="a cold glass of milk";
            IsConsumable=true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Milk1();
            else
                Milk2();
        }
        else if (name=="apple"){
            Description="a perfectly delicious fruit";
            IsConsumable=true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Apple1();
            else
                Apple2();
        }
        else if (name=="potion"){
            Description="a bubbling red liquid in a round bottom flask";
            IsConsumable=true;
            Potion1();
        }
        else if (name=="Regen Spell"){
            Description="n old paper that feels like a bandage and has the aroma of an emergency room";
            IsConsumable=true;
        }
        else if (name=="Ice Spell"){
            Description=" cold sheet of papyrus that has frost on the corners";
            IsConsumable=true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Ice1();
            else
                Ice2();
        }
        else if (name=="key"){
            Description="an old copper key";
            IsConsumable=true;
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Key1();
            else
                Key2();
        }
        else
        {
            Description="";
            IsConsumable=false;
        }
    }

    // EVENTS FOR ITEMS (Some of these are very unusual but they're meant to be in line with the satire theme)

    // RUBIES
    static void Rubies1()
        {
            Console.WriteLine("\nThe rubies begin to glow...");
            Console.WriteLine("\nBrighter and brighter, the rubies luminescence spreads into your hands... up your arms...");
            Console.WriteLine("\nYou feel fantastic. Better than when you entered the dungeon.");
            Console.WriteLine("\nYou feel powerful.");
            //Player.Buff("rage", 1, 0);
        }

    static void Rubies2()
    {
            Console.WriteLine("\nThe rubies begin to glow...");
            Console.WriteLine("\nThey grow warm, and the light looks as if it's seeping into your skin...");
            Console.WriteLine("\nDo you drop the rubies (TYPE '1') or wait to see what happens? (TYPE '2')");
            Console.Write("\n> ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Contains("1"))
                {
                    Console.WriteLine("\nYou drop the rubies, and they shatter as they hit the ground, emitting rancid smoke.");
                    Console.WriteLine("\nGood thing you dropped those, I guess.");
                    Console.WriteLine("\nYou notice a few rubies still lying on the table.");
                }
                else if (input.Contains("2")) 
                {
                    Console.WriteLine("\nYou continue to hold the rubies, but they get even warmer... until they're scalding hot.");
                    Console.WriteLine("\nBefore you get the chance to drop them, they explode in your hands, leaving horrible burns.");
                    //Player.Debuff("vulnerability", 2, 0);
                }
            
    }

    // EMERALDS
    static void Emeralds1()
    {
        Console.WriteLine("\nYou take a large bite into this emerald, only to hear a loud 'CRUNCH'.");
        Console.WriteLine("\nYou look down at the intact emerald, before realization sets in.");
        Console.WriteLine("\nThat crunch was your teeth cracking against the hard mineral surface.");
        Console.WriteLine("\nNow sufficiently regretting your actions, you steal a pair of false teeth from a nearby desk.");
    }

    static void Emeralds2()
    {
        Console.WriteLine("\nYou bite down onto the emerald and feel your teeth sink into its chewy surface.");
        Console.WriteLine("\nYour curiosity is rewarded with a chewy texture and the flavor of green apple.");
        Console.WriteLine("\nYou propmtly grab the rest and shove them into your bag for later.");
    }

    // DIAMONDS
    static void Diamonds1()
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

    static void Diamonds2()
    {
        Console.WriteLine("\nAs you pick up the diamonds, they sparkle in the light.");
        Console.WriteLine("\nThe longer you hold them, the more energized they make you feel.");
        Console.WriteLine("\nYou're ready to fight whatever comes your way.");
        //Player.Buff("rage", 1, 0);
    }

    // KEY
    static void Key1()
    {
        Console.WriteLine("\nYou feel like this key has got to be useful in some way.");
        Console.WriteLine("\n*ACHOO*");
        Console.WriteLine("\nHmm... your allergies seem to be acting up.");
        Console.WriteLine("\nYour eyes start watering heavily, your throat feels constricted, and hives start to appear on your arms.");
        Console.WriteLine("\nYou quickly tuck the key into your pocket, immediately using the free hand to scratch your arm.");
        Console.WriteLine("\nWell, that key must've been copper.");
        Console.WriteLine("\nYou're allergic to copper.");
    }

    static void Key2()
    {
        Console.WriteLine("\nAs you go to grab the key, you feel your body halt as you are overcome with this feeling of intense dread.");
        Console.WriteLine("\nThe feeling dissapates as you retract your hand.");
        Console.WriteLine("\nSomething isn't right. It takes you a moment to realize that there is no curse, this is your body's base instincts to keep you alive.");
        Console.WriteLine("\nReaching for it a second time, the feeling washes over you, more intense than the last.");
        Console.WriteLine("\nWhatever this key is, or whatever it unlocks, is clearly not to be messed with. Better to just leave it be.");
    }

    static void Fire1()
    {
        Console.WriteLine("\nThe fire begins to dance atop the lit torch. It's... beautiful.");
        Console.WriteLine("\nYou draw the torch closer to yourself, bathing in the warmth and soft glow.");
        Console.WriteLine("\nYou then begin to feel a stinging pain and the smell of burnt hair as you have brought it a little too close.");
        Console.WriteLine("\nYou quickly splash some water on yourself and leave the torch alone.");
    }

    static void Fire2()
    {
        Console.WriteLine("\nYou pick up the torch, but it slips out of your hands.");
        Console.WriteLine("\nIt manages to land in a crate labeled 'Inconvinently Placed Explosives'.");
        Console.WriteLine("\nYou hear a faint sizzle, and after a few moments, nothing happens.");
        Console.WriteLine("\n'These must be expired' you say to yourself. 'Thank goo-' A thunderous *BOOM* echoes throughout the house.");
        Console.WriteLine("\nThe room manages to stay completely intact and you find yourself mostly unharmed. The only evidence of an explosion is the thick layer of soot covering the floor and yourself.");
    }

    static void Ice1()
    {
        Console.WriteLine("\nYou recite the ice spell, but it doesn't seem to work.");
        Console.WriteLine("\nYou try it over and over, to no avail. You finally give up.");
        Console.WriteLine("\nAs you start to explore the room a bit more, you hear a funny jingle.");
        Console.WriteLine("\nIt's a very familiar jingle. But what is it?");
        Console.WriteLine("\nAll of a sudden, an ice cream truck bursts into the room, leaving stray ice cream bars strewn everywhere.");
        Console.WriteLine("\nAt least you get a sweet treat!");
    }

    static void Ice2()
    {
        Console.WriteLine("\nYou attempt to freeze a candle with your newly learned ice spell.");
        Console.WriteLine("\nThe candle won't freeze for some reason.");
        Console.WriteLine("\nYou keep trying, but you suddenly slip and hit your face on a table.");
        Console.WriteLine("\nThe floor is ice.");
        Console.WriteLine("\nThis would be fun if you could skate!");
    }

    static void Milk1()
    {
        Console.WriteLine("\nYou pick up the milk and take a sip.");
        Console.WriteLine("\nIt's nice and refreshing, and reminds you of childhood.");
        Console.WriteLine("\nThe only thing that would make this better is a freshly baked chocolate chip cookie.");
    }

    static void Milk2()
    {
        Console.WriteLine("\nYou take a sip of the milk...");
        Console.WriteLine("\nIt's absolutely disgusting.");
        Console.WriteLine("\nYou take a closer look at it. It's spoiled.");
    }

    static void Apple1()
    {
        Console.WriteLine("\nAs you grab the apple, a worm crawls out of it.");
        Console.WriteLine("\nYou gasp out of disgust, but the worm looks at you desperately.");
        Console.WriteLine("\n'Help! He's coming after me!' says the worm.");
        Console.WriteLine("\n'Who's coming after--?'");
        Console.WriteLine("\nAll of a sudden, a hawk swoops down from nowhere and grabs the worm by its head.");
    }

    static void Apple2()
    {
        Console.WriteLine("\nA crisp, unblemished apple.");
        Console.WriteLine("\nIf you had a knife and some peanut butter, this would make a great snack.");
    }
    
    static void Potion1()
    {
        Console.WriteLine("\n'Everyone know this is a healing potion.' You think to yourself.");
        Console.WriteLine("\nA quick sip however, reveals it was, in fact, NOT a healing potion.");
        Console.WriteLine("\nThis is a flask of boiling hot cranberry juice kept hot by magic.");
    }

}



