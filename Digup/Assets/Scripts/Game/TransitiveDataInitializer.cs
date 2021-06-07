using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PseudoDict :MonoBehaviour
{
    public string Name;
    public GameObject Prefab;

    public PseudoDict(string name, GameObject gameObject)
    {
        Name = name;
        Prefab = gameObject;
    }
}
public class TransitiveDataInitializer : MonoBehaviour
{
    public bool LoadData;
    public bool LoadPrefabs;
    public List<PseudoDict> AlliesPrefabs;
    public PseudoDict[] EnemiesPrefabs;
    public PseudoDict[] ItemsPrefabs;

    private void Start()
    {
        if (LoadPrefabs)
        {
            AlliesPrefabs.All(a => { GameData.AlliesPrefabs.Add(a.Name, a.Prefab); return true; });
            EnemiesPrefabs.All(a => { GameData.EnemiesPrefabs.Add(a.Name, a.Prefab); return true; });
            ItemsPrefabs.All(a => { GameData.ItemsPrefabs.Add(a.Name, a.Prefab); return true; });
        }
        if (LoadData)
        {
            GameData.LoadDataDictionaries();
        }
    }
}
