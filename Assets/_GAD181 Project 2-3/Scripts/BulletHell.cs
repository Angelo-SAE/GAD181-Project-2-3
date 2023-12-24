using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float Rate = 3f;
    

    void Start()
    {
        
        InvokeRepeating("ShootBullets", 0f, Rate);
    }

   
    void ShootBullets()
    {
        
        SpawnBullet(Vector2.up);
        SpawnBullet(Vector2.down);
        SpawnBullet(Vector2.left);
        SpawnBullet(Vector2.right);
    }

    void SpawnBullet(Vector2 direction)
    {
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        
        bullet.transform.up = direction;
        
    }
}
