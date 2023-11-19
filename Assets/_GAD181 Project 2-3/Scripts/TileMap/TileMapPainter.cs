using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapPainter : MonoBehaviour
{
  [SerializeField] private Tilemap floorMap, wallMap, holeMap, chestMap, spikeMap;
  [SerializeField] private TileBase floorTile, wallTile, holeTile, chestTile, spikeTile;


  public void PaintFloorTiles(HashSet<Vector2Int> tilePositions)
  {
    floorMap.ClearAllTiles();
    foreach(Vector2Int position in tilePositions)
    {
      TilePainter(floorMap, position, floorTile);
    }
  }

  public void PaintWallTiles(HashSet<Vector2Int> tilePositions)
  {
    wallMap.ClearAllTiles();
    foreach(Vector2Int position in tilePositions)
    {
      TilePainter(wallMap, position, wallTile);
    }
  }

  public void PaintHoleTile(Vector2Int tilePosition)
  {
    holeMap.ClearAllTiles();
    TilePainter(holeMap, tilePosition, holeTile);
  }

  public void PaintChestTile(Vector2Int tilePosition)
  {
    chestMap.ClearAllTiles();
    TilePainter(chestMap, tilePosition, chestTile);
  }

  public void PaintSpikeTiles(HashSet<Vector2Int> tilePositions)
  {
    spikeMap.ClearAllTiles();
    foreach(Vector2Int position in tilePositions)
    {
      TilePainter(spikeMap, position, spikeTile);
    }
  }

  private void TilePainter(Tilemap map, Vector2Int location, TileBase tile)
  {
    map.SetTile((Vector3Int)location, tile);
  }


}
