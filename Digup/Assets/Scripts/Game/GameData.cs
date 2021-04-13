using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    private static Dictionary<string,Character> Roaster;
    private static Dictionary<string,Character> Foes;
    private static Dictionary<string, EquipmentItem> Equipments;
    private static Dictionary<string, ConsumableItem> Consumables;


    public static Character GetCharacter(string name) { return (Character)Roaster[name].Clone(); }
    public static Character GetFoe(string name) { return (Character)Foes[name].Clone(); }
    public static EquipmentItem GetEquipment(string name) { return (EquipmentItem)Equipments[name].Clone(); }



}
