using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EquipmentType { NULL, WEAPON, GLOVES, GREAVES, ARMOR, HELMET, RING, NECKLACE}
public abstract class EquipmentItem : Item
{
    public EquipmentType EquipmentType;
    public EquipmentItem(string name, string desc, string flavor) : base(name, desc, flavor)
    {
    }


}
