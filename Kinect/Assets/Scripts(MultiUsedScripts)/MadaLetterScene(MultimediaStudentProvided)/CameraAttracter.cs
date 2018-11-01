using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttracter : MonoBehaviour {

    public Transform playerTransform;
    public Transform focusTraget;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;


	// Use this for initialization
	void Start () {
        _cameraOffset = transform.position - playerTransform.position;
	}
	
	
	void Update () {
        Vector3 newPos = playerTransform.position + _cameraOffset;
        Vector3 targetDir = focusTraget.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, smoothFactor, 0.0f);


        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        transform.rotation = Quaternion.LookRotation(newDir);
	}
}
