using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

  [SerializeField] private float damage;
  [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.layer == 6)
      {
        player.GetComponent<Player>().TakeDamage(damage);
      }
    }

}
