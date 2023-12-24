using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 currentDirection;
    private float timer = 0f;
    public float switchPath = 2f;
    public LayerMask walls;

    void Start()
    {

        SetRandomDirection();
    }

    void Update()
    {
      if(!GetComponent<Enemy>().active)
      {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, 0.5f, walls);
        timer += Time.deltaTime;

        if (timer >= switchPath || hit)
        {

            SetRandomDirection();
            timer = 0f;
        }

        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
      }
    }

    void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        currentDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
    }
}
