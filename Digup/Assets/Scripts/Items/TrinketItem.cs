/// <summary>
/// Equipment that gives Character stats effects (passive) to an Ally
/// </summary>
public class TrinketItem : EquipmentItem
{
    /// <summary>
    /// TrinketItem constructor
    /// </summary>
    /// <param name="name">Trinket name</param>
    /// <param name="desc">Description</param>
    /// <param name="flavor">Flavor text</param>
    /// <param name="type">Equipment type if wearable. Default : NULL</param>
    /// <param name="effect"></param>
    public TrinketItem(string name, string desc, string flavor, Effect effect, Rarity rarity, EquipmentType type = EquipmentType.NULL) : base(name, desc, flavor, effect, rarity, type)
    {
    }

    public new object Clone()
    {
        var clone = (TrinketItem)base.Clone();
        return clone;
    }
}
