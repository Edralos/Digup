using System;

public abstract class Item : ICloneable
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

    public object Clone()
    {
        return (Item)this.MemberwiseClone();
    }
}
