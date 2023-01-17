using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using static UnityEngine.GraphicsBuffer;
//using static UnityEngine.GraphicsBuffer;

public class EnemyRangeOfVision : MonoBehaviour
{
    //Broñ strzelaj¹ca
    public Transform firePoint;
    public float force;


    private float timer;
    public float phaseTime;
    public bool canShoot;
    public bool canShotgun;
    public bool canGranade;
    public bool BOSS;

    public int pelletCount;
    public float spread;
    
    // Tu dajemy kulki, granaty itp
    public GameObject pellet;
    public GameObject eBulletPrefab;
    public GameObject pfGrenade;
    public Animator animator;



    public LayerMask targetMask;
    public LayerMask obstructionMask;

    //Szybkoœæ i dystas od gracza jaki ma utrzymywaæ
    public float speed;
    public float minimumDistance;
    //
    // Attack
    public Transform attackPoint;
    public float attackRange = 1f;
    //Zasiêg widzenia
    public float radius;
    [Range(0,360)]
    public float angle;
    //Czy nas widzi
    public bool canSeePlayer;

    public Transform player;
    private Rigidbody2D rb;

   

    private void Start()
    {

      
       
        StartCoroutine(FOVRoutine());
        rb = this.GetComponent<Rigidbody2D>();
    }
   

    public void Update()
    {
        animator = GetComponent<Animator>();

        if (canSeePlayer == false)
        {

            nieWidze();

        }


        if (canSeePlayer == true)
        {
            Obserwacja();
            FollowToYou();

           animator.SetBool("canSeePlayer2", true);

            if (canShoot == true)
            {
                timer += Time.deltaTime;
                if (timer > 1)
                {
                    timer = 0;
                    Shoot();

                }
            }

            if (canShotgun == true)
            {

                timer += Time.deltaTime;
                if (timer > 2)
                {
                    timer = 0;
                    Shotgun();

                }
            }

            if (BOSS == true)
            {
                StartCoroutine("IamTheBoss");
               
            }


            if (canGranade == true)
            {

                timer += Time.deltaTime;
                if (timer > 2)
                {
                    timer = 0;
                    Grenade();

                }
            }

            
        }
    }

    
    public void nieWidze()
    {
        
            

            animator.SetBool("canSeePlayer2", false);

        

    }
    

    private IEnumerator FOVRoutine()
    {
      
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }



    }


    public void FieldOfViewCheck()
    {
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.right, directionToTarget) < angle * 0.5f)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    
                    
                }




                else
                    canSeePlayer = false;
           

            }
            else
                canSeePlayer = false;
       

        }
        else if (canSeePlayer)
            canSeePlayer = false;
     

    }








    public void Obserwacja()
    {

        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

        }
    }

    void FollowToYou()
    {
        if (Vector2.Distance(transform.position, player.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
            
                Attack();
           

        }
        /*
        else
        {
            
        }
        **/
    }

    void Shoot()
    {
        
        GameObject bulletEnemy = Instantiate(eBulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bulletEnemy.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);


    }


    void Shotgun()
    {
        
        /*
        foreach (Quaternion quat in pellets)
        {
            pellets = Random.rotation;
            GameObject p = Instantiate(pellet, firePoint.position, firePoint.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets, spread);
            p.GetComponent<Rigidbody2D>().AddForce(p.transform.up * pelletFireVel);
           
        }

        **/


        
        for (int i = 0; i < pelletCount; i++)
        {
            GameObject p = Instantiate(pellet, firePoint.position, firePoint.rotation);
            Rigidbody2D brb = p.GetComponent<Rigidbody2D>();


            Vector2 dir = transform.rotation * Vector2.right;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
            brb.velocity = (dir + pdir) * force;
                    
            

           



        }
        


    }


    void Grenade()
    {

       GameObject grenadeEnemy = Instantiate(pfGrenade, firePoint.position, firePoint.rotation);
        //Granade.Create(pfGrenade, firePoint, e.shootPosition);
        Rigidbody2D xb = grenadeEnemy.GetComponent<Rigidbody2D>();

        xb.AddForce(firePoint.up * force, ForceMode2D.Impulse);

    }
    
    private void OnGrenadeExplode(Vector3 position)
    {

    }



    private void Attack()
    {
        Collider2D[] hitTarget = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetMask);

        //Damage
        foreach (Collider2D target in hitTarget)
        {
            target.GetComponent<Health>().TakeDamage(1);

        }



    }

    IEnumerator IamTheBoss()
    {
      
        if (BOSS == true)
        {
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                timer = 0;
                Shoot();




            }





        }

        yield return new WaitForSeconds(phaseTime);


        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            timer = 0;
            Shotgun();





        }







    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }








}
