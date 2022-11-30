using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
//using static UnityEngine.GraphicsBuffer;

public class EnemyRangeOfVision : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    //public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    //dodatki
    public Transform player;
    private Rigidbody2D rb;
    //
    public float speed;
    public float minimumDistance;
    //
    // Attack
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask targetLayers;

    private void Start()
    {
       // playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canSeePlayer == true)
        {
            FollowToYou();
            Obserwacja();
        }
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


    void Obserwacja()
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

    private void Attack()
    {
        Collider2D[] hitTarget = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);

        //Damage
        foreach(Collider2D target in hitTarget)
        {
            target.GetComponent<Health>().TakeDamage(1);
           
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
