using System;
using System.Collections.Generic;

public enum EffectType { HEAL, DAMAGE, BUFF, DEBUFF, HEAL_STATUS, STATUS }
public enum TargetType { SELF, ALLY, FOE, ALL_ALLIES, ALL_FOES }
public enum StatusType { NONE, BURN, BLEED, POISON, STUN, PARALIZE, PROVOKE, ALERT, DOPE, WITHDRAWAL, BAD_TRIP, }
public enum StatType { NONE, MAX_HP, PROT, ATK, DODGE, SPEED }
public class Effect : ICloneable
{

    TargetType Target;
    List<EffectType> Effects;
    Dictionary<StatusType, int> StatusAmount;
    Dictionary<StatType, int> StatAmount;
    int SimpleAmount;



    public object Clone()
    {
        Effect clone = (Effect)this.MemberwiseClone();
        clone.Effects = new List<EffectType>(Effects);
        clone.StatusAmount = new Dictionary<StatusType, int>(StatusAmount);
        clone.StatAmount = new Dictionary<StatType, int>(StatAmount);
        return clone;

    }
}
