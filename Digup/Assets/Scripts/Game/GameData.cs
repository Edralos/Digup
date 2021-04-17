using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Transitive datas used as references through the game
/// </summary>
public static class GameData
{
    private const string ROASTER_PATH = @"\Resources\JsonReferences\Roaster.json";
    private const string ENNEMIES_PATH = @"\Resources\JsonReferences\Ennemies.json";
    private const string TRINKETS_PATH = @"\Resources\JsonReferences\Trinkets.json";
    private const string EQUIPMENTS_PATH = @"\Resources\JsonReferences\Equiments.json";
    private const string CONSUMABLES_PATH = @"\Resources\JsonReferences\Consumables.json";
    private static Dictionary<string, Character> Roaster;
    private static Dictionary<string, Character> Ennemies;
    private static Dictionary<string, TrinketItem> Trinkets;
    private static Dictionary<string, ActiveItem> ActiveEquipments;
    private static Dictionary<string, ConsumableItem> Consumables;


    public static Character GetAlly(string name)
    {
        if (Roaster == null)
        {
            throw new NullReferenceException("Allies have not been loaded");
        }
        Character chara;
        Roaster.TryGetValue(name, out chara);
        return (Character)chara.Clone();

    }
    public static Character GetEnnemy(string name)
    {
        if (Ennemies == null)
        {
            throw new NullReferenceException("Ennemies have not been loaded");
        }
        Character ennemy;
        Ennemies.TryGetValue(name, out ennemy);
        return (Character)ennemy.Clone();
    }
    public static ActiveItem GetEquipment(string name)
    {
        if (ActiveEquipments == null)
        {
            throw new NullReferenceException("Equipments have not been loaded");
        }
        ActiveItem equipment;
        ActiveEquipments.TryGetValue(name, out equipment);
        return (ActiveItem)equipment.Clone();
    }
    public static ConsumableItem GetConsumable(string name)
    {
        if (Consumables == null)
        {
            throw new NullReferenceException("Consumables have not been loaded");
        }

        ConsumableItem consumable;
        Consumables.TryGetValue(name, out consumable);
        return (ConsumableItem)consumable.Clone();
    }

    public static TrinketItem GetTrinket(string name)
    {
        if (Consumables == null)
        {
            throw new NullReferenceException("Trinkets have not been loaded");
        }

        TrinketItem trinket;
        Trinkets.TryGetValue(name, out trinket);
        return (TrinketItem)trinket.Clone();
    }

    /// <summary>
    /// Loads all Dictionaries from Json reference game files
    /// </summary>
    /// <param name="roasterFile"></param>
    /// <param name="foeFile"></param>
    /// <param name="equipmentFile"></param>
    /// <param name="consumableFiles"></param>
    public static void LoadDataDictionaries()
    {
        Task loadRoaster = new Task(() => LoadRoaster());
        Task loadFoes = new Task(() => LoadEnnemies());
        Task loadEquipment = new Task(() => LoadEquipments());
        Task loadConsumable = new Task(() => LoadConsumables());
        Task loadTrinkets = new Task(() => LoadTrinkets());
        var res = Task.WhenAll(loadRoaster, loadFoes, loadEquipment, loadConsumable, loadTrinkets);
        if (res.IsFaulted || res.IsCanceled)
        {
            throw res.Exception;
        }


    }

    private static void LoadConsumables()
    {
        string json = File.ReadAllText(Application.dataPath + CONSUMABLES_PATH);
        Consumables = JsonConvert.DeserializeObject<Dictionary<string, ConsumableItem>>(json);
    }

    private static void LoadEquipments()
    {
        string json = File.ReadAllText(Application.dataPath + EQUIPMENTS_PATH);
        ActiveEquipments = JsonConvert.DeserializeObject<Dictionary<string, ActiveItem>>(json);
    }

    private static void LoadEnnemies()
    {
        string json = File.ReadAllText(Application.dataPath + ENNEMIES_PATH);
        Ennemies = JsonConvert.DeserializeObject<Dictionary<string, Character>>(json);
    }

    private static void LoadRoaster()
    {
        string json = File.ReadAllText(Application.dataPath + ROASTER_PATH);
        Roaster = JsonConvert.DeserializeObject<Dictionary<string, Character>>(json);
    }
    private static void LoadTrinkets()
    {
        string json = File.ReadAllText(Application.dataPath + TRINKETS_PATH);
        Trinkets = JsonConvert.DeserializeObject<Dictionary<string, TrinketItem>>(json);
    }

}
