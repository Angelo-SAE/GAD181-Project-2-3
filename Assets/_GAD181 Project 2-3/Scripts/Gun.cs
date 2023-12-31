using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
  [SerializeField] private Transform gunPosition, gunTip;
  [SerializeField] private GameObject bullet, bulletStorage, reloadingBackground, ammoWarning, bulletSound;
  public float attackSpeed, reloadSpeed, bulletDamage, bulletSpeed;
  [SerializeField] private Slider delayTimer, ammoSlider, maxAmmoSlider;
  public int ammoCount, maxAmmo, bulletAmount;
  private bool readyToShoot = true, reloading;
  private float angle, scaleX;

  void Start()
  {
    scaleX = transform.localScale.x;
  }

  void Update()
  {
    if(!GamePause.paused)
    {
      angle = GunLooking();
      GunShooting();
      AmmoMaxUpdate();
      ammoCount = Mathf.Clamp(ammoCount, 0, maxAmmo);
      ammoSlider.value = ammoCount;
    }
  }

  private float GunLooking()
  {
    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);

    float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

    if(angle + 180 >= 90 && angle + 180 <= 270)
    {
      transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
      gunPosition.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    } else {
      transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
      gunPosition.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180));
    }
    return(angle);
  }

  private float AngleBetweenPoints(Vector2 playerPosition, Vector2 mousePosition)
  {
    return Mathf.Atan2(playerPosition.y - mousePosition.y, playerPosition.x - mousePosition.x) * Mathf.Rad2Deg;
  }

  private void GunShooting()
  {
    if(Input.GetButtonDown("Fire1") && readyToShoot && ammoCount > 0 && !reloading)
    {
      ammoCount -= bulletAmount;
      StartCoroutine(ShootingDelay());
      readyToShoot = false;
      for(float a = bulletAmount; a > 0; a--)
      {
        Quaternion rotation = Quaternion.Euler(new Vector3(gunPosition.transform.rotation.x, gunPosition.transform.rotation.y, angle + (bulletAmount * 6) - (a * 6) - (bulletAmount * 2)));
        GameObject shotBullet = Instantiate(bullet, new Vector3(gunTip.position.x, gunTip.position.y, gunTip.position.z + 0.01f), rotation, bulletStorage.transform);
        shotBullet.GetComponent<BulletDamage>().damage = bulletDamage;
        shotBullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        shotBullet.GetComponent<Bullet>().ShootBullet();
        Instantiate(bulletSound);
      }
    } else if(Input.GetButtonDown("Fire1") && readyToShoot && ammoCount <= 0 && !reloading)
    {
      ammoWarning.SetActive(true);
    }

    if(Input.GetButtonDown("Reload") && !reloading)
    {
      reloadingBackground.SetActive(true);
      reloading = true;
      StartCoroutine(Reload());
    }
  }

  private IEnumerator ShootingDelay()
  {
    delayTimer.value = 0;
    for(int a = 0; a < 10; a++)
    {
      yield return new WaitForSeconds(attackSpeed/10);
      delayTimer.value += 1;
    }
    readyToShoot = true;
  }

  private IEnumerator Reload()
  {
    float reloadSpeedd = reloadSpeed/(maxAmmo - ammoCount);
    for(float a = ammoCount; a < maxAmmo; a++)
    {
      yield return new WaitForSeconds(reloadSpeedd);
      ammoCount++;
    }
    reloading = false;
    reloadingBackground.SetActive(false);
  }

  private void AmmoMaxUpdate()
  {
    maxAmmoSlider.value = maxAmmo;
  }
}
