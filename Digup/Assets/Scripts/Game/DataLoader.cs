using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public GameObject CaptainPrefab;
    private Ally Captain;

    // Start is called before the first frame update
    void Start()
    { 
        GameData.LoadDataDictionaries();
        Captain = GameData.GetAlly("Captain");
        Captain.Prefab = CaptainPrefab;

        PartyData.AddPlayer(0, Captain);

    }



    public class CharacterPrefabs{
        public string Name;
        public GameObject Prefab;
    
    }
}
