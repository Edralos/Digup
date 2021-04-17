using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private string Name { get; set; }
    private int MaxDepth { get; set; }
    private StartRoom StartRoom { get; set; }

    public Stage(string Name, int MaxDepth)
    {
        this.Name = Name;
        this.MaxDepth = MaxDepth;
        InitStage();
    }

    public void InitStage()
    {
        Debug.Log("------------------------\nStart Init");

        /*-----------------------------------------------*/
        /*         Randomly generate the stages          */
        /*-----------------------------------------------*/
        List<StageRoom> CurrentRooms = new List<StageRoom>();
        List<StageRoom> NextRooms = new List<StageRoom>();
        List<StageRoom> Pool = new List<StageRoom>();

        /*-------------------------------*/
        /*   Fill the Pool with Rooms    */
        /*-------------------------------*/
        int MaxRoomsInPool = (MaxDepth - 4) * 3; // 3 is the max width
        while(Pool.Count < MaxRoomsInPool)
        {
            Debug.Log("Pool Count:" + Pool.Count + " - Max Rooms:" + MaxDepth);
            /**
             * Les Rooms sont mises à 0 de Profondeur 
             * et sont mises à jour dans les ajouts suivants
             */
            int Rand = (int) new System.Random().Next(0,100);
            if(Rand < 50) { //50% of Combat rooms
                Pool.Add(new CombatRoom(0));
            } else if (Rand < 75) { //25% of Treasure or Trap rooms
                switch(new System.Random().Next(0,1)) { // 1/2 est une treasure l'autre une Trap
                    case 0:
                        Pool.Add(new TreasureRoom());
                        break;
                    case 1:
                        Pool.Add(new TrapRoom());
                        break;
                } 
            } else { //25% of Other rooms
                switch(new System.Random().Next(0, 2)) { // Randomly add one of each following Rooms
                    case 0:
                        Pool.Add(new MiniBossRoom());
                        break;
                    case 1:
                        Pool.Add(new FountainRoom());
                        break;
                    case 2:
                        Pool.Add(new ShopRoom());
                        break;
                }
            }

        }

        /*-------------------------------*/
        /*  Create the room progression  */
        /*-------------------------------*/
        for (int Depth = 0; Depth< MaxDepth; Depth++)
        {
            if(Depth == 0) { //Démarrer avec 1 StartRoom et ensuite 2 CombatRoom
                this.StartRoom = new StartRoom(Depth);
                CurrentRooms.Add(this.StartRoom);

                NextRooms.Add(new CombatRoom(Depth));
                NextRooms.Add(new CombatRoom(Depth));
            } else if(Depth == MaxDepth - 1) { //Avant le boss 2 salles de repos
                NextRooms.Add(new TreasureRoom(Depth));
                NextRooms.Add(new ShopRoom(Depth));
            } else if(Depth == MaxDepth) { //Dernière salle est la salle de boss
                NextRooms.Add(new BossRoom(Depth));
            } else {
                //Pick 3 random Room from the Pool


                //Change the Depth of these rooms
            }

            //For each current rooms
            foreach(StageRoom CurrentRoom in CurrentRooms) {
                //Create a Array copy of the NextRooms
                List<StageRoom> NextRoomsCopy = new List<StageRoom>(NextRooms);
                Debug.Log(NextRoomsCopy);

                //Link the current Room to the next (tirage sans remise)
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


        Debug.Log("------------------------\nInit finished");
    }

    new private string ToString()
    {
        string StringRet = this.Name;

        StageRoom CurrentRoom = StartRoom;
        while(CurrentRoom.NextRooms.Count != 0)
        {
            Debug.Log("yo");
        }

        return StringRet;
    }



    // Start is called before the first frame update
    void Start()
    {
        Stage Stage = new Stage("Tunnels", 12);
        Debug.Log("Stage = "+ Stage.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
