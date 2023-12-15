using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    public Transform player;  
    public GameObject bulletPrefab;  
    public Transform ShootStart;  
    public float Rate = 2f;  
    private float CoolDown = 0f;  
    void Update()
    {
        
        if (Time.time - CoolDown > Rate)
        {
           
            RotateTowardsPlayer();

            
            Shoot();

          
            CoolDown = Time.time;
        }
    }

    void RotateTowardsPlayer()
    {
       
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;  

        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, ShootStart.position, ShootStart.rotation);

        
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10f;

        
        Destroy(bullet, 3f);
    }
}
