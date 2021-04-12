using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType { HEAL, DAMAGE, BUFF, DEBUFF, HEAL_STATUS, STATUS }
public enum TargetType { SELF, ALLY, FOE, ALL_ALLIES, ALL_FOES }
public enum StatusType { NONE, BURN, BLEED, POISON, STUN, PARALIZE, PROVOKE, ALERT, DOPE, WITHDRAWAL, BAD_TRIP, }
public enum StatType { NONE, MAX_HP, PROT, ATK, DODGE, SPEED }
public class Effect
{
    
    TargetType Target;
    List<EffectType> Effects;
    Dictionary<StatusType, int> StatusAmount;
    Dictionary<StatType, int> StatAmount;
    int SimpleAmount;

}
