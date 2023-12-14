using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HoleGeneration : MonoBehaviour
{
  public Vector2Int GenerateHole(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions)
  {
    Vector2Int holePosition = new Vector2Int();
    for(int a = 0; a < 1;)
    {
      holePosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));
      if(holePosition != new Vector2Int(1, 1))
      {
        int b = 0;
        int c = 0;
        foreach(Vector2Int direction in StaticTilemaps.cardinalDirections)
        {
          if(wallPositions.Contains(holePosition + direction))
          {
            b++;
          }
        }
        foreach(Vector2Int direction in StaticTilemaps.diagionalDirections)
        {
          if(wallPositions.Contains(holePosition + direction))
          {
            c++;
          }
        }

        if(b < 2 && c == 0)
        {
          a++;
        }
        
        //if(b == 0 && c < 2)
        //{
        //  a++;
        //} else if(b < 2 && c == 0)
        //{
        //  a++;
        //}
      }
    }
    return holePosition;
  }
}
