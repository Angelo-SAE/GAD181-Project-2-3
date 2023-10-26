using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed;
    [SerializeField] private GameObject bulletDirection;

    void Awake()
    {
      Vector3 direction = transform.position - bulletDirection.transform.position;
      gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 10, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        Destroy(gameObject);
    }

}
