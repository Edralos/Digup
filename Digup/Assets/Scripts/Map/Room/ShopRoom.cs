using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRoom : StageRoom
{
    public ShopRoom() : this(0)
    {

    }
    public ShopRoom(int depth) : base(depth)
    {
        Name = "Shop Room";
    }
}
