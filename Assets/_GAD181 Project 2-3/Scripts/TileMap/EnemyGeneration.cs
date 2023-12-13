using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private GameObject enemySmall, enemyBig;
    [SerializeField] private int enemyMin, enemyMax;
    private int enemyAmount;

    public void GenerateEnemy(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> objectPositions)
    {
      enemyAmount = Random.Range(enemyMin + (GetComponent<ExitLadder>().roomsCleared*2), enemyMax + (GetComponent<ExitLadder>().roomsCleared*3) + 1);
      for(int a = enemyAmount; a > 0;)
      {
        Vector2Int enemyPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));
        if(!objectPositions.Contains(enemyPosition))
        {
          int ok = 0;
          foreach(Vector2Int position in StaticTilemaps.enemyCantSpawn)
          {
            if(enemyPosition == position)
            {
              ok++;
            }
          }
          if(ok == 0)
          {
            a--;
            objectPositions.Add(enemyPosition);
            EnemyCount.enemyCount++;
            Instantiate(enemySmall, new Vector3(enemyPosition.x + 0.5f, enemyPosition.y + 0.5f, -1f), transform.rotation);
          }
        }
      }
    }
}
