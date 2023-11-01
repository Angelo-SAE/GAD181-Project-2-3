using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed;
    [SerializeField] private GameObject bulletDirection;

    public void ShootBullet()
    {
      Vector3 direction = transform.position - bulletDirection.transform.position;
      gameObject.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      if(col.gameObject.layer != 6)
      {
        Destroy(gameObject);
      }
    }

}
