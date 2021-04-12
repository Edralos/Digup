using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private string name;
    private StartRoom startRoom;

    public void initStage()
    {
        /* ---------------------------- */
        /* Randomly generate the stages */
        /* ---------------------------- */

        int Depth = 0;

        //Add the default 1st Room
        startRoom = new StartRoom(Depth);
        Depth++;

        //Add the 2 following CombatRoom
        startRoom.addNextRoom(new CombatRoom(Depth));
        startRoom.addNextRoom(new CombatRoom(Depth));
        Depth++;

        //Randomly add the 10 next depth rooms
        

        //Add 2 break rooms


        //Add the boss room

    }

    private string toString()
    {
        string sRet = "";

        StageRoom currentRoom = startRoom;
        while(currentRoom.getNextRooms.Count != 0)
        {
            Debug.Log("yo");
        }

        return sRet;
    }

    // Start is called before the first frame update
    void Start()
    {
        toString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
