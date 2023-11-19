using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  [SerializeField] private float damage;
  private GameObject player;

  void Start()
  {
    player = GameObject.Find("Player");
  }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 6)
        {
          player.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
