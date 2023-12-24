using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed, AttackRange, seeAhead;
    public GameObject player;
    private Rigidbody2D rb2d;
    public bool active, boss;
    [SerializeField] private Animator enemyAnimator;

    void Start()
    {
      player = GameObject.Find("Player");
      rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      if(!boss)
      {
        enemyAnimator.SetBool("Active", active);
          if (active)
          {
            MoveTowardsPlayer();
          } else {
            if(IsPlayerInRange())
            {
              active = true;
            }
          }
      }
    }

    public bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= AttackRange;
    }

    private void MoveTowardsPlayer()
    {
        rb2d.velocity = GetComponent<EnemySteering>().finalDirection * movementSpeed;
    }



}
