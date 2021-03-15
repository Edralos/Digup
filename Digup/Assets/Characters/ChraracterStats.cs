using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChraracterStats : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public int MaxHp;
    public int HP;
    public int Prot;
    public int Dodge;
    public int AttakModifiers;
    // pr�cision aussi par attaque
    public int Accuracy;
    public int Speed;

    public int Poison = 0; // nb tours -  5-8% /tour, cumul augmente le nb de d�gats
    public bool isStunned = false;
    public int Burn = 0; // nb tours - 3% des HP/tour, cumul augmente le nb tours
    public int[] Bleed = new int[] { 0, 0 };
    public bool isParalized = false; // 5 tours
    public bool isProvoking = false;
    public bool isProtected = false;
    public bool isAlert = false; // +75% esquive
    public int Doped = 0; // d�gats sup inflig�s au prochain tour
    public bool hasWithdrawal = false;
    public bool BadTrip = false;

    public LifebarBehavior Lifebar;
    public AttackTextBehavior AttackTextBehavior;


    public void ResetStatus()
    {
        Poison = 0;
        isStunned = false;
        Burn = 0;
        Bleed = new int[] { 0, 0 };
        isParalized = false;
        isProvoking = false;
        isProtected = false;
        isAlert = false;
        Doped = 0;
        hasWithdrawal = false;
        BadTrip = false;


    }

    private void Start()
    {
        float healthRatio = (float)HP / (float)MaxHp;

        Lifebar.Set(healthRatio);
    }

    public void Heal(int healAmount)
    {
        if (healAmount + HP >= MaxHp)
        {
            Lifebar.Set(1f);
            AttackTextBehavior.DisplayText($"Heal {healAmount}");
            HP = MaxHp;
            return;
        }
        else if (HP <= 0)
        {
            AttackTextBehavior.DisplayText($"Heal {healAmount}");
            return;
        }
        float healedRatio = (float)healAmount / (float)MaxHp;
        healedRatio += Lifebar.HealthTransform.localScale.x;
        Lifebar.Set(healedRatio);
        HP += healAmount;
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
        if (HP - damageAmount <= 0)
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
        HP -= damageAmount;
        float damageRatio = (float)damageAmount / (float)MaxHp;
        Debug.Log($"Damage {damageRatio}");
        damageRatio = Lifebar.HealthTransform.localScale.x - damageRatio;
        Lifebar.Set(damageRatio);


    }
}
