using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileDataManager", menuName = "Scriptable Objects/TileDataManager")]
public class TileDataManager : ScriptableObject
{
    public List<TileData> tileDataList = new List<TileData>(); 

    public TileData GetTileDataByType(TileType tileType)
    {
        return tileDataList.Find(data => data.tileType == tileType);
    }

    public void MarkEdgesAsWall(Tilemap tilemap)
    {
        TileData wallTileData = GetTileDataByType(TileType.Wall);
        if (wallTileData == null || wallTileData.tile == null)
        {
            Debug.LogError("Wall 타일 데이터가 설정되지 않았습니다.");
            return;
        }

        TileBase wallTile = wallTileData.tile;

        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.xMin; x <= bounds.xMax; x++)
        {
            tilemap.SetTile(new Vector3Int(x, bounds.yMin, 0), wallTile);
            tilemap.SetTile(new Vector3Int(x, bounds.yMax, 0), wallTile);
        }

        for (int y = bounds.yMin; y <= bounds.yMax; y++)
        {
            tilemap.SetTile(new Vector3Int(bounds.xMin, y, 0), wallTile);
            tilemap.SetTile(new Vector3Int(bounds.xMax, y, 0), wallTile);
        }

        Debug.Log("테두리 타일이 Wall로 설정되었습니다.");
    }

}
