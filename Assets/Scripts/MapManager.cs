using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public Tilemap tilemap; // 타일맵 컴포넌트
    public TileDataManager tileDataManager; // 타일 데이터 매니저

    public int mapWidth = 32;  // 맵의 가로 크기
    public int mapHeight = 18; // 맵의 세로 크기

    void Start()
    {
        GenerateMap();
        GenerateRoom();
        GenerateResources();
    }


    //맵 생성
    void GenerateMap()
    {
        // 기본 타일 데이터 가져오기
        TileData defaultTileData = tileDataManager.GetTileDataByType(TileType.Soil);
        if (defaultTileData == null)
        {
            Debug.LogError("Default tile data (Soil) is missing in TileDataManager!");
            return;
        }

        // 맵의 시작 위치를 조정 (중앙 정렬)
        int startX = -mapWidth / 2;
        int startY = -mapHeight / 2;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int position = new Vector3Int(startX + x, startY + y, 0);
                tilemap.SetTile(position, defaultTileData.tile);
            }
        }
    }
    // 방 생성
    void GenerateRoom()
    {
        // 방 크기 설정
        int roomWidth = 4;
        int roomHeight = 3;

        // 방의 랜덤 위치 계산 (맵의 중심에서 크게 벗어나지 않도록 제한)
        int roomX = Random.Range(-mapWidth / 4, mapWidth / 4 - roomWidth);
        int roomY = Random.Range(-mapHeight / 4, mapHeight / 4 - roomHeight);

        // 방 타일 데이터 가져오기
        TileData roomTileData = tileDataManager.GetTileDataByType(TileType.Room);
        if (roomTileData == null)
        {
            Debug.LogError("Room tile data is missing in TileDataManager!");
            return;
        }

        // 방 생성
        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomHeight; y++)
            {
                Vector3Int position = new Vector3Int(roomX + x, roomY + y, 0);
                tilemap.SetTile(position, roomTileData.tile);
                Debug.Log($"Room tile set at position {position}");
            }
        }
        // 타일맵 갱신
        //tilemap.RefreshAllTiles(); 
    }

    void GenerateResources()
    {
        // 자원 타일 데이터 가져오기
        TileData resourceTileData = tileDataManager.GetTileDataByType(TileType.Resource);
        if (resourceTileData == null)
        {
            Debug.LogError("Resource tile data is missing in TileDataManager!");
            return;
        }

        // 자원 타일을 랜덤한 위치에 배치
        int resourceX = Random.Range(-mapWidth / 2 + 5, mapWidth / 2 - 5);
        int resourceY = Random.Range(-mapHeight / 2 + 5, mapHeight / 2 - 5);

        Vector3Int position = new Vector3Int(resourceX, resourceY, 0);
        tilemap.SetTile(position, resourceTileData.tile);
        Debug.Log($"Resources tile set at position {position}");
        // 타일맵 갱신
        //tilemap.RefreshAllTiles(); 
    }
}