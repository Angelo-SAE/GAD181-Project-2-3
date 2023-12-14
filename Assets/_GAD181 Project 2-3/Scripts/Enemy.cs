using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed, AttackRange, seeAhead;
    private GameObject player;
    private Rigidbody2D rb2d;
    public bool active;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private GameObject topRight, topLeft, bottomRight, bottomLeft;

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

        bool collisionAhead = Physics2D.Raycast(transform.position, direction, seeAhead, 1 << 9);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, seeAhead + 1f, 1 << 7);

        //if(collisionAhead)
        //{
        //  rb2d.velocity = FindPath(direction) * movementSpeed;
        //} else {
        //  rb2d.velocity = direction * movementSpeed;
        //}

        rb2d.velocity = direction * movementSpeed;

        if(rb2d.velocity.x > 0)
        {
          transform.localScale = new Vector3(-1f, 1f, 1f);
        } else {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private Vector3 FindPath(Vector3 currDirection)
    {
      Vector3 direction = Vector3.zero;
      bool turn = true;
      for(float a = 5; a < 1000;)
      {
        direction = Quaternion.AngleAxis(a, Vector3.forward) * currDirection;
        turn = Physics2D.Raycast(transform.position, direction, 1.5f, 1 << 9);

        if(!turn)
        {
          return Quaternion.AngleAxis(a + 50, Vector3.forward) * direction;
        } else {
          direction = Quaternion.AngleAxis(-a, Vector3.forward) * currDirection;
          turn = Physics2D.Raycast(transform.position, direction, 1.5f, 1 << 9);
          if(!turn)
          {
            return Quaternion.AngleAxis(a - 50, Vector3.forward) * direction;
          }
        }
        a += 5;
      }
      return direction;
    }



}
