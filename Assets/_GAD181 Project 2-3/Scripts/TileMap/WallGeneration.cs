using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneration : MonoBehaviour
{
    public HashSet<Vector2Int> GenerateWall(HashSet<Vector2Int> floorPositions)
    {
      HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
      foreach(Vector2Int position in floorPositions)
      {
        foreach(Vector2Int direction in StaticTilemaps.allDirections)
        {
          if(!floorPositions.Contains(position + direction))
          {
            wallPositions.Add(position + direction);
          }
        }
      }
      return wallPositions;
    }
}
