using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabsOnCreate : MonoBehaviour
{
    public GameObject AllyGO;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Ally ally in PartyData.Allies.Values)
        {
            AllyGO = Instantiate(ally.Prefab, new Vector3(0, 0, 0), Quaternion.identity);
            AllyGO.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            CharacterBehavior characterBehavior = AllyGO.GetComponent<CharacterBehavior>();
            characterBehavior.Character = ally;
            characterBehavior.Lifebar.Set(100);
            characterBehavior.Init();
        }
    }

}
