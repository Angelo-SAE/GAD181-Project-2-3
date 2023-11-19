using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestGeneration : MonoBehaviour
{
    public Vector2Int GenerateChest(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions, HashSet<Vector2Int> objectPositions)
    {
      Vector2Int chestPosition = new Vector2Int();
      for(int a = 0; a < 1;)
      {
        chestPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));
        int b = 0;
        int c = 0;
        if(!objectPositions.Contains(chestPosition))
        {
          foreach(Vector2Int direction in StaticTilemaps.cardinalDirections)
          {
            if(wallPositions.Contains(chestPosition + direction) && objectPositions.Contains(chestPosition + direction))
            {
              b++;
            }
          }
          foreach(Vector2Int direction in StaticTilemaps.diagionalDirections)
          {
            if(wallPositions.Contains(chestPosition + direction) && objectPositions.Contains(chestPosition + direction))
            {
              c++;
            }
          }
          if(b == 0 && c < 2)
          {
            a++;
          } else if(b < 2 && c == 0)
          {
            a++;
          }
        }
      }
      return chestPosition;
    }
}
