using UnityEngine;

public class ChracterStats : MonoBehaviour
{
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

    public int Heal(int healAmount)
    {
        if (healAmount + HP >= MaxHp)
        {
            return 0;
        }
        return 0;
    }

}
