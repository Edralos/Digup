using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public int Prot;
    public int Dodge;
    public int AttakModifiers;
    // précision aussi par attaque
    public int Accuracy;
    public int Speed;

    public int Poison = 0; // nb tours -  5-8% /tour, cumul augmente le nb de dégats
    public bool isStunned = false;
    public int Burn = 0; // nb tours - 3% des HP/tour, cumul augmente le nb tours
    public int[] Bleed = new int[2];
    public bool isParalized = false; // 5 tours
    public bool isProvoking = false;
    public bool isProtected  = false;
    public bool isAlert = false; // +75% esquive
    public int Doped = 0; // dégats sup infligés au prochain tour
    public bool hasWithdrawal = false;
    public bool BadTrip = false;

   
}
