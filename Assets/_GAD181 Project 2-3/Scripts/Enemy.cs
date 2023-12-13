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
        rb2d.velocity = direction * movementSpeed;

        bool collisionAhead1 = Physics2D.Raycast(transform.position, (player.transform.position - topRight.transform.position).normalized, 2f, 1 << 9);
        bool collisionAhead2 = Physics2D.Raycast(transform.position, (player.transform.position - topLeft.transform.position).normalized, 2f, 1 << 9);
        bool collisionAhead3 = Physics2D.Raycast(transform.position, (player.transform.position - bottomRight.transform.position).normalized, 2f, 1 << 9);
        bool collisionAhead4 = Physics2D.Raycast(transform.position, (player.transform.position - bottomLeft.transform.position).normalized, 2f, 1 << 9);
        if(collisionAhead1 || collisionAhead2 || collisionAhead3 || collisionAhead4)
        {
          rb2d.velocity = FindPath(direction) * movementSpeed;
        }

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
          return Quaternion.AngleAxis(50, Vector3.forward) * direction;
        } else {
          direction = Quaternion.AngleAxis(-a, Vector3.forward) * currDirection;
          turn = Physics2D.Raycast(transform.position, direction, 1.5f, 1 << 9);
          if(!turn)
          {
            return Quaternion.AngleAxis(-50, Vector3.forward) * direction;
          }
        }
        a += 5;
      }
      return direction;
    }

}
