public class ConsumableItem : Item
{
    public Effect Effect;

    public ConsumableItem(string name, string desc, string flavor, Effect effect) : base(name, desc, flavor)
    {
        Effect = effect;
    }


}
