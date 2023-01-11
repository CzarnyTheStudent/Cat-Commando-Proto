using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //Enemies to take damage
        if(collision.gameObject.TryGetComponent<HealthEnemy>(out HealthEnemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

        Destroy(gameObject); //niszczy kule za ka¿dym razem przy kontakcie
    }
}
