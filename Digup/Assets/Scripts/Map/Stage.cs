using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private string Name;
    private StartRoom StartRoom;

    public Stage(string Name, int NbRooms)
    {
        this.Name = Name;
        InitStage(NbRooms, 3);
    }

    public void InitStage(int MaxDepth, int Width)
    {
        /*-----------------------------------------------*/
        /*         Randomly generate the stages          */
        /*-----------------------------------------------*/
        List<StageRoom> CurrentRooms = new List<StageRoom>();
        List<StageRoom> NextRooms = new List<StageRoom>();
        List<StageRoom> Pool = new List<StageRoom>();

        /*-------------------------------*/
        /*   Fill the Pool with Rooms    */
        /*-------------------------------*/
        int MaxRoomsInPool = (MaxDepth - 4) * Width;
        //50% of Combat rooms

        //25% of Treasure or Trap rooms

        //25% of Other rooms



        for (int Depth = 0; Depth< MaxDepth; Depth++)
        {
            if(Depth == 0) {
                this.StartRoom = new StartRoom(Depth);
                CurrentRooms.Add(this.StartRoom);

                NextRooms.Add(new CombatRoom(Depth));
                NextRooms.Add(new CombatRoom(Depth));
            } else if(Depth == MaxDepth - 1)
            {
                NextRooms.Add(new TreasureRoom(Depth));
                NextRooms.Add(new ShopRoom(Depth));
            } else if(Depth == MaxDepth) {
                NextRooms.Add(new BossRoom(Depth));
            } else {
                //Pick 3 random Room from the Pool

            }

            //For each current rooms
            foreach(StageRoom CurrentRoom in CurrentRooms) {
                //Create a Array copy of the NextRooms
                List<StageRoom> NextRoomsCopy = new List<StageRoom>(NextRooms);
                Debug.Log(NextRoomsCopy);

                //Link the current Room to the next
                for (int i = 0; i < NextRoomsCopy.Count && i<2; i++) {
                    //Pick a random Room 
                    StageRoom RandomNextRoom = NextRoomsCopy[new System.Random().Next(0,NextRoomsCopy.Count)];
                    //Add it to the next Rooms
                    CurrentRoom.addNextRoom(RandomNextRoom);
                    //Delete it from the list
                    NextRoomsCopy.RemoveAt(NextRoomsCopy.IndexOf(RandomNextRoom));
                }
            }

            CurrentRooms = new List<StageRoom>(NextRooms);
            NextRooms = new List<StageRoom>();
        }
    }

    private string ToString()
    {
        string StringRet = "";

        StageRoom currentRoom = StartRoom;
        while(currentRoom.getNextRooms.Count != 0)
        {
            Debug.Log("yo");
        }

        return StringRet;
    }

    // Start is called before the first frame update
    void Start()
    {
        ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
