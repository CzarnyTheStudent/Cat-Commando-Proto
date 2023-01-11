using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float radius = 0.5f;

    private void Update()
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(transform.position, radius);
        {
            foreach(Collider2D col in playerHit)
            {
                Health playerHealth = col.GetComponent<Health>();
                if (playerHealth != null) playerHealth.TakeDamage(1);
            }
        }
    }

    public void DestroyIt()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
