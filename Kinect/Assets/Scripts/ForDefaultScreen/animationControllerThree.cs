using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControllerThree : MonoBehaviour {
    float speed = 1.0f;
    float amount = 1.0f;
    Vector3 pos;

    // Use this for initialization
    void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        pos.x = Mathf.Sin(Time.time * speed) * amount;

		
	}
}
