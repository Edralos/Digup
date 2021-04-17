using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : StageRoom
{
    public StartRoom() : this(0)
    {

    }
    public StartRoom(int depth) : base(depth)
    {
        Name = "Start Room";
    }
}
