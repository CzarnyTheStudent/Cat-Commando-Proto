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
    public float reloadTime;
    public float fireRate;

    private float lastShootTime = 0;
    //bools
    bool shooting;
    private bool isReloading = false;
    //bool reload;

    //Reference
    public Transform attackPoint;
    public RaycastHit bulletHit;
    public LayerMask whatIsEnemy;
    public Weapon weapon;

    void OnEnable()
    {
        
        
    }


    private void Update()
    {

      
        if (shooting = Input.GetButtonDown("Fire1") && isReloading == false)
            {
           
            
                weapon.Shoot();
            
            
            
           
        }
       
        if ( Input.GetKeyDown(KeyCode.R)) //currentClip == 0 |
        {
            StartCoroutine("Reload");



           
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
    


    IEnumerator Reload()
    {
        
        isReloading = true;
        Debug.Log("Prze³adowuje");
        int reloadAmount = maxClipSize - currentClip; //Ile kul by na³adowaæ magazynek
        reloadAmount = (currentAmmo - reloadAmount) >=0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
        yield return new WaitForSeconds(reloadTime);

        isReloading = false;
        Debug.Log("Prze³adowano");

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
