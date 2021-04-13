using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketItem : EquipmentItem
{

    public TrinketItem(string name, string desc, string flavor) : base(name, desc, flavor)
    {
    }

    public new object Clone()
    {
        var clone = (TrinketItem)base.Clone();
        return clone;
    }
}
