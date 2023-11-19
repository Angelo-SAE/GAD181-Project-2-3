using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float AttackRange = 5.0f;
    private GameObject player;

    void Start()
    {
      player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            MoveTowardsPlayer();
        }
    }

    public bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= AttackRange;
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

}
