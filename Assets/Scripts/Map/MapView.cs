using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapView : MonoBehaviour
{
    [SerializeField] public Tilemap Tilemap;
    [SerializeField] private TileDataManager tileDataManager;
    private TileData defaultTileData;
    private TileData roomTileData;
    private TileData resourceTileData;


    public void Awake()
    {
        if (Tilemap == null)
        {
            //Tilemap = transform.parent?.GetComponentInChildren<Tilemap>();
            Debug.LogError("Tilemap 컴포넌트를 찾을 수 없습니다.");
        }

        InitializeTileData();
    }

    private void InitializeTileData()
    {
        if(tileDataManager == null)
        {
            Debug.LogError("TileDataManager가 할당되지 않았습니다.");
        }

        // TileData 초기화
        defaultTileData = tileDataManager.GetTileDataByType(TileType.Soil);
        if (defaultTileData == null)
        {
            Debug.LogError("Default tile data (Soil) 찾을 수 없습니다.");
        }

        roomTileData = tileDataManager.GetTileDataByType(TileType.Room);
        if (roomTileData == null)
        {
            Debug.LogError("Room tile data 찾을 수 없습니다.");
        }

        resourceTileData = tileDataManager.GetTileDataByType(TileType.Resource);
        if (resourceTileData == null)
        {
            Debug.LogError("Resource tile data 찾을 수 없습니다.");
        }
    }

    public void GenerateMap(Vector3Int position)
    {
        Tilemap.SetTile(position, defaultTileData.tile);
        Tilemap.RefreshAllTiles();
        Debug.LogError("맵 생성");
    }

    public void GenerateRoom(Vector3Int position)
    {
        Tilemap.SetTile(position, roomTileData.tile);
        Tilemap.RefreshAllTiles();
        Debug.LogError("방 생성");
    }

    public void GenerateResource(Vector3Int position)
    {
        Tilemap.SetTile(position, resourceTileData.tile);
        Tilemap.RefreshAllTiles();
        Debug.LogError("자원 생성");
    }

    public void RefreshAllTiles()
    {
        Tilemap.RefreshAllTiles();
    }

    public TileBase GetTile(Vector3Int position)
    {
        return Tilemap.GetTile(position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
