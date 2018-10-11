using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetChangeDirection : MonoBehaviour
{

    //Public variables
    public Vector3 magnetDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet")
            other.GetComponent<MagnetAction>().newPosition = magnetDirection;
    }



}
