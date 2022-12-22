using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDrop : MonoBehaviour
{
    public GameObject flippedVersion;
    public bool interactRange;

    public Transform player;

    void Update()
    {
        if(interactRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
              
                Instantiate(flippedVersion, transform.position, player.rotation);
                Destroy(gameObject);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            interactRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactRange = false;
        }
    }


}
