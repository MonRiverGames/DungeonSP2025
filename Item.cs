using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsConsumable { get; set; }
    
    public Item(string name)
    {
        Name = name;
        if (name=="Rubies"){
            Description=" dazzling red ruby the color of human blood";
            IsConsumable=false;
        }
        else if (name=="Gold"){
            Description=" heavy bar weighing almost a much a child";
            IsConsumable=false;
        }
        else if (name=="Emeralds"){
            Description=" 8x8 png picture of a minecraft emerald and as you pick you hear a distant 'hrrrrr' ";
            IsConsumable=false;
        }
        else if (name=="Diamonds"){
            Description=" 32k diamond with no imperfections";
            IsConsumable=false;
        }
        else if (name=="Poison Spell"){
            Description="n old parchment that stinks of sulfur and death";
            IsConsumable=true;
        }
        else if (name=="Fire Spell"){
            Description="n old scroll that is warm to the touch and smells like campfire";
            IsConsumable=true;
        }
        else if (name=="Regen Spell"){
            Description="n old paper that feels like a bandage and has the aroma of an emergency room";
            IsConsumable=true;
        }
        else if (name=="Ice Spell"){
            Description=" cold sheet of papyrus that has frost on the corners";
            IsConsumable=true;
        }
        else if (name=="Key"){
            Description="n old copper key";
            IsConsumable=true;
        }
        else
        {
            Description="";
            IsConsumable=false;
        }
    }
}

