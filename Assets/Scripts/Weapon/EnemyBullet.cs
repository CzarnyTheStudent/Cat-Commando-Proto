using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
  

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Enemies to take damage
        if (collision.gameObject.TryGetComponent<Health>(out Health playerComponent))
        {
            playerComponent.TakeDamage(1);
        }

        if (collision.gameObject.TryGetComponent<HealthEnemy>(out HealthEnemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

        if (collision.gameObject.TryGetComponent<TableStrength>(out TableStrength tableComponent))
        {
            tableComponent.Damage(1);
        }


        Destroy(gameObject); //niszczy kule za ka�dym razem przy kontakcie
    }

}
