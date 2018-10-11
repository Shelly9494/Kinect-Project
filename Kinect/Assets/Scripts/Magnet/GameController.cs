using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Public variables
    public GameObject coin;

    //Private variables
    private Rigidbody coinRb;

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 20f;

            Vector3 instancePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Instantiate(coin, instancePosition, Quaternion.identity);
        }
    }

}
