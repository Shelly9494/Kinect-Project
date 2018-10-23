using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour {

    public Transform obj;
    public Transform centerPoint;

    float changeOffset;

	// Use this for initialization
	void Start () {
        changeOffset = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

        float speed = 2 * Time.deltaTime;

        if (transform.position.z != changeOffset && transform.position.z > changeOffset)
        {
            foreach (Transform other in obj)
            {
                other.position = Vector3.MoveTowards(other.position, centerPoint.position, speed);
            }
        } else if(transform.position.z != changeOffset && transform.position.z < changeOffset)
        {
            foreach (Transform other in obj)
            {
                other.position = Vector3.MoveTowards(other.position, centerPoint.position, -speed);
            }
        }

        changeOffset = transform.position.z;
	}
}
