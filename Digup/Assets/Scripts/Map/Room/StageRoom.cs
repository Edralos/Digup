using System.Collections.Generic;

/**
 * Class representing the Room
 * @author Quentin Robard
 */
public class StageRoom
{
    protected string Name { get; set; }
    protected int Depth { get; set; }
    public List<StageRoom> NextRooms { get; protected set; }

    /**
     * Default constructor without params
     */
    public StageRoom()
    {
        this.Name = "Room";
        this.Depth = 0;
        this.NextRooms = new List<StageRoom>();
    }
    
    /**
     * Default constructor without params
     * @params Depth, the depth of the room withint the Stage
     */
    public StageRoom(int Depth)
    {
        this.Name = "Room";
        this.Depth = Depth;
        this.NextRooms = new List<StageRoom>();
    }

    /**
     * Add a new room to the next rooms
     */
    public void addNextRoom(StageRoom NextRoom)
    {
        this.NextRooms.Add(NextRoom);
    }
    private string toString()
    {
        return this.Name;
    }
}
