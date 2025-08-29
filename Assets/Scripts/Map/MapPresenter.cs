using UnityEngine;
using UnityEngine.Tilemaps;

public class MapPresenter : MonoBehaviour
{
    [SerializeField] private MapView mapView;
    [SerializeField] private TileDataManager tileDataManager;
    [SerializeField] public Tilemap tilemap;
    int mapWidth = 32;  // 맵의 가로 크기
    int mapHeight = 18; // 맵의 세로 크기

    private MapModel mapModel;
    
    private void Start()
    {
        mapModel = new MapModel(mapWidth, mapHeight);

        GenerateMap();
        GenerateRoom();
        GenerateResource();
    }

    private void GenerateMap()
    {

        int startX = -mapModel.mapWidth / 2;
        int startY = -mapModel.mapHeight / 2;

        for (int x = 0; x < mapModel.mapWidth; x++)
        {
            for (int y = 0; y < mapModel.mapHeight; y++)
            {
                Vector3Int position = new Vector3Int(startX + x, startY + y, 0);
                mapView.GenerateMap(position);
            }
        }

        tileDataManager.MarkEdgesAsWall(mapView.Tilemap);
    }

    private void GenerateRoom()
    {
        int roomWidth = 4;
        int roomHeight = 3;

        mapModel.RoomX = Random.Range(-mapModel.mapWidth / 4, mapModel.mapWidth / 4 - roomWidth);
        mapModel.RoomY = Random.Range(-mapModel.mapWidth / 4, mapModel.mapWidth / 4 - roomHeight);


        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomHeight; y++)
            {
                Vector3Int position = new Vector3Int(mapModel.RoomX + x, mapModel.RoomY + y, 0);
                mapView.GenerateRoom(position);
            }
        }

    }

    private void GenerateResource()
    {

        int resourceX = Random.Range(mapModel.RoomX - 4, mapModel.RoomX + 9);
        int resourceY = Random.Range(1, 3);

        if (resourceY == 1) resourceY = mapModel.RoomY - 4;
        else resourceY = mapModel.RoomY + 7;

        if (resourceX == mapModel.RoomX - 4 || resourceX == mapModel.RoomX + 9)
        {
            resourceY = Random.Range(mapModel.RoomY - 4, mapModel.RoomY + 8);
        }

        Vector3Int position = new Vector3Int(resourceX, resourceY, 0);
        mapView.GenerateResource(position);

    }
    void Update()
    {
        if(mapView == null)
        {
            Debug.LogError("MapView is not assigned in MapController!");
        }
        if(mapView.Tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned in MapView!");
        }
    }
}
