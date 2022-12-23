using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStrength : MonoBehaviour
{
    public int health, maxHealth;

    private bool damaged;
    private bool destroyed;



    private void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (damaged == true)
        {
            
        }


        if (destroyed == true)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int d)
    {

        if (health == 2)
        {
            health -= d; //1-1=0     
            if (health < 2)
            {
                damaged = true;
            }
        }

        if (health >= 1)
        {
            health -= d; //1-1=0     
            if (health < 1)
            {
                destroyed = true;
            }
        }


    }
}
