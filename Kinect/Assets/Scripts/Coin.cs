using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Script for managing coin movements

    //Public variables
    public float magnetStrength = 5f;
    public float distanceStrength = 10f; // Magnetic strength based on the distance
    public int magnetDirection = 1; // 1 = attract, -1 = repel
    public bool looseMagnet = true;

    //Private variables
    private Transform trans;
    private Rigidbody thisRb;
    private Transform magnetTrans;
    private bool magnetInZone;

    void Awake()
    {
        trans = transform;
        thisRb = trans.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (magnetInZone)
        {
            Vector3 directionToMagnet = magnetTrans.position - trans.position;
            float distance = Vector3.Distance(magnetTrans.position, trans.position);
            float magnetDistanceStr = (distanceStrength / distance) * magnetStrength;

            thisRb.AddForce(magnetDistanceStr * (directionToMagnet * magnetDirection), ForceMode.Force);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet")
        {
            magnetTrans = other.transform;
            magnetInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Magnet" && looseMagnet)
        {
            magnetInZone = false;
        }
    }

}
