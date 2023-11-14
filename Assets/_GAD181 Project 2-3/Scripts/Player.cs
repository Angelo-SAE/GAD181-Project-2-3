using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float movementSpeed, health;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private GameObject deathMenu, pauseMenu;
    private bool isPaused;

    void Start()
    {
      rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      if(!GamePause.paused)
      {
        Movement();
        Health();
      }
      Dead();
      PauseGame();
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

    public void TakeDamage(float damage)
    {
      health -= damage;
      playerSprite.color = new Color(0.67f, 0.1f, 0.1f);
      Invoke("ChangeColorBack", 0.1f);
    }

    private void ChangeColorBack()
    {
      playerSprite.color = new Color(0.26f, 0.26f, 0.26f);
    }

    private void Dead()
    {
      if(health <= 0)
      {
        GamePause.Pause();
        deathMenu.SetActive(true);
      }
    }

    public void PauseGame()
    {
      if(Input.GetButtonDown("Pause") && !isPaused && !GamePause.paused)
      {
        GamePause.Pause();
        pauseMenu.SetActive(true);
        isPaused = true;
      } else if(Input.GetButtonDown("Pause") && GamePause.paused && isPaused)
      {
        UnPause();
      }
    }

    public void UnPause()
    {
      pauseMenu.SetActive(false);
      isPaused = false;
      GamePause.UnPause();
    }
}
