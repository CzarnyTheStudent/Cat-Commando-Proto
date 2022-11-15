using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public GameObject Front;
    public GameObject Left;
    public GameObject Right;
    public GameObject Back;
    private void FixedUpdate()
    {
        Vector3 diffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diffrence.Normalize();

        float rotationZ = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 44)
        {
            Front.SetActive(false);
            Left.SetActive(false);
            Right.SetActive(true);
            Back.SetActive(false);
        }
        if (transform.eulerAngles.z >= 130 && transform.eulerAngles.z <= 180)
        {
            Front.SetActive(false);
            Left.SetActive(true);
            Right.SetActive(false);
            Back.SetActive(false);
        }
        if (transform.eulerAngles.z >= 44 && transform.eulerAngles.z <= 130)
        {
            Front.SetActive(false);
            Left.SetActive(false);
            Right.SetActive(false);
            Back.SetActive(true);
        }
        if (transform.eulerAngles.z >= 220 && transform.eulerAngles.z <= 340)
        {
            Front.SetActive(true);
            Left.SetActive(false);
            Right.SetActive(false);
            Back.SetActive(false);
        }
    }




}
