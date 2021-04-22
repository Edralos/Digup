/// <summary>
/// Equipment Item that gives an active ability/attack
/// </summary>
public class ActiveItem : EquipmentItem
{
    public ActiveItem(string name, string desc, string flavor, Effect effect, Rarity rarity, EquipmentType type = EquipmentType.NULL) : base(name, desc, flavor, effect, rarity,type)
    {
    }
}
