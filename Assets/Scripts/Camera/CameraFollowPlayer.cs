using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
   
    GameObject player;
    PlayerMovement pm;
    public bool followPlayer = true;
    Vector3 mousePos;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
  

        if (followPlayer == true)
        {
            camFollowPlayer ();
        }
    }
    public void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }
    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

}
