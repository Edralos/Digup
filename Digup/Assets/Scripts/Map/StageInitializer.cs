using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading datas");
        //Avant on charge les ressources
        GameData.LoadDataDictionaries();
        

        Debug.Log("Creating stage");
        //Ici on créer la map
        Stage Stage = new Stage("Tunnels", 12);
    }

}
