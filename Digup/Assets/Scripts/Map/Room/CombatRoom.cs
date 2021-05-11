using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for combat rooms with enemy and allies available positionning
 * @author Quentin Robard
 */
public class CombatRoom : StageRoom
{
    public Side AllySide { get; set; }
    public Side EnemySide { get; set; }

    public CombatRoom(): this(0)
    {

    }

    public CombatRoom(int depth) : base(depth)
    {
        Name = "Combat Room";
    }

}
