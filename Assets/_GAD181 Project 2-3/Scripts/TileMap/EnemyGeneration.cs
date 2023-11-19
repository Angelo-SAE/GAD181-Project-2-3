using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private GameObject enemySmall, enemyBig;
    [SerializeField] private int enemyAmount;

    public void GenerateEnemy(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> objectPositions)
    {
      EnemyCount.enemyCount = enemyAmount;
      for(int a = enemyAmount; a > 0; a--)
      {
        Vector2Int enemyPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));
        if(!objectPositions.Contains(enemyPosition))
        {
          objectPositions.Add(enemyPosition);
          Instantiate(enemySmall, new Vector3(enemyPosition.x + 0.5f, enemyPosition.y + 0.5f, -1f), transform.rotation);
        }
      }
    }
}
