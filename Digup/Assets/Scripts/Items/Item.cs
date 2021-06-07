using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// generic version of Item
/// </summary>
public abstract class Item : ICloneable
{
    public string Name;
    public string Description;
    public string FlavorText;
    public Rarity Rarity;

    public Item(string name, string desc, string flavor, Rarity rarity)
    {
        Name = name;
        Description = desc;
        FlavorText = flavor;
        Rarity = rarity;
    }

    public object Clone()
    {
        return (Item)this.MemberwiseClone();
    }
}

public enum Rarity { COMMON, UNCOMMON, RARE, LEGEND}
