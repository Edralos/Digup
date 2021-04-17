using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : StageRoom
{
    public BossRoom() : this(0)
    {

    }
    public BossRoom(int depth) : base(depth)
    {
        Name = "Boss Room";
    }
}
