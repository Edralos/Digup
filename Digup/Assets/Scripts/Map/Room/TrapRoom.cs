using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRoom : StageRoom
{
    public TrapRoom() : this(0)
    {

    }
    public TrapRoom(int depth) : base(depth)
    {
        Name = "Trap Room";
    }
}
