﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FloatingThree : MonoBehaviour {

    float moveSpeed = 3f;
    float rotSpeed = 100f;

    bool isWandering = false;
    bool isRotatingLeft = false;
    bool isRotatingRight = false;
    bool isWalking = false;

    void Start()
    {

    }

    void Update()
    {
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if(isRotatingRight == true)
        {
            transform.Rotate(transform.forward * Time.deltaTime * rotSpeed);
        }
        if(isRotatingLeft == true)
        {
            transform.Rotate(transform.forward * Time.deltaTime * -rotSpeed);
        }
        if(isWalking == true)
        {
            
            transform.position += transform.right * moveSpeed * Time.deltaTime; 
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(3, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;
        yield return new WaitForSeconds(walkWait);

        isWalking = true;
        yield return new WaitForSeconds(walkTime);

        isWalking = false;
        yield return new WaitForSeconds(rotateWait);

        if(rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }

        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;

    }
    
}