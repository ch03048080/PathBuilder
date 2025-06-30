using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileDataManager", menuName = "Scriptable Objects/TileDataManager")]
public class TileDataManager : ScriptableObject
{
    public List<TileData> tileDataList; //타일 데이터 저장 리스트

    // TileType으로 타일 데이터를 검색
    public TileData GetTileDataByType(TileType tileType)
    {
        return tileDataList.Find(data => data.tileType == tileType);
    }
}
