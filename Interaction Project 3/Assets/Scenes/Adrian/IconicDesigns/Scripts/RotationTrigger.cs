using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    public ObjectRotator objRotate;
    
    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Hand")
        {
            objRotate.StartRotation();
            //Debug.Log("Touch");
        }       
    }
}
