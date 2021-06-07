using Assets.Characters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Transitive datas used as references through the game (Items & Character)
/// </summary>
public static class GameData
{
    private const string ROASTER_PATH = @"\Resources\JsonReferences\Roaster.json";
    private const string ENNEMIES_PATH = @"\Resources\JsonReferences\Ennemies.json";
    private const string TRINKETS_PATH = @"\Resources\JsonReferences\Trinkets.json";
    private const string EQUIPMENTS_PATH = @"\Resources\JsonReferences\Equiments.json";
    private const string CONSUMABLES_PATH = @"\Resources\JsonReferences\Consumables.json";
    private static Dictionary<string, Ally> Roaster;
    private static Dictionary<string, Ennemy> Ennemies;
    private static Dictionary<string, TrinketItem> Trinkets;
    private static Dictionary<string, ActiveItem> ActiveEquipments;
    private static Dictionary<string, ConsumableItem> Consumables;

    public static Dictionary<string, GameObject> AlliesPrefabs = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> EnemiesPrefabs = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> ItemsPrefabs = new Dictionary<string, GameObject>();

    /// <summary>
    /// Get a referenced Ally
    /// </summary>
    /// <param name="name">name of Ally</param>
    /// <returns>Copy of a referenced Ally if present, else returns null</returns>
    public static Ally GetAlly(string name)
    {
        if (Roaster == null)
        {
            throw new NullReferenceException("Allies have not been loaded");
        }
        Ally chara;
        Roaster.TryGetValue(name, out chara);
        return (Ally)chara.Clone();

    }

    /// <summary>
    /// Get a referenced Ennemy
    /// </summary>
    /// <param name="name">Name of Ennemy</param>
    /// <returns>Copy of referenced Ennemy if present, else returns null</returns>
    public static Ennemy GetEnnemy(string name)
    {
        if (Ennemies == null)
        {
            throw new NullReferenceException("Ennemies have not been loaded");
        }
        Ennemy ennemy;
        Ennemies.TryGetValue(name, out ennemy);
        return (Ennemy)ennemy.Clone();
    }

    /// <summary>
    /// Get a referenced ActiveItem
    /// </summary>
    /// <param name="name">Name of ActiveItem</param>
    /// <returns>Copy of referenced ActiveItem if present, else returns null</returns>
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

    /// <summary>
    /// Get a referenced Consumable
    /// </summary>
    /// <param name="name">Name of Consumable</param>
    /// <returns>Copy of referenced Consumable if present, else returns null</returns>
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

    /// <summary>
    /// Get a referenced Trinket
    /// </summary>
    /// <param name="name">Name of Trinket</param>
    /// <returns>Copy of referenced Trinket if present, else returns null</returns>
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
    /// Loads all files into reference Ditionaries
    /// </summary>
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

    /// <summary>
    /// Loads Consumables from associated JSON file
    /// </summary>
    private static void LoadConsumables()
    {
        string json = File.ReadAllText(Application.dataPath + CONSUMABLES_PATH);
        Consumables = JsonConvert.DeserializeObject<Dictionary<string, ConsumableItem>>(json);
    }


    /// <summary>
    /// Loads ActiveItems from associated JSON file
    /// </summary>
    private static void LoadEquipments()
    {
        string json = File.ReadAllText(Application.dataPath + EQUIPMENTS_PATH);
        ActiveEquipments = JsonConvert.DeserializeObject<Dictionary<string, ActiveItem>>(json);
    }

    /// <summary>
    /// Loads Ennemies from associated JSON file
    /// </summary>
    private static void LoadEnnemies()
    {
        string json = File.ReadAllText(Application.dataPath + ENNEMIES_PATH);
        Ennemies = JsonConvert.DeserializeObject<Dictionary<string, Ennemy>>(json);
    }

    /// <summary>
    /// Loads Allies from associated JSON file
    /// </summary>
    private static void LoadRoaster()
    {
        string json = File.ReadAllText(Application.dataPath + ROASTER_PATH);
        Roaster = JsonConvert.DeserializeObject<Dictionary<string, Ally>>(json);
    }

    /// <summary>
    /// Loads Trinkets from associated JSON file
    /// </summary>
    private static void LoadTrinkets()
    {
        string json = File.ReadAllText(Application.dataPath + TRINKETS_PATH);
        Trinkets = JsonConvert.DeserializeObject<Dictionary<string, TrinketItem>>(json);
    }

}
