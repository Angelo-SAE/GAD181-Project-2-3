using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    private GameObject player;
    public int healthGain = 1;

    private void Start()
    {
        player = GameObject.Find("Player");

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RegenHealth();
            Destroy(gameObject);

        }
    }

    private void RegenHealth()
    {
        player.GetComponent<Player>().PlayerHealed();
        player.GetComponent<Player>().health += healthGain;
    }
}
