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
            Debug.LogError("Tilemap ������Ʈ�� ã�� �� �����ϴ�.");
        }

        InitializeTileData();
    }

    private void InitializeTileData()
    {
        if(tileDataManager == null)
        {
            Debug.LogError("TileDataManager�� �Ҵ���� �ʾҽ��ϴ�.");
        }

        // TileData �ʱ�ȭ
        defaultTileData = tileDataManager.GetTileDataByType(TileType.Soil);
        if (defaultTileData == null)
        {
            Debug.LogError("Default tile data (Soil) ã�� �� �����ϴ�.");
        }

        roomTileData = tileDataManager.GetTileDataByType(TileType.Room);
        if (roomTileData == null)
        {
            Debug.LogError("Room tile data ã�� �� �����ϴ�.");
        }

        resourceTileData = tileDataManager.GetTileDataByType(TileType.Resource);
        if (resourceTileData == null)
        {
            Debug.LogError("Resource tile data ã�� �� �����ϴ�.");
        }
    }

    public void GenerateMap(Vector3Int position)
    {
        Tilemap.SetTile(position, defaultTileData.tile);
        Tilemap.RefreshAllTiles();
        Debug.LogError("�� ����");
    }

    public void GenerateRoom(Vector3Int position)
    {
        Tilemap.SetTile(position, roomTileData.tile);
        Tilemap.RefreshAllTiles();
        Debug.LogError("�� ����");
    }

    public void GenerateResource(Vector3Int position)
    {
        Tilemap.SetTile(position, resourceTileData.tile);
        Tilemap.RefreshAllTiles();
        Debug.LogError("�ڿ� ����");
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
