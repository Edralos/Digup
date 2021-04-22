using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that can be consumed to apply an Effect to one or multiple targets
/// </summary>
public class ConsumableItem : Item
{
    public Effect Effect;   

    /// <summary>
    /// ConsumableItem constructor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="desc"></param>
    /// <param name="flavor"></param>
    /// <param name="effect"></param>
    public ConsumableItem(string name, string desc, string flavor ,Effect effect, Rarity rarity) : base(name, desc, flavor, rarity)
    {
        Effect = effect;
    }


}
