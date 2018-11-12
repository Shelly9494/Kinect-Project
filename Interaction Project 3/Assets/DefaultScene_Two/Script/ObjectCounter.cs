using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectCounter : MonoBehaviour
{

    Counter counterClass;

    void Start()
    {
        counterClass = GameObject.Find("Counter").GetComponent<Counter>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag != "Hand")
        {
            counterClass.CreateCanvas();
        }
    }
 
}