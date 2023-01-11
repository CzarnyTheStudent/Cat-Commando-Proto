using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIT : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            Destroy(gameObject);

        }

    }
}
