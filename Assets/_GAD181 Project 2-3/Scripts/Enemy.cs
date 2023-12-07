using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public float AttackRange;
    private GameObject player;
    private Rigidbody2D rb2d;
    public bool active;
    [SerializeField] private Animator enemyAnimator;

    void Start()
    {
      player = GameObject.Find("Player");
      rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
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

    public bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= AttackRange;
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb2d.velocity = direction * movementSpeed;
        if(rb2d.velocity.x > 0)
        {
          transform.localScale = new Vector3(-1f, 1f, 1f);
        } else {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
