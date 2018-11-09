using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {

    float rotateSpeed = 2f;
    Quaternion targetAngels;

    // Use this for initialization
    void Start () {

        //targetAngels = Quaternion.Euler(0, 90f, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        RotateObject();
    }

    void RotateObject()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngels, rotateSpeed * Time.deltaTime);

        if (Quaternion.Angle(targetAngels, transform.rotation) < 1)
        {
            transform.rotation = targetAngels;
        }
       
    }
}
