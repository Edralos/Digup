using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{

    public Character Character;
    public LifebarBehavior Lifebar;
    public AttackTextBehavior AttackTextBehavior;


    public void ResetStatus()
    {
        Character.Poison = 0;
        Character.IsStunned = false;
        Character.Burn = 0;
        Character.Bleed = new int[] { 0, 0 };
        Character.IsParalized = false;
        Character.IsProvoking = false;
        Character.IsProtected = false;
        Character.IsAlert = false;
        Character.Doped = 0;
        Character.HasWithdrawal = false;
        Character.BadTrip = false;
    }

    public void Init()
    {
        float healthRatio = (float)Character.HP / (float)Character.MaxHp;

        Lifebar.Set(healthRatio);
    }

    public void Heal(int healAmount)
    {
        if (healAmount + Character.HP >= Character.MaxHp)
        {
            Lifebar.Set(1f);
            AttackTextBehavior.DisplayText($"Heal {healAmount}");
            Character.HP = Character.MaxHp;
            return;
        }
        else if (Character.HP <= 0)
        {
            AttackTextBehavior.DisplayText($"Heal {healAmount}");
            return;
        }
        float healedRatio = (float)healAmount / (float)Character.MaxHp;
        healedRatio += Lifebar.HealthTransform.localScale.x;
        Lifebar.Set(healedRatio);
        Character.HP += healAmount;
        AttackTextBehavior.DisplayText($"Heal {healAmount}");

    }

    public void TestDamage(int damageAmount)
    {
        Damage(damageAmount, false);
    }

    public void TestCrit(int damageAmount)
    {
        Damage(damageAmount, true);
    }

    public void Damage(int damageAmount, bool isCrit)
    {
        if (Character.HP - damageAmount <= 0)
        {
            Lifebar.Set(0f);
            if (isCrit)
            {

                AttackTextBehavior.DisplayText($"Crit! {damageAmount}");
            }
            else
            {

                AttackTextBehavior.DisplayText($"Damage {damageAmount}");
            }
            return;

        }
        if (isCrit)
        {
            AttackTextBehavior.DisplayText($"Crit! {damageAmount}");

        }
        else
        {
            AttackTextBehavior.DisplayText($"Damage {damageAmount}");

        }
        Character.HP -= damageAmount;
        float damageRatio = (float)damageAmount / (float)Character.MaxHp;
        Debug.Log($"Damage {damageRatio}");
        damageRatio = Lifebar.HealthTransform.localScale.x - damageRatio;
        Lifebar.Set(damageRatio);


    }
}
