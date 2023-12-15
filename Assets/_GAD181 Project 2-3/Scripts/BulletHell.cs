using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform BulletStart;    
    public float Rate = 1.0f; 

    private float timer = 0f;

    void Update()
    {
       
        timer += Time.deltaTime;

        
        if (timer >= Rate)
        {
            
            SpawnBullet();

            
            timer = 0f;
        }
    }

    void SpawnBullet()
    {
       
        GameObject bullet = Instantiate(bulletPrefab, BulletStart.position, Quaternion.identity);

      
        bullet.transform.parent = transform;
    }
}
