using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySteering : MonoBehaviour
{
    [SerializeField] private float detectionRadius, enemyColliderSize;
    [SerializeField] private LayerMask wallMask, playerMask, playerWallMask, enemyMask;
    private bool playerVisiable;
    private Collider2D[] wallColliders, enemyColliders;
    private float[] badDirections, goodDirections;
    private Vector3 playerDirection, lastPlayerPosition;
    public Vector3 finalDirection;
    private GameObject player;
    private Collider2D selfCollider;

    void Start()
    {
      player = GetComponent<Enemy>().player;
      selfCollider = GetComponentInChildren<BoxCollider2D>();
    }

    void Update()
    {
      playerDirection = (player.transform.position - transform.position).normalized;
      PlayerInSight();
      if(playerVisiable)
      {
        DetectWalls();
        GoodDirections();
        BadDirections();
        CalculateFinalDirection();
      } else {
        playerDirection = (lastPlayerPosition - transform.position).normalized;
        DetectWalls();
        GoodDirections();
        BadDirections();
        CalculateFinalDirection();
      }
    }

    private void DetectWalls()
    {
      wallColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, wallMask);
    }

    private void PlayerInSight()
    {
      RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, 100f, playerWallMask);
      if(hit.collider != null)
      {
        if(hit.collider.gameObject.tag == "Player")
        {
          playerVisiable = true;
          lastPlayerPosition = player.transform.position;
        } else {
          playerVisiable = false;
          enemyColliders = Physics2D.OverlapCircleAll(lastPlayerPosition, 0.5f, enemyMask);
          foreach(Collider2D enemyCollider in enemyColliders)
          {
            if(enemyCollider == selfCollider)
            {
              GetComponent<Enemy>().active = false;
            }
          }
        }
      } else {
        playerVisiable = false;
        enemyColliders = Physics2D.OverlapCircleAll(lastPlayerPosition, 0.5f, enemyMask);
        foreach(Collider2D enemyCollider in enemyColliders)
        {
          if(enemyCollider == gameObject)
          {
            GetComponent<Enemy>().active = false;
          }
        }
      }
    }

    private void GoodDirections()
    {
      goodDirections = new float[8];
      int a = 0;
      foreach(Vector2 direction in DirectionsList.allDirectionsEnemy)
      {
        float goodValue = Vector2.Dot(playerDirection, direction);

        if(goodValue > 0)
        {
          if(goodValue > goodDirections[a])
          {
            goodDirections[a] = goodValue;
          }
        }
        a++;
      }
    }

    private void BadDirections()
    {
      badDirections = new float[8];
      foreach(Collider2D wall in wallColliders)
      {
        Vector2 wallDirection = wall.ClosestPoint(transform.position) - (Vector2)transform.position;
        float distanceToWall = wallDirection.magnitude;
        wallDirection = wallDirection.normalized;
        float weight = 0f;
        if(distanceToWall <= enemyColliderSize)
        {
          weight = 1f;
        } else {
          weight = (detectionRadius - distanceToWall) / detectionRadius;
        }
        int a = 0;
        foreach(Vector2 direction in DirectionsList.allDirectionsEnemy)
        {
          float result = Vector2.Dot(wallDirection, direction);

          float dangerValue = result * weight;

          if(dangerValue > badDirections[a])
          {
            badDirections[a] = dangerValue;
          }
          a++;
        }
      }
    }

    private void CalculateFinalDirection()
    {
      for(int a = 0; a < 8; a++)
      {
        goodDirections[a] = Mathf.Clamp(goodDirections[a] - badDirections[a], 0, 1);
      }

      Vector2 tempDirection = Vector2.zero;
      for(int a = 0; a < 8; a++)
      {
        tempDirection += DirectionsList.allDirectionsEnemy[a] * goodDirections[a];
      }
      finalDirection = tempDirection.normalized;
    }
}


public static class DirectionsList
{
  public static List<Vector2> allDirectionsEnemy = new List<Vector2>
  {
    new Vector2(1f,0f),
    new Vector2(0f,1f),
    new Vector2(0f,-1f),
    new Vector2(-1f,0f),
    new Vector2(1f,1f),
    new Vector2(-1f,1f),
    new Vector2(1f,-1f),
    new Vector2(-1f,-1f)
  };
}
