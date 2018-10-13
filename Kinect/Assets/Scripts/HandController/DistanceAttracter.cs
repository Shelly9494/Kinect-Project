using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttracter : MonoBehaviour {

    public Transform playerMovement;
    public Transform testObj;
    public GameObject cube_1;
    public Transform cube_2;

    private Vector3 _distanceOffset;
    private float distance;
	// Use this for initialization
	void Start () {
        _distanceOffset = playerMovement.position - testObj.position;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {

        float change = (playerMovement.position.z - testObj.position.z)*0.5f;

        if (change != (_distanceOffset.z * 0.5f) && change < (_distanceOffset.z * 0.5f))
        {
            cube_2.position = new Vector3(cube_2.position.x + change * 0.01f, cube_2.position.y, cube_2.position.z);
            _distanceOffset.z = change * 2;
        }
        if (change != (_distanceOffset.z * 0.5f) && change > (_distanceOffset.z * 0.5f))
        {
            cube_2.position = new Vector3(cube_2.position.x - change * 0.01f, cube_2.position.y, cube_2.position.z);
            _distanceOffset.z = change * 2;
        }
       
	}

}
