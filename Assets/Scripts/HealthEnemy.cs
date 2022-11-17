using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HealthEnemy : MonoBehaviour
{
    [SerializeField] float enemyHealth, maxEnemyHealth; // 1

    private bool dead;


    private void Start()
    {
       enemyHealth = maxEnemyHealth;
    }
    void Update()
    {
        if (dead == true)
        {
            //SET DEAD CODE
            Destroy(gameObject);
        }

        
    }

    public void TakeDamage(int d) //d to damage zjebie
    {
        if (enemyHealth >= 1)
        {
            enemyHealth -= d; //1-1=0     
            if (enemyHealth < 1)
            {
                dead = true;
            }
        }


    }

    
}


