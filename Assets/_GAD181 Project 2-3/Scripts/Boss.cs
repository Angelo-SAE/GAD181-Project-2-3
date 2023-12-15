using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject Spawn;
    public float spawnCooldown = 3f;

    private void Start()
    {
        InvokeRepeating("Move", 0f, spawnCooldown);
    }

    

    private void Move()
    {
        
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        
        Instantiate(Spawn, transform.position, Quaternion.identity);
    }
}
