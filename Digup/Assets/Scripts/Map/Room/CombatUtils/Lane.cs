using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane 
{
    public string Name;
    public Character[] Characters;

    public Lane(string name)
    {
        Name = name;
    }

    public bool AddCharacter(int position, Character character)
    {
        if(Characters[position] == null)
        {

            return true;
        }
        
        return false;
    }
}
