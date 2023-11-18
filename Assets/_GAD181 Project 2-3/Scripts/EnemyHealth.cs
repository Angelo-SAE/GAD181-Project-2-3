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
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Death.Play();
            Destroy(gameObject);
        }
        

    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
