using Assets.Characters;
using System.Collections.Generic;

public static class PartyData
{
    public static Dictionary<int, Ally> Allies { get; private set; } = new Dictionary<int, Ally>();

    public static Ally RemoveAlly(int id)
    {
        Ally character = Allies[id];
        Allies.Remove(id);
        return character;
    }

    public static void AddPlayer(int id, Ally character)
    {
        Ally a;
        if(!Allies.TryGetValue(id, out a))
        {
            Allies.Add(id, character);
        }
    }
    
}
