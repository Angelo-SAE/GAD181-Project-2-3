using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FloorGeneration : MonoBehaviour
{
  [SerializeField] private int stepAmount, itterationAmount;
  private HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

    public HashSet<Vector2Int> GenerateFloor()
    {
      floorPositions.Clear();
      floorPositions.Add(new Vector2Int(0,0));
      for(int a = itterationAmount; a > 0; a--)
      {
        Vector2Int position = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        for(int b = stepAmount; b > 0; b--)
        {
          Vector2Int newPosition = position + StaticTilemaps.GetRandomCardinalDirection();
          for(int c = 0; c < 1;)
          {
            if(!floorPositions.Contains(newPosition))
            {
              c++;
              floorPositions.Add(newPosition);
              position = newPosition;
            } else {
              newPosition += StaticTilemaps.GetRandomCardinalDirection();
            }
          }
        }
      }
      return floorPositions;
    }

}
