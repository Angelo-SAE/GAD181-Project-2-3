using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistaArrow : MonoBehaviour
{

  [SerializeField] private GameObject arrowDirection;
  public float arrowDamage, arrowSpeed;

  public void ShootArrow()
  {
    Vector3 direction =  arrowDirection.transform.position - transform.position;
    gameObject.GetComponent<Rigidbody2D>().AddForce(direction * arrowSpeed, ForceMode2D.Impulse);
  }

    private void OnCollisionEnter2D(Collision2D col)
    {
      if(col.gameObject.layer == 6)
      {
        GameObject.Find("Player").GetComponent<Player>().TakeDamage(arrowDamage);
      }
      Destroy(gameObject);
    }
}
