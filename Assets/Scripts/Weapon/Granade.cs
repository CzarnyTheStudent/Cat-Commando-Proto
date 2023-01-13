using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;


public class Granade : MonoBehaviour
{

    private float timeToExplode;
    private int bounceState;
    
    //private float explodePass;
    //public bool explosionTrue;

    public GameObject explosion;


    public static void Create(Transform pfGranade, Vector3 spawnPosition, Vector3 targetPosition)
    {
        Granade grenade = Instantiate(pfGranade, spawnPosition, Quaternion.identity).GetComponent<Granade>();

        grenade.Setup(targetPosition);
    }

    
    
    private void Setup(Vector3 targetPosition)
    {
        Vector3 moveDirection = targetPosition - transform.position.normalized;
        float moveSpeed = 250f;
        gameObject.GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed;
        transform.localEulerAngles = new Vector3(0,0, UtilsClass.GetAngleFromVector(moveDirection));

        timeToExplode = 0f;
        bounceState = 0;
        //explodePass = 0.5f;
    }

    private void Update()
    {
        switch (bounceState)
        {
            default:
            case 0:
                transform.localScale += Vector3.one * 7f * Time.deltaTime;
                if (transform.localScale.x >= 2.5f) bounceState =1;
                break;
            case 1:
                transform.localScale -= Vector3.one * 7f * Time.deltaTime;
                if (transform.localScale.x <= 1f) bounceState = 2;
                break;
            case 2:
                break;
        }

        timeToExplode += Time.deltaTime;
        if (timeToExplode > 3f)
        {
            //ExplodeGrenade();
            //explosionTrue = true;
            StartCoroutine(ExplodeGrenade(1));
           
        }
    }



    /*
    void ExplodeGrenade()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        if (explosionTrue == true)
        {
            explodePass += Time.deltaTime;
            if (explodePass > 0)
            {

                
                Destroy(gameObject);
            }

        }


    }
    
    **/


    IEnumerator ExplodeGrenade(float time)
    {
        


        yield return new WaitForSeconds(time);

        Debug.Log("Koniec explozji");
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);

    }

    



}
