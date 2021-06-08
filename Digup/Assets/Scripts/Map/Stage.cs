using System.Collections.Generic;

/// <summary>
/// Represent the current stage
/// Its composed of a starting room
/// </summary>
public static class Stage
{

    /// <summary>
    /// The name of the stage ex: "Tunnels", "Mountain", "Sky"
    /// </summary>
    public static string Name { get; set; }
    /// <summary>
    /// The max depth where the rooms can go
    /// </summary>
    public static int MaxDepth { get; set; }
    /// <summary>
    /// The starting room of the stage
    /// </summary>
    public static StageRoom CurrentRoom { get; set; }

    /// <summary>
    /// This constructor create a Stage with a name and a max depth
    /// </summary>
    /// <param name="name">Name of the stage</param>
    /// <param name="maxDepth">Max depth of the stage</param>
    //public Stage(string name, int maxDepth)
    //{
    //    Name = name;
    //    MaxDepth = maxDepth;
    //    InitStage();
    //}

    /// <summary>
    /// Initialise the stage by creating a pool of rooms
    /// Then link all rooms one to another
    /// </summary>
    public static void InitStage(string name, int maxDepth)
    {
        Name = name;
        MaxDepth = maxDepth;
        int width = 3;

        List<StageRoom> currentRooms = new List<StageRoom>();
        List<StageRoom> nextRooms = new List<StageRoom>();
        List<StageRoom> pool = new List<StageRoom>();

        /*-------------------------------*/
        /*   Fill the Pool with Rooms    */
        /*-------------------------------*/
        int maxRoomsInPool = (MaxDepth) * width; // 3 is the max 
        System.Random rand = new System.Random();
        int randInt;
        while (pool.Count < maxRoomsInPool)
        {
            //Les Rooms sont mises à 0 de Profondeur
            //elles sont mises à jour dans les ajouts suivants lors de la liaison
            randInt = rand.Next(100);
            if (randInt < 50)
            { //50% of Combat rooms
                pool.Add(new CombatRoom());
            }
            else if (randInt < 75)
            { //25% of Treasure or Trap rooms
                switch (rand.Next(2))
                { // 1/2 est une treasure l'autre une Trap
                    case 0:
                        pool.Add(new TreasureRoom());
                        break;
                    case 1:
                        pool.Add(new TrapRoom());
                        break;
                }
            }
            else
            { //25% of Other rooms
                switch (rand.Next(3))
                { // Randomly add one of each following Rooms
                    case 0:
                        pool.Add(new MiniBossRoom());
                        break;
                    case 1:
                        pool.Add(new FountainRoom());
                        break;
                    case 2:
                        pool.Add(new ShopRoom());
                        break;
                }
            }
        }

        /*-------------------------------*/
        /*  Create the room progression  */
        /*-------------------------------*/
        for (int depth = 0; depth < MaxDepth; depth++)
        {
            if (depth == 0) //Démarrer avec 1 StartRoom et ensuite 2 CombatRoom
            {
                CurrentRoom = new StartRoom(depth);
                currentRooms.Add(CurrentRoom);

                nextRooms.Add(new CombatRoom(depth));
                nextRooms.Add(new CombatRoom(depth));
            }
            else if (depth > 0 && depth < MaxDepth - 3) //Apres les 1er salles et avant les salles de fin
            {
                //Pick 3 random Room from the Pool
                StageRoom randomNextRoom;
                for (int i = 0; i < width; i++)
                {
                    int r = rand.Next(0, pool.Count);
                    //Pick a random Room 
                    randomNextRoom = pool[r];
                    //Change the Depth of these rooms
                    randomNextRoom.Depth = depth;
                    //Add it to the next rooms
                    nextRooms.Add(randomNextRoom);
                    //Remove it from the pool
                    pool.RemoveAt(pool.IndexOf(randomNextRoom));
                }
            }
            else if (depth == MaxDepth - 3) //Avant le boss 2 salles de repos
            {
                nextRooms.Add(new TreasureRoom(depth));
                nextRooms.Add(new ShopRoom(depth));
            }
            else if (depth == MaxDepth - 2) //Dernière salle est la salle de boss
            {
                nextRooms.Add(new BossRoom(depth));
            }

            //For each current rooms
            List<StageRoom> nextRoomsCopy;
            foreach (StageRoom currentRoom in currentRooms)
            {
                //Create a Array copy of the NextRooms
                nextRoomsCopy = new List<StageRoom>(nextRooms);
                //Link the current Room to the nexts (tirage sans remise)
                for (int i = 0; i < 2 && nextRoomsCopy.Count > 0; i++)
                {
                    //Pick a random Room
                    StageRoom randomNextRoom = nextRoomsCopy[rand.Next(0, nextRoomsCopy.Count)];
                    //Add it to the next Rooms
                    currentRoom.addNextRoom(randomNextRoom);
                    //Delete it from the list
                    nextRoomsCopy.RemoveAt(nextRoomsCopy.IndexOf(randomNextRoom));
                }
            }

            currentRooms = new List<StageRoom>(nextRooms);
            nextRooms = new List<StageRoom>();
        }
    }
}
