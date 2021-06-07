using System.Collections.Generic;

/// <summary>
/// This class represent a Room within a Stage
/// It can be different type of Rooms, this class is the parent class
/// for other more specific classes
/// </summary>
public class StageRoom
{
    /// <summary>
    /// Name: the name of the room ("Combat", "Fake treasure", "Life fountain")
    /// </summary>
    protected string Name { get; set; }
    /// <summary>
    /// Depth: The depth of the room in the stage
    /// </summary>
    public int Depth { get; set; }
    /// <summary>
    /// Difficulty: The difficulty of the room, it's a multiplicator that will impact the nb of enemies or the damages the players can loose on a trap
    /// </summary>
    protected int Difficulty { get; set; }

    /// <summary>
    /// NextRooms: The rooms that will be available next when you're in this room
    /// </summary>
    public List<StageRoom> NextRooms { get; protected set; }


    /// <summary>
    /// Empty contructor
    /// Depth value for this constructor is 0
    /// </summary>
    public StageRoom() : this(0)
    {

    }

    /// <summary>
    /// One param constructor
    /// It create a Room at a specified depth
    /// </summary>
    /// <param name="depth">The depth of the room within the Stage</param>
    public StageRoom(int depth, int difficulty = 1)
    {
        Name = "Room";
        Depth = depth;
        NextRooms = new List<StageRoom>();
        Difficulty = difficulty;
    }

    /// <summary>
    /// Add a new room to next rooms of the current room
    /// </summary>
    /// <param name="nextRoom">The room to add in the next Rooms</param>
    public void addNextRoom(StageRoom nextRoom)
    {
        this.NextRooms.Add(nextRoom);
    }
    private string toString()
    {
        return Name;
    }
}
