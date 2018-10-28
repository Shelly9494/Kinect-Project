using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingRotation : MonoBehaviour
{
    public float waterLevel = 0.01f;
    public float floatThreshold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    float forceFactor;
    Vector3 floatForce;
    Quaternion defaultRotation;
    private int countRotation;
    private int rotateSpeed;

    void Start()
    {
        defaultRotation = transform.localRotation;
        InvokeRepeating("Count", 3f, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waterLevel = Random.Range(-1f, 1f);
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatThreshold);

        if (forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }

    }

    void Update()
    {
        if (countRotation % 2 == 0)
        {
            transform.Rotate(Vector3.down * rotateSpeed, Space.World);
        }

        if (countRotation % 2 == 1)
        {
            transform.Rotate(Vector3.right * rotateSpeed, Space.World);
        }
    }

    void Count()
    {
        countRotation = Random.Range(0, 2);
        Debug.Log(countRotation);
    }
}