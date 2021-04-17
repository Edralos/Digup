using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : StageRoom
{
    public TreasureRoom() : this(0)
    {

    }
    public TreasureRoom(int depth) : base(depth)
    {
        Name = "Treasure Room";
    }
}
