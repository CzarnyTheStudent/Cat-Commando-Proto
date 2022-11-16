using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text collectedText;
    public static int collectedAmount = 0;
    public bool moving = true;
    public float speed;

    //Movment gracza NIEPOTRZEBNE
    //USUNIÊTE
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
            if (moving == true)
        { 
            movement();
            collectedText.text = "MLEKO ZEBRANE: " + collectedAmount;
        }
        movementCheck();
    }

    public void setMoving(bool val)
    {
        moving = val;
    }
    
    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate (Vector3.down * speed * Time.deltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate (Vector3.left * speed * Time.deltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate (Vector3.right * speed * Time.deltaTime, Space.World);
            moving = true;
        }
    }

    void movementCheck()
        {
            if (Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.S) != true && Input.GetKey(KeyCode.W) != true)
            {
                moving = false;
            }
            else
            {
            moving = true;
            }


        }





    
}
