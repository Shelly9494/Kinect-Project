using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{

    Transform objTransform;

    public float waterLevel = 0.01f;
    public float floatThreshold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    float forceFactor;
    Vector3 floatForce;
    private float x;
    private float y;

    private float countRotation;

    void Start()
    {
        countRotation = 0;
        x = 0;
        y = 0;
        InvokeRepeating("Rotation", 2.0f, 3.0f);
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

        StartCoroutine(WaitForRotate());
       
    }

    IEnumerator WaitForRotate()
    {
        yield return new WaitForSeconds(10);
        
        Debug.Log(countRotation);
    }

    void Rotation()
    {
        countRotation++;
        if (countRotation % 2 ==0)
        {
            x = x + 90;
            objTransform.localEulerAngles = new Vector3(x , y, 0);
        }
        if(countRotation % 2 == 1)
        {
            y = y + 90;
            objTransform.localEulerAngles = new Vector3(x, y, 0);
        }
    }
}