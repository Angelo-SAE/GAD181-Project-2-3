using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpikeGeneration : MonoBehaviour
{
  [SerializeField] private int spikeAmount;

    public HashSet<Vector2Int> GenerateSpike(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions, HashSet<Vector2Int> objectPositions)
    {
      HashSet<Vector2Int> spikePositions = new HashSet<Vector2Int>();
      for(int k = spikeAmount; k > 0; k--)
      {
        for(int a = 0; a < 1;)
        {
          Vector2Int spikePosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));
          int b = 0;
          int c = 0;
          if(!objectPositions.Contains(spikePosition) && spikePosition != new Vector2Int(1, 1))
          {
            foreach(Vector2Int direction in StaticTilemaps.cardinalDirections)
            {
              if(wallPositions.Contains(spikePosition + direction) && objectPositions.Contains(spikePosition + direction))
              {
                b++;
              }
            }
            foreach(Vector2Int direction in StaticTilemaps.diagionalDirections)
            {
              if(wallPositions.Contains(spikePosition + direction) && objectPositions.Contains(spikePosition + direction))
              {
                c++;
              }
            }
            if(b == 0 && c < 2)
            {
              spikePositions.Add(spikePosition);
              a++;
            } else if(b < 2 && c == 0)
            {
              spikePositions.Add(spikePosition);
              a++;
            }
          }
        }
      }
      return spikePositions;
    }
}
