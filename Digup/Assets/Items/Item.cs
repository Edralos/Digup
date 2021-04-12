using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string Name;
    public string Description;
    public string FlavorText;

    public Item(string name, string desc, string flavor)
    {
        Name = name;
        Description = desc;
        FlavorText = flavor;
    }

}
