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
    private const string ENNEMIES_PATH = @"\Resources\JsonReferences\Enemies.json";
    private const string TRINKETS_PATH = @"\Resources\JsonReferences\Trinkets.json";
    private const string ACTIVE_EQUIPMENTS_PATH = @"\Resources\JsonReferences\ActiveEquipments.json";
    private const string TRINKET_EQUIPMENTS_PATH = @"\Resources\JsonReferences\TrinketEquipments.json";
    private const string CONSUMABLES_PATH = @"\Resources\JsonReferences\Consumables.json";
    private static Dictionary<string, Ally> Roaster;
    private static Dictionary<string, Enemy> Enemies;
    private static Dictionary<string, TrinketItem> Trinkets;
    private static Dictionary<string, ActiveItem> ActiveEquipments;
    private static Dictionary<string, TrinketItem> TrinketEquipments;
    private static Dictionary<string, ConsumableItem> Consumables;

    private static string DataPath;


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
    public static ActiveItem GetActiveEquipment(string name)
    {
        if (ActiveEquipments == null)
        {
            throw new NullReferenceException("Active equipments have not been loaded");
        }
        ActiveItem equipment;
        ActiveEquipments.TryGetValue(name, out equipment);
        return (ActiveItem)equipment.Clone();
    }
    public static TrinketItem GetTrinketEquipment(string name)
    {
        if (TrinketEquipments == null)
        {
            throw new NullReferenceException("Trinket equipments have not been loaded");
        }
        TrinketItem equipment;
        TrinketEquipments.TryGetValue(name, out equipment);
        return (TrinketItem)equipment.Clone();
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
    public async static void LoadDataDictionaries()
    {
        DataPath = Application.dataPath;

        Task loadRoaster = Task.Run(() => LoadRoaster());
        Task loadFoes = Task.Run(() => LoadEnnemies());
        Task loadActiveEquipment = Task.Run(() => LoadActiveEquipments());
        Task loadTrinketEquipment = Task.Run(() => LoadTrinketEquipments());
        Task loadConsumable = Task.Run(() => LoadConsumables());
        Task loadTrinkets = Task.Run(() => LoadTrinkets());
        var res = Task.WhenAll(loadRoaster, loadFoes, loadActiveEquipment, loadTrinketEquipment, loadConsumable, loadTrinkets);
        res.Wait();
        if (res.IsFaulted || res.IsCanceled)
        {
            throw res.Exception;
        }
    }

    private static void LoadConsumables()
    {
        string json = File.ReadAllText(DataPath + CONSUMABLES_PATH);
        Consumables = JsonConvert.DeserializeObject<Dictionary<string, ConsumableItem>>(json);
    }

    private static void LoadActiveEquipments()
    {
        string json = File.ReadAllText(DataPath + ACTIVE_EQUIPMENTS_PATH);
        ActiveEquipments = JsonConvert.DeserializeObject<Dictionary<string, ActiveItem>>(json);
    }

    private static void LoadTrinketEquipments()
    {
        string json = File.ReadAllText(DataPath + TRINKET_EQUIPMENTS_PATH);
        TrinketEquipments = JsonConvert.DeserializeObject<Dictionary<string, TrinketItem>>(json);
    }

    private static void LoadEnnemies()
    {
        string json = File.ReadAllText(DataPath + ENNEMIES_PATH);
        Enemies = JsonConvert.DeserializeObject<Dictionary<string, Enemy>>(json);
    }

    private static void LoadRoaster()
    {
        string json = File.ReadAllText(DataPath + ROASTER_PATH);
        Roaster = JsonConvert.DeserializeObject<Dictionary<string, Ally>>(json);
    }
    private static void LoadTrinkets()
    {
        string json = File.ReadAllText(DataPath + TRINKETS_PATH);
        Trinkets = JsonConvert.DeserializeObject<Dictionary<string, TrinketItem>>(json);
    }

}
