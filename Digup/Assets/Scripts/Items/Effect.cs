using System;
using System.Collections.Generic;
using System.Linq;


public enum EffectType { LIFE, CHARACTERSTAT, STATUS }
public enum TargetType { SELF, ALLY, ENNEMY, ALL_ALLIES, ALL_ENNEMIES }
public enum StatusType { NONE, BURN, BLEED, POISON, STUN, PARALIZE, PROVOKE, ALERT, DOPE, WITHDRAWAL, BAD_TRIP, }
public enum CharacterStatType { NONE, MAX_HP, PROT, ATK, DODGE, SPEED }

/// <summary>
/// Properties of an effect applied to a character
/// </summary>
public class Effect : ICloneable
{

    // NOTE : les effets < 0 sont des retraits. Ex : LIFE avec amount < 0 => dégats sinon heal, STATUS positif => inflige un statut sinon enlève le statut
    public TargetType Target;
    public List<EffectType> EffectTypes;
    // on part du principe que les dictionnaires sont remplis en accord avec les effect types possibles, la liste des Effect type permet 
    // seulement de vérifier qu'un dictionnaire est rempli

    public Dictionary<StatusType, int> StatusAmount;
    public Dictionary<CharacterStatType, int> CharacterStatAmount;
    public List<int> LifeAmounts;

    /// <summary>
    /// Constructor of Effect
    /// </summary>
    /// <param name="targetType">Target which the effect applies to</param>
    /// <param name="effects">Efect types of the effect</param>
    /// <param name="lifeamounts">If LIFE is among the effect types, gives the amounts healed/damaged</param>
    /// <param name="statusamount">If STATUS is among the effect types, gives the amounts of each concerned StatusType</param>
    /// <param name="statamount">If CHARACTERSTAT is among the effect types, gives the amounts of each concerned CharacterStatType</param>
    public Effect(TargetType targetType, IEnumerable<EffectType> effects, IEnumerable<int> lifeamounts = null, Dictionary<StatusType, int> statusamount = null, Dictionary<CharacterStatType, int> statamount = null)
    {
        Target = targetType;
        EffectTypes = effects.Distinct().ToList();
        //check correlation entre types d'effets
        foreach (EffectType effectType in EffectTypes)
        {
            if (effectType == EffectType.CHARACTERSTAT && (statamount?.Count < 1 || statamount == null))
            {
                throw new ArgumentException("Stat effect has been declared but has no associated amounts");
            }
            else if (effectType == EffectType.STATUS && (statusamount?.Count < 1 || statusamount == null))
            {

                throw new ArgumentException("Status effect has been declared but has no associated amounts");
            }
            else if (effectType == EffectType.LIFE && (lifeamounts?.Count() < 1 || lifeamounts == null))
            {

                throw new ArgumentException("Life effect has been declared but has no associated amounts");
            }
        }
        if (lifeamounts == null)
        {
            LifeAmounts = null;
        }
        else
        {

            LifeAmounts = new List<int>(lifeamounts);
        }

        if (statamount == null)
        {

            CharacterStatAmount = null;
        }
        else
        {

            CharacterStatAmount = statamount;
        }

        if (statusamount == null)
        {

            StatusAmount = null;
        }
        else
        {

            StatusAmount = statusamount;
        }
    }

    public object Clone()
    {
        Effect clone = (Effect)MemberwiseClone();
        clone.EffectTypes = new List<EffectType>(EffectTypes);
        clone.StatusAmount = new Dictionary<StatusType, int>(StatusAmount);
        clone.CharacterStatAmount = new Dictionary<CharacterStatType, int>(CharacterStatAmount);
        return clone;

    }
}
