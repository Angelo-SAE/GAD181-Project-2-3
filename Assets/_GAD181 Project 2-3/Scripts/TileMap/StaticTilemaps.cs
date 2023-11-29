using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTilemaps : MonoBehaviour
{
    public static List<Vector2Int> cardinalDirections = new List<Vector2Int>
    {
      new Vector2Int(0,1),
      new Vector2Int(1,0),
      new Vector2Int(0,-1),
      new Vector2Int(-1,0)
    };

    public static List<Vector2Int> diagionalDirections = new List<Vector2Int>
    {
      new Vector2Int(1,1),
      new Vector2Int(1,-1),
      new Vector2Int(-1,-1),
      new Vector2Int(-1,1)
    };

    public static List<Vector2Int> allDirections = new List<Vector2Int>
    {
      new Vector2Int(1,0),
      new Vector2Int(0,1),
      new Vector2Int(0,-1),
      new Vector2Int(-1,0),
      new Vector2Int(1,1),
      new Vector2Int(-1,1),
      new Vector2Int(1,-1),
      new Vector2Int(-1,-1)
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
      return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}
