using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoomType
{
    public int GoldAmount { get; private set; }
    public int XpAmout { get; private set; }
    public List<Item> Items { get; private set; }
}