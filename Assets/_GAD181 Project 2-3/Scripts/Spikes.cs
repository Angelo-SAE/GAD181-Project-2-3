using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

  [SerializeField] private int damage;
  private GameObject player;

  void Start()
  {
    player = GameObject.Find("Player");
  }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.layer == 6)
      {
        player.GetComponent<Player>().TakeDamage(damage, new Vector3(0f, 0f, 0f), 0f);
      }
    }

}
