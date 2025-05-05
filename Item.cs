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
                    Graphics.Type(player.fastMode, "\nDespite the greed in your mind telling you to take the gold, your better judgement decides to leave it where it was.");
                    Graphics.Type(player.fastMode, "\nSuch a shame considering how much it is probably worth.");
                    Graphics.Type(player.fastMode, "\nTruely a shame...");
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

        else if (name == "emeralds"){
            Description = " 8x8 png picture of a minecraft emerald and as you pick you hear a distant 'hrrrrr' ";
            IsConsumable = false;
            Graphics.Type(player.fastMode, "\nTo your utter surprise, one of the emeralds grows a face and begins speaking to you.");
            Graphics.Type(player.fastMode, "\n'Get your grubby paws off me, buster!' says the emerald.");
            Graphics.Type(player.fastMode, "\n'And what if I don't want to?' you say.");
            Random rng = new Random();
            int index = rng.Next(2);

            if (index == 0)
                Emeralds1(player);
            else
                Emeralds2(player);
        }
        else if (name == "diamonds"){
            Description = " 32k diamond with no imperfections";
            IsConsumable = false;
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
        else if (name == "potion"){
            Description = "a bubbling liquid";
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
        Graphics.Type(player.fastMode, "\n'You're about to find out.'");
        Graphics.Type(player.fastMode, "\nThe emerald shoots up at your face, latching onto your nose.");
        Graphics.Type(player.fastMode, "\nAs it jumps back down to the table, it takes your nose with it.");
        Graphics.Type(player.fastMode, "\n'HAHA! Got your nose!' It scurries out of sight.");
    }

    static void Emeralds2(Player player)
    {
        Graphics.Type(player.fastMode, "\n'You do NOT want to see my bad side,' says the emerald.");
        Graphics.Type(player.fastMode, "\n'You're right! I don't. That's why you're going in my pocket, so I don't have to see you at all.'");
        Graphics.Type(player.fastMode, "\nThe emerald attempts to protest, but as it reaches your bag, it is silenced.");
    }

    // DIAMONDS
    static void Diamonds1(Player player)
    {
        Graphics.Type(player.fastMode, "\nYou kneel down and pick up a diamond.");
        Graphics.Type(player.fastMode, "\n'Yes! 100 percent yes!' you hear as you look up, noticing the horse of love and affection looking down at you.");
        Graphics.Type(player.fastMode, "\n'Huh?' you say.");
        Graphics.Type(player.fastMode, "\n'Are you not proposing to me?' asks the horse.");
        Graphics.Type(player.fastMode, "\n'NO! Absolutely not!'");
        Graphics.Type(player.fastMode, "\n'How rude! Why would you tease me like that?'");
        Graphics.Type(player.fastMode, "\nThe horse of love and affection becomes the horse of hatred and annoyance, then eats the diamonds.");
        Graphics.Type(player.fastMode, "\nThankfully, there's a few diamonds left.");
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
        Graphics.Type(player.fastMode, "\nAs soon as you pick up the key, a chicken falls from nowhere and immediately begins running around frantically.");
        Graphics.Type(player.fastMode, "\nIt runs in circles, repeatedly pecking at your toes and screeching 'KEY! KEY!'");
        Graphics.Type(player.fastMode, "\nYou have no desire to give up this key.");
        Graphics.Type(player.fastMode, "\n'Why did the chicken cross the road?' you ask.");
        Graphics.Type(player.fastMode, "\nThe chicken stops dead in its tracks and stares at you. All of a sudden, it screeches 'CHICKEN JOCKEY!' and explodes in a cloud of feathers.");
    }

    static void Fire1(Player player)
    {
        Graphics.Type(player.fastMode, "\nA fire-breathing dragon comes out of nowhere lunges at you.");
        Graphics.Type(player.fastMode, "\nAfraid of being scorched, you dodge its advance.");
        Graphics.Type(player.fastMode, "\nThe dragon stares at you for a moment, then murmurs something about Shrek and vanishes into nothingness.");
    }

    static void Fire2(Player player)
    {
        Graphics.Type(player.fastMode, "\nYou pick up the torch, but it slips out of your hands.");
        Graphics.Type(player.fastMode, "\nA scrap of parchment lying on the ground erupts into flames, then turns into a squirrel.");
        Graphics.Type(player.fastMode, "\nThe squirrel looks at you in confusion for a moment, before preceding to chuck acorns at you.");
        Graphics.Type(player.fastMode, "\nYou try and grab it, but it snickers as it throws one last acorn at you and disappears in a plume of smoke.");
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
        Graphics.Type(player.fastMode, "\nAs you go to pick up the potion, it explodes in your face.");
        Graphics.Type(player.fastMode, "\nThe horse of judgement and self-satisfaction walks by and cackles at your stupidity.");
    }
}