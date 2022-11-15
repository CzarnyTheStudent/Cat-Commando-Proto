using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    //Gun stats and graphic
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    //public float bulletSpeed = 10;



    //bools
    bool shooting;

    //Reference
    public Transform attackPoint;
    public RaycastHit bulletHit;
    public LayerMask whatIsEnemy;

    //Graphic
   
    //public ammoText;

    
    
    private void Update()
    {
        if (shooting = Input.GetButtonDown("Fire1"))
            {
            Shoot();
        }

        

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }




}
