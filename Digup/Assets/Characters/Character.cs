using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ICloneable
{
    public string Name;
    public int MaxHp;
    public int HP;
    public int Prot;
    public int Dodge;
    public int AttakModifiers;

    // pr�cision aussi par attaque
    public int Accuracy;
    public int Speed;

    public int Poison = 0; // nb tours -  5-8% /tour, cumul augmente le nb de d�gats
    public bool IsStunned = false;
    public int Burn = 0; // nb tours - 3% des HP/tour, cumul augmente le nb tours
    public int[] Bleed = new int[] { 0, 0 };
    public bool IsParalized = false; // 5 tours
    public bool IsProvoking = false;
    public bool IsProtected = false;
    public bool IsAlert = false; // +75% esquive
    public int Doped = 0; // d�gats sup inflig�s au prochain tour
    public bool HasWithdrawal = false;
    public bool BadTrip = false;


    public Character(string name, int maxHP, int prot, int dodge, int atkMods, int acc, int speed)
    {
        Name = name;
        MaxHp = maxHP;
        HP = maxHP;
        Prot = prot;
        Dodge = dodge;
        AttakModifiers = atkMods;
        Accuracy = acc;
        Speed = speed;
    }

    public object Clone()
    {
        Character copy = this.MemberwiseClone() as Character;
        copy.Bleed = new int[] { 0, 0 };
        return copy;
    }
}
