using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EquipmentType { NULL, WEAPON, GLOVES, GREAVES, ARMOR, HELMET, RING, NECKLACE}

/// <summary>
/// Items that can be equipped by Allies
/// </summary>
public abstract class EquipmentItem : Item
{
    public EquipmentType EquipmentType;
    public Effect Effect;

    public EquipmentItem(string name, string desc, string flavor, Effect effect, Rarity rarity, EquipmentType type = EquipmentType.NULL) : base(name, desc, flavor, rarity)
    {
        EquipmentType = type;
        Effect = effect;
    }

    public new object Clone()
    {
        var clone = (EquipmentItem)base.Clone();
        clone.EquipmentType = EquipmentType;
        return clone;
    }


}
