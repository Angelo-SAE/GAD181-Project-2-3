using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDamage;

    private void OnCollisionEnter2D(Collision2D col)
    {
      if(col.gameObject.tag == "Wall")
      {
        Destroy(gameObject);
      }
    }

}
