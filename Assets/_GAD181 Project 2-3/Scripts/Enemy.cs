using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float AttackRange = 5.0f;
    public Transform player;
    public int damage;

    private void Update()
    {
        if (IsPlayerInRange())
        {
            MoveTowardsPlayer();
        }
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= AttackRange;
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void TakeDamage(float damage)
    {

    }

}
