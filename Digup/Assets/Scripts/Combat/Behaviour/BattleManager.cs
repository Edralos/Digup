using Assets.Characters;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Etats du combat
/// </summary>
public enum BattleState { START, ACTION_PICK, WON, LOST }
public class BattleManager : MonoBehaviour
{
    public const float CRITICALMOD = 1.5f;
    public List<GameObject> Allies;
    public List<GameObject> Ennemies;
    private List<Character> TurnOrder;
    List<Character> Characters = new List<Character>();

    BattleState State;

    private void Start()
    {

        State = BattleState.START;
        Ally player = GameData.GetAlly("captain");

        foreach (var chara in Allies)
        {
            
        }
        foreach (var chara in Ennemies)
        {
            Characters.Add(chara.GetComponent<Character>());

        }
    }



    void RollSpeed()
    {
        Dictionary<Character, int> speedrolls = new Dictionary<Character, int>();
        foreach (var chara in Characters)
        {
            int res = Mathf.RoundToInt(Random.Range(1, 6));
            speedrolls.Add(chara, res);
        }
        while (speedrolls.Count > 0)
        {
            var max = speedrolls.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            TurnOrder.Add(max);
            speedrolls.Remove(max);
        }
        Debug.Log("Speed rolled with success");
    }


    int RollAttack(Character chara, Effect effect)
    {
        if (Random.Range(0, 100) >= 95)
        {
            return Mathf.RoundToInt(effect.LifeAmounts[0][1] * CRITICALMOD);
        }
        return chara.AttakModifiers + Mathf.RoundToInt(Random.Range(effect.LifeAmounts[0][0], effect.LifeAmounts[0][1]));
    }

    int RollHeal(Effect effect)
    {
        if (effect.LifeAmounts.Count > 1)
        {
            if (Random.Range(0, 100) >= 95)
            {
                return Mathf.RoundToInt(effect.LifeAmounts[1][1] * CRITICALMOD);
            }
            return Mathf.RoundToInt(Random.Range(effect.LifeAmounts[1][0], effect.LifeAmounts[1][1]));
        }
        else
        {
            if (Random.Range(0, 100) >= 95)
            {
                return Mathf.RoundToInt(effect.LifeAmounts[1][1] * CRITICALMOD);
            }
            return Mathf.RoundToInt(Random.Range(effect.LifeAmounts[0][0], effect.LifeAmounts[0][1]));
        }
    }



    bool IsTargetValid(Character target, Effect effect)
    {
        if (target is Enemy)
        {
            return effect.Target == TargetType.ENNEMY;
        }
        else
        {
            return effect.Target == TargetType.ALLY;
        }


    }
}
