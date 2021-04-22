using System.Collections;
using System.Collections.Generic;

public class RoomTypeDict
{
    public Dictionary<string, TrapRoomType> TrapRoomType { get; set; }
    public Dictionary<string, FountainRoomType> FountainRoomType { get; set; }
    public Dictionary<string, TreasureRoomType> TreasureRoomType { get; set; }
}
