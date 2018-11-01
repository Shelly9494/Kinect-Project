using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAction : MonoBehaviour
{

    //Script for managing magnet movement

    //Public variables
    public Vector3 newPosition; // The target position

    //Private variables
    private Transform trans;

    void Awake()
    {
        trans = transform;
    }

    void Update()
    {
        trans.position = Vector3.Lerp(trans.position, newPosition, Time.deltaTime * 1.75f);

        if (Mathf.Abs(newPosition.x - trans.position.x) < 0.05)
            trans.position = newPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
            Destroy(other.gameObject);
    }
}
