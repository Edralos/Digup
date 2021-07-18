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

    // la liste int[] est de taille 2. Dans le cas où il y aurait 2 LifeAmount,  le 1er LifeAmount est un dégat et le 2e un Heal
    public List<int[]> LifeAmounts;

   

    public object Clone()
    {
        Effect clone = (Effect)MemberwiseClone();
        clone.EffectTypes = new List<EffectType>(EffectTypes);
        clone.StatusAmount = new Dictionary<StatusType, int>(StatusAmount);
        clone.CharacterStatAmount = new Dictionary<CharacterStatType, int>(CharacterStatAmount);
        return clone;

    }
}
