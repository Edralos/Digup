public class TrinketItem : EquipmentItem
{
    public TrinketItem(string name, string desc, string flavor, EquipmentType type, Effect effect) : base(name, desc, flavor, type, effect)
    {
    }

    public new object Clone()
    {
        var clone = (TrinketItem)base.Clone();
        return clone;
    }
}
