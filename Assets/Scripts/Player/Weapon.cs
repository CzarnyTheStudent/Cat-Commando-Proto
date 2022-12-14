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
    

    //private float lastShootTime = 0;
    private float timeBtwShots;
    public float startTimeBtwShots;
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

    void Start()
    {
       
    }

    private void Update()
    {

      
        if (shooting = Input.GetButtonDown("Fire1") && isReloading == false)
            {

           timeBtwShots = startTimeBtwShots;
            weapon.Shoot();
            
            
            
           
        }
       
        if ( Input.GetKeyDown(KeyCode.R)) //currentClip == 0 |
        {
            StartCoroutine("Reload");



           
        }
        

    }
    



    void Shoot()
    {
        if (currentClip > 0 && timeBtwShots <= 0)
        {
          



                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                currentClip--;
                timeBtwShots = Time.deltaTime;

            
            
        }


    }
    


    IEnumerator Reload()
    {
        
        isReloading = true;
        Debug.Log("Przeładowuje");
        int reloadAmount = maxClipSize - currentClip; //Ile kul by naładować magazynek
        reloadAmount = (currentAmmo - reloadAmount) >=0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
        yield return new WaitForSeconds(reloadTime);

        isReloading = false;
        Debug.Log("Przeładowano");

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
