using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side 
{
    public Lane FrontLane { get; set; }
    public Lane BackLane { get; set; }

    public Side()
    {
        FrontLane = new Lane("front");
        BackLane = new Lane("back");
    }
}
