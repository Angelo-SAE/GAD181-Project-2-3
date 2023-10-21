using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float movementSpeed;

    void Start()
    {
      rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      Movement();
    }

    private void Movement()
    {
      rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
    }
}
