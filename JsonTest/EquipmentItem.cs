public enum EquipmentType { NULL, WEAPON, GLOVES, GREAVES, ARMOR, HELMET, RING, NECKLACE }
public abstract class EquipmentItem : Item
{
    public EquipmentType EquipmentType;
    public Effect Effect;
    public EquipmentItem(string name, string desc, string flavor, EquipmentType type, Effect effect) : base(name, desc, flavor)
    {
        EquipmentType = type;
        Effect = effect;
    }

    public new object Clone()
    {
        var clone = (EquipmentItem)base.Clone();
        clone.EquipmentType = EquipmentType;
        return clone;
    }


}
