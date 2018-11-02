using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLines : MonoBehaviour {

    public Transform[] movePath;           
    
    private float speed;
    private int currentPos;
	 	
// Update is called once per frame
    void Update()
    {
        speed = Time.deltaTime * 5;

        if (transform.position != movePath[currentPos].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, movePath[currentPos].position, speed);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            currentPos = (currentPos + 1) % movePath.Length;
        }
    }
}

