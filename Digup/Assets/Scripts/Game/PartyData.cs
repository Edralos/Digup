using Assets.Characters;
using System.Collections.Generic;

public static class PartyData
{
    public static Dictionary<int, Ally> Allies { get; private set; }

    public static Ally RemoveAlly(int id)
    {
        Ally character = Allies[id];
        Allies.Remove(id);
        return character;
    }

    public static void AddPlayer(int id, Ally character)
    {
        Allies.Add(id, character);
    }
    
}
