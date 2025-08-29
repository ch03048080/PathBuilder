using System.Collections.Generic;
using UnityEngine;

public class TunnelModel
{
    public int PathwayCost { get; private set; }
    public HashSet<Vector3Int> PreviewTiles { get; } = new HashSet<Vector3Int>();

    public TunnelModel(int initialCost)
    {
        PathwayCost = initialCost;
    }

    public bool CanDig(Vector3Int position)
    {
        return PathwayCost > 0 && !PreviewTiles.Contains(position);
    }

    public void DigTile(Vector3Int position)
    {
        //if (CanDig(position))
        //{
            PathwayCost--;
            PreviewTiles.Add(position);
        //}
    }

    public void ResetPreview()
    {
        PreviewTiles.Clear();
    }
}