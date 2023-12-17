using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float movementSpeed;
    public int health, maxHealth;
    [SerializeField] private Slider healthSlider, maxHealthSlider;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private GameObject deathMenu, pauseMenu, mainCamera;
    private Animator pAnimator;
    private bool isPaused;
    private float t;

    void Awake()
    {
      GamePause.UnPause();
    }

    void Start()
    {
      rb2d = gameObject.GetComponent<Rigidbody2D>();
      pAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
      if(!GamePause.paused)
      {
        Movement();
        Health();

        if(Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
        {
          pAnimator.SetBool("Moving", false);
          t += Time.deltaTime;
          if(t > 10f)
          {
            pAnimator.SetTrigger("Sit");
          }
        } else {
          t = 0f;
          pAnimator.SetBool("Moving", true);
        }

      }
      Dead();
      PauseGame();
    }

    private void Movement()
    {
      rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed;
    }

    private void Health()
    {
      maxHealthSlider.value = maxHealth;
      health = Mathf.Clamp(health, 0, maxHealth);
      healthSlider.value = health;
    }

    public void TakeDamage(int damage, Vector3 direction, float pushForce)
    {
      rb2d.AddForce(direction * pushForce);
      StartCoroutine(mainCamera.GetComponent<CameraShake>().ShakeScreen());
      health -= damage;
      playerSprite.color = new Color(0.67f, 0.1f, 0.1f);
      Invoke("ChangeColorBack", 0.2f);
    }

    private void ChangeColorBack()
    {
      playerSprite.color = new Color(1f, 1f, 1f);
    }

    public void PlayerHealed()
    {
      playerSprite.color = new Color(0.7f, 1f, 0.5f);
      Invoke("ChangeColorBack", 0.2f);
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
