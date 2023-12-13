using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
  [SerializeField] private GameObject arrow;
  [SerializeField] private float arrowSpeed;
  [SerializeField] private int arrowDamage;


    void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
      while(true)
      {
        GameObject shotArrow = Instantiate(arrow, transform);
        shotArrow.GetComponent<BalistaArrow>().arrowSpeed = arrowSpeed;
        shotArrow.GetComponent<BalistaArrow>().arrowDamage = arrowDamage;
        shotArrow.GetComponent<BalistaArrow>().ShootArrow();
        yield return new WaitForSeconds(2f);
      }
    }

}
