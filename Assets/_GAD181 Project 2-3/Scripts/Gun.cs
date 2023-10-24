using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
  [SerializeField] private Transform gunPosition, gunTip;
  [SerializeField] private GameObject bullet, bulletStorage, reloadingBackground;
  [SerializeField] private float attackSpeed, reloadSpeed, bulletDamage;
  [SerializeField] private Slider delayTimer, ammoSlider;
  private int ammoCount = 6;
  private bool readyToShoot = true, reloading;

  void Update()
  {
    GunLooking();
    GunShooting();
  }

  private void GunLooking()
  {
    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);

    float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

    if(angle + 180 >= 90 && angle + 180 <= 270)
    {
      transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
      gunPosition.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    } else {
      transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
      gunPosition.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180));
    }
  }

  private float AngleBetweenPoints(Vector2 a, Vector2 b)
  {
    return Mathf.Atan2(a.y -b.y, a.x - b.x) * Mathf.Rad2Deg;
  }

  private void GunShooting()
  {
    if(Input.GetButtonDown("Fire1") && readyToShoot && ammoCount > 0 && !reloading)
    {
      ammoCount--;
      ammoSlider.value -= 1;
      StartCoroutine(ShootingDelay());
      readyToShoot = false;
      GameObject shotBullet = Instantiate(bullet, new Vector3(gunTip.position.x, gunTip.position.y, gunTip.position.z + 0.01f), gunPosition.transform.rotation, bulletStorage.transform);
      shotBullet.GetComponent<Rigidbody2D>().AddForce((gunTip.position - gunPosition.position)* 10, ForceMode2D.Impulse);
      shotBullet.GetComponent<Bullet>().bulletDamage = bulletDamage;
    }

    if(Input.GetButtonDown("Reload") && ammoCount == 0 && !reloading)
    {
      reloadingBackground.SetActive(true);
      reloading = true;
      StartCoroutine(Reload());
    }
  }

  private IEnumerator ShootingDelay()
  {
    delayTimer.value = 0;
    for(int a = 0; a < 100; a++)
    {
      yield return new WaitForSeconds(attackSpeed/100);
      delayTimer.value += 1;
    }
    readyToShoot = true;
  }

  private IEnumerator Reload()
  {
    for(int a = 0; a < 6; a++)
    {
      yield return new WaitForSeconds(reloadSpeed/6);
      ammoSlider.value += 1;
      ammoCount++;
    }
    reloading = false;
    reloadingBackground.SetActive(false);
  }
}
