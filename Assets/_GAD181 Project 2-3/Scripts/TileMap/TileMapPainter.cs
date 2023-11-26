using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapPainter : MonoBehaviour
{
  [SerializeField] private Tilemap floorMap, wallMap, holeMap, chestMap, spikeMap;
  [SerializeField] private TileBase holeClosedTile, holeOpenedTile, chestClosedTile, chestOpenedTile, spikeTile;
  [SerializeField] private List<TileBase> floorTiles, topWalls, leftWalls, rightWalls, bottomWalls = new List<TileBase>();
  [SerializeField] private TileBase fullWall, topLeftWall, topRightWall, bottomLeftWall, bottomRightWall;


  public void PaintFloorTiles(HashSet<Vector2Int> tilePositions)
  {
    floorMap.ClearAllTiles();
    foreach(Vector2Int position in tilePositions)
    {
      TilePainter(floorMap, position, floorTiles[Random.Range(0, floorTiles.Count)]);
    }
  }

  public void PaintWallTiles(HashSet<Vector3Int> tilePositions)
  {
    wallMap.ClearAllTiles();
    foreach(Vector3Int position in tilePositions)
    {
      Vector2Int tPosition = new Vector2Int(position.x, position.y);
      if(position.z == 0)
      {
        TilePainter(wallMap, tPosition, topWalls[Random.Range(0, topWalls.Count)]);
      }
      if(position.z == 1)
      {
        TilePainter(wallMap, tPosition, rightWalls[Random.Range(0, rightWalls.Count)]);
      }
      if(position.z == 2)
      {
        TilePainter(wallMap, tPosition, bottomWalls[Random.Range(0, bottomWalls.Count)]);
      }
      if(position.z == 3)
      {
        TilePainter(wallMap, tPosition, leftWalls[Random.Range(0, leftWalls.Count)]);
      }
      if(position.z == 4)
      {
        TilePainter(wallMap, tPosition, fullWall);
      }
      if(position.z == 5)
      {
        TilePainter(wallMap, tPosition, topLeftWall);
      }
      if(position.z == 6)
      {
        TilePainter(wallMap, tPosition, topRightWall);
      }
      if(position.z == 7)
      {
        TilePainter(wallMap, tPosition, bottomLeftWall);
      }
      if(position.z == 8)
      {
        TilePainter(wallMap, tPosition, bottomRightWall);
      }
    }
  }

  public void PaintHoleTile(Vector2Int tilePosition)
  {
    holeMap.ClearAllTiles();
    TilePainter(holeMap, tilePosition, holeClosedTile);
  }

  public void PaintHoleOpenTile(Vector2Int tilePosition)
  {
    holeMap.ClearAllTiles();
    TilePainter(holeMap, tilePosition, holeOpenedTile);
  }

  public void PaintChestTile(Vector2Int tilePosition)
  {
    chestMap.ClearAllTiles();
    TilePainter(chestMap, tilePosition, chestClosedTile);
  }

  public void PaintChestOpenTile(Vector2Int tilePosition)
  {
    chestMap.ClearAllTiles();
    TilePainter(chestMap, tilePosition, chestOpenedTile);
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
