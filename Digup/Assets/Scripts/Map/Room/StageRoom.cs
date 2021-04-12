using System.Collections.Generic;

/**
 * Class representing the Room
 * @author Quentin Robard
 */
public class StageRoom
{
    protected string Name;
    protected int Depth;
    protected List<StageRoom> NextRooms;

    public StageRoom(int depth)
    {
        this.Name = "Room";
        this.Depth = depth;
        this.NextRooms = new List<StageRoom>();
    }

    public string getName { get { return this.Name; } }
    public int getDepth { get { return this.Depth; } }
    public List<StageRoom> getNextRooms { get { return this.NextRooms; } }


    /**
     * Add a new room to the next rooms
     */
    public void addNextRoom(StageRoom nextRoom)
    {
        this.NextRooms.Add(nextRoom);
    }
    private string toString()
    {
        return this.Name;
    }
}
