using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType
{
    Soil,
    Resource,
    Room,
    Pathway
}

[CreateAssetMenu(fileName = "TileData", menuName = "Scriptable Objects/TileData")]
public class TileData : ScriptableObject
{
    //public Tilemap tilemap; // 타일맵 컴포넌트
    public TileType tileType; // 타일 타입
    public TileBase tile; // 타일 객체
    public bool isWalkable; // 이동 가능 여부
    public bool isResource; // 자원 여부
    public bool isRoom; // 방 여부
}
