/// <summary>
/// Equipment Item that gives an active ability/attack
/// </summary>
public class ActiveItem : EquipmentItem
{
    /// <summary>
    /// ActiveItem constructor
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="desc">Description</param>
    /// <param name="flavor">Flavor text</param>
    /// <param name="effect">Effect</param>
    /// <param name="rarity">Rarity</param>
    /// <param name="type">Equipment type. default : NULL</param>
    public ActiveItem(string name, string desc, string flavor, Effect effect, Rarity rarity, EquipmentType type = EquipmentType.NULL) : base(name, desc, flavor, effect, rarity,type)
    {
    }
}
