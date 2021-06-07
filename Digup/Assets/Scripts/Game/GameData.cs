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
    private const string ENNEMIES_PATH = @"\Resources\JsonReferences\Enemies.json";
    private const string TRINKETS_PATH = @"\Resources\JsonReferences\Trinkets.json";
    private const string ACTIVE_EQUIPMENTS_PATH = @"\Resources\JsonReferences\ActiveEquipments.json";
    private const string CONSUMABLES_PATH = @"\Resources\JsonReferences\Consumables.json";
    private static Dictionary<string, Ally> Roaster;
    private static Dictionary<string, Enemy> Enemies;
    private static Dictionary<string, TrinketItem> Trinkets;
    private static Dictionary<string, ActiveItem> ActiveEquipments;
    private static Dictionary<string, ConsumableItem> Consumables;

    public static Dictionary<string, GameObject> AlliesPrefabs = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> EnemiesPrefabs = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> ItemsPrefabs = new Dictionary<string, GameObject>();

    private static string DataPath;

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
    public static Enemy GetEnemy(string name)
    {
        if (Enemies == null)
        {
            throw new NullReferenceException("Ennemies have not been loaded");
        }
        Enemy enemy;
        Enemies.TryGetValue(name, out enemy);
        return (Enemy)enemy.Clone();
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
            throw new NullReferenceException("Active equipments have not been loaded");
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
        DataPath = Application.dataPath;

        Task loadRoaster = Task.Run(() => LoadRoaster());
        Task loadFoes = Task.Run(() => LoadEnnemies());
        Task loadActiveEquipment = Task.Run(() => LoadActiveEquipments());
        Task loadConsumable = Task.Run(() => LoadConsumables());
        Task loadTrinkets = Task.Run(() => LoadTrinkets());
        var res = Task.WhenAll(loadRoaster, loadFoes, loadActiveEquipment/*, loadConsumable*//*, loadTrinkets*/);
        try
        { 
            res.Wait();
        }
        catch (Exception) { }
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
        string json = File.ReadAllText(DataPath + CONSUMABLES_PATH);
        Consumables = JsonConvert.DeserializeObject<Dictionary<string, ConsumableItem>>(json);
    }


    /// <summary>
    /// Loads ActiveItems from associated JSON file
    /// </summary>
    private static void LoadActiveEquipments()
    {
        string json = File.ReadAllText(DataPath + ACTIVE_EQUIPMENTS_PATH);
        ActiveEquipments = JsonConvert.DeserializeObject<Dictionary<string, ActiveItem>>(json);
    }

    /// <summary>
    /// Loads Ennemies from associated JSON file
    /// </summary>
    private static void LoadEnnemies()
    {
        string json = File.ReadAllText(DataPath + ENNEMIES_PATH);
        Enemies = JsonConvert.DeserializeObject<Dictionary<string, Enemy>>(json);
    }

    /// <summary>
    /// Loads Allies from associated JSON file
    /// </summary>
    private static void LoadRoaster()
    {
        string json = File.ReadAllText(DataPath + ROASTER_PATH);
        Roaster = JsonConvert.DeserializeObject<Dictionary<string, Ally>>(json);
    }

    /// <summary>
    /// Loads Trinkets from associated JSON file
    /// </summary>
    private static void LoadTrinkets()
    {
        string json = File.ReadAllText(DataPath + TRINKETS_PATH);
        Trinkets = JsonConvert.DeserializeObject<Dictionary<string, TrinketItem>>(json);
    }

}
