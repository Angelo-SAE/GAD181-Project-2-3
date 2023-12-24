using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject Spawn1, Spawn2;
    public float spawnCooldown = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnCooldown);
    }



    private void SpawnEnemies()
    {
      EnemyCount.enemyCount++;
      int r = Random.Range(0, 100 + 1);
      if(r < 70)
      {
        GameObject enemy = Instantiate(Spawn1, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyHealth>().dropHearts = false;
      } else {
        GameObject enemy = Instantiate(Spawn2, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyHealth>().dropHearts = false;
      }
    }
}
