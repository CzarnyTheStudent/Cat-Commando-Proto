using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{
    PlayerMovement pm;
    float timer = 0.1f;
    float mod=0.1f;
    float zVal = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(pm.moving==true)
        {
            Vector3 rot = new Vector3(0, 0, zVal);
            this.transform.eulerAngles = rot;

            timer -= Time.deltaTime;
            if (timer<=0)
            {
                zVal += mod;
            }

            if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z <10.0f)
            {
                mod = -0.05f;
            }
            else if (transform.eulerAngles.z <355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.05f;
            }

        }

    }
}
