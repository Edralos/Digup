using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane
{
    public string Name;
    public Character[] Characters;

    public Lane(string name)
    {
        Characters = new Character[6];
        Name = name;
    }

    public bool AddCharacter(int position, Character character)
    {
        if(Characters[position] == null)
        {
            Characters[position] = character;
            return true;
        }
        
        return false;
    }
}
