using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    private float currentHealth;
    public AudioSource Death;
    private bool alive;
    [SerializeField] private SpriteRenderer enemySprite;



    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        alive = true;
    }

    public void TakeDamage(float damage)
    {
      enemySprite.color = new Color(0.67f, 0.1f, 0.1f);
      Invoke("ChangeColorBack", 0.1f);
      if(GetComponent<Enemy>().active)
      {

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0 && alive)
        {
          alive = false;
          EnemyCount.enemyCount--;
          Instantiate(Death);
          Destroy(gameObject);
        }

      } else {
        GetComponent<Enemy>().active = true;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0 && alive)
        {
          alive = false;
          EnemyCount.enemyCount--;
          Instantiate(Death);
          Destroy(gameObject);
        }
      }
    }

    private void ChangeColorBack()
    {
      enemySprite.color = new Color(1f, 1f, 1f);
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
