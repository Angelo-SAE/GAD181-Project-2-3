using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    private float currentHealth;
    public AudioSource Death;



    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
      if(GetComponent<Enemy>().IsPlayerInRange())
      {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
          EnemyCount.enemyCount--;
          Instantiate(Death);
          Destroy(gameObject);
        }
      }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
