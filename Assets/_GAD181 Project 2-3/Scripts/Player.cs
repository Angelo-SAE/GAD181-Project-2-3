using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int health;

    void Start()
    {
      rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      Movement();
      Health();
    }

    private void Movement()
    {
      rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
    }

    private void Health()
    {
      health = Mathf.Clamp(health, 0, 100);
      healthSlider.value = health;
    }
}
