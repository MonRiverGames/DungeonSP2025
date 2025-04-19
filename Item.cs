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
            Description=" heavy bar weighing almost as much as a child";
            IsConsumable=false;
            Console.WriteLine("\nAs you struggle to lift the chunk of gold, you wonder how it could be of any use.");
            Console.WriteLine("\nAll of a sudden, the horse of greed and self-indulgence comes crashing into the room.");
            Console.WriteLine("\n'That looks really good,' says the horse.");
            Console.WriteLine("\n'Um... do you want it?' you ask.");
            Console.WriteLine("\nHe nods his head violently.");
            Console.WriteLine("\nDo you give it to him (TYPE '1') or do you refuse? (TYPE '2')");
            Console.Write("\n> ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Contains("1"))
                {
                    Console.WriteLine("\nYou give the block of gold to the horse of greed and self-indulgence.");
                    Console.WriteLine("\nUnexpectedly, he eats it.");
                    Console.WriteLine("\nBefore leaving the room, he approaches you and lovingly chomps off your ear.");
                }
                else if (input.Contains("2"))
                {
                    Console.WriteLine("\nThe horse of greed and self-indulgence doesn't appreciate your lack of cooperation.");
                    Console.WriteLine("\nIn retaliation, he approaches you and not only bites the gold out of your hand, but he takes one of your fingers with it.");
                    Console.WriteLine("\nHe then vanishes into thin air.");
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
            Description=" 8x8 png picture of a minecraft emerald and as you pick you hear a distant 'hrrrrr' ";
            IsConsumable=false;
            Console.WriteLine("\nTo your utter surprise, one of the emeralds grows a face and begins speaking to you.");
            Console.WriteLine("\n'Get your grubby paws off me, buster!' says the emerald.");
            Console.WriteLine("\n'And what if I don't want to?' you say.");
            Random rng = new Random();
            int index = rng.Next(2);

            if (index==0)
                Emeralds1();
            else
                Emeralds2();
        }
        else if (name=="diamonds"){
            Description=" 32k diamond with no imperfections";
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
            Description="a bubbling liquid";
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
        Console.WriteLine("\n'You're about to find out.'");
        Console.WriteLine("\nThe emerald shoots up at your face, latching onto your nose.");
        Console.WriteLine("\nAs it jumps back down to the table, it takes your nose with it.");
        Console.WriteLine("\n'HAHA! Got your nose!' It scurries out of sight.");
    }

    static void Emeralds2()
    {
        Console.WriteLine("\n'You do NOT want to see my bad side,' says the emerald.");
        Console.WriteLine("\n'You're right! I don't. That's why you're going in my pocket, so I don't have to see you at all.'");
        Console.WriteLine("\nThe emerald attempts to protest, but as it reaches your bag, it is silenced.");
    }

    // DIAMONDS
    static void Diamonds1()
    {
        Console.WriteLine("\nYou kneel down and pick up a diamond.");
        Console.WriteLine("\n'Yes! 100 percent yes!' you hear as you look up, noticing the horse of love and affection looking down at you.");
        Console.WriteLine("\n'Huh?' you say.");
        Console.WriteLine("\n'Are you not proposing to me?' asks the horse.");
        Console.WriteLine("\n'NO! Absolutely not!'");
        Console.WriteLine("\n'How rude! Why would you tease me like that?'");
        Console.WriteLine("\nThe horse of love and affection becomes the horse of hatred and annoyance, then eats the diamonds.");
        Console.WriteLine("\nThankfully, there's a few diamonds left.");
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
        Console.WriteLine("\nAs soon as you pick up the key, a chicken falls from nowhere and immediately begins running around frantically.");
        Console.WriteLine("\nIt runs in circles, repeatedly pecking at your toes and screeching 'KEY! KEY!'");
        Console.WriteLine("\nYou have no desire to give up this key.");
        Console.WriteLine("\n'Why did the chicken cross the road?' you ask.");
        Console.WriteLine("\nThe chicken stops dead in its tracks and stares at you. All of a sudden, it screeches 'CHICKEN JOCKEY!' and explodes in a cloud of feathers.");
    }

    static void Fire1()
    {
        Console.WriteLine("\nA fire-breathing dragon comes out of nowhere lunges at you.");
        Console.WriteLine("\nAfraid of being scorched, you dodge its advance.");
        Console.WriteLine("\nThe dragon stares at you for a moment, then murmurs something about Shrek and vanishes into nothingness.");
    }

    static void Fire2()
    {
        Console.WriteLine("\nYou pick up the torch, but it slips out of your hands.");
        Console.WriteLine("\nA scrap of parchment lying on the ground erupts into flames, then turns into a squirrel.");
        Console.WriteLine("\nThe squirrel looks at you in confusion for a moment, before preceding to chuck acorns at you.");
        Console.WriteLine("\nYou try and grab it, but it snickers as it throws one last acorn at you and disappears in a plume of smoke.");
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
        Console.WriteLine("\nAs you go to pick up the potion, it explodes in your face.");
        Console.WriteLine("\nThe horse of judgement and self-satisfaction walks by and cackles at your stupidity.");
    }

}



