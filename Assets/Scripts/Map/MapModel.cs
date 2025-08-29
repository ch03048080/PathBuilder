using UnityEngine;

public class MapModel
{
    public int mapWidth { get; set; } 
    public int mapHeight { get; set; } 
    public int RoomX { get; set; }
    public int RoomY { get; set; }

    public MapModel(int width, int height)
    {
        mapWidth = width;
        mapHeight = height;
    }
}
