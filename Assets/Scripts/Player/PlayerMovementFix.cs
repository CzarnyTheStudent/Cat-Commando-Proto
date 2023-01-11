using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFix : MonoBehaviour
{

    [SerializeField] private LayerMask dashLayerMask;
    [SerializeField] private TrailRenderer tr;
    public Rigidbody2D rb;
    public float speed;

    private Vector3 moveDir;

    
    private bool isDashing;
    public float dashingPower;
    public float cooldownDash;
    private float nextDashTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;

        if (Time.time > nextDashTime)
        {

            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDashing = true;

               
                nextDashTime = Time.time + cooldownDash;
                
            }
        }
        


    }


    /*
    private IEnumerator Dash ()
    {
        canDash = false;
        isDashing = true;

        rb.velocity = new Vector3(transform.position.x * dashingPower, transform.position.y * dashingPower);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;


    }
    **/


    private void FixedUpdate()
    {



        
        rb.velocity = moveDir * speed;

        if (isDashing == true)
        {
            Vector3 dashPosition = transform.position + moveDir * dashingPower;
            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashingPower, dashLayerMask);
            if (raycastHit2d.collider != null)
            {
                dashPosition = raycastHit2d.point;
            }

            

            rb.MovePosition(transform.position + moveDir * dashingPower);
            isDashing = false;
            
        
        }

        
        


    }


}
