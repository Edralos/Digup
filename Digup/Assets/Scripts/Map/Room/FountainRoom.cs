using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainRoom : StageRoom
{
    public FountainRoom() : this(0)
    {

    }
    public FountainRoom(int depth) : base(depth)
    {
        Name = "Fountain Room";
    }
}
