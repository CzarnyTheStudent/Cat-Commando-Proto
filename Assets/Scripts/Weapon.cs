using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Gun stats and graphic
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public int currentClip, maxClipSize = 6, currentAmmo, maxAmmoSize = 18;


    //bools
    bool shooting;

    //Reference
    public Transform attackPoint;
    public RaycastHit bulletHit;
    public LayerMask whatIsEnemy;
    public Weapon weapon;
    
    private void Update()
    {
        if (shooting = Input.GetButtonDown("Fire1"))
            {
            weapon.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();

        }
        

    }

    void Shoot()
    {
        if (currentClip > 0)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            currentClip--;
        }


    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip; //Ile kul by na³adowaæ magazynek
        reloadAmount = (currentAmmo - reloadAmount) >=0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo (int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }



}
