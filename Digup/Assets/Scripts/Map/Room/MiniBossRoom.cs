using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossRoom : StageRoom
{
    public MiniBossRoom() : this(0)
    {

    }
    public MiniBossRoom(int depth) : base(depth)
    {
        Name = "MiniBoss Room";
    }
}
