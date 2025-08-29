using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TunnelView : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase emptyTile;
    public Color previewColor = new Color(1f, 1f, 1f, 0.5f);

    public void SetTilePreview(Vector3Int position)
    {
        tilemap.SetTileFlags(position, TileFlags.None);
        tilemap.SetColor(position, previewColor);
    }

    public void ClearTilePreview(Vector3Int position)
    {
        tilemap.SetTileFlags(position, TileFlags.None);
        tilemap.SetColor(position, Color.white);
    }

    public void DigTile(Vector3Int position)
    {
        tilemap.SetTile(position, emptyTile);
    }
}