﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjects : MonoBehaviour {

    public GameObject[] findShapes;
    public AudioSource clickAudio;

    private int currentShape;

    // Use this for initialization
	void Start () {

<<<<<<< HEAD
        clickAudio = GetComponent<AudioSource>();
        currentShape = Random.Range(0, findShapes.Length - 1);
=======
       
        currentShape = Random.Range(0, findShapes.Length);
        
>>>>>>> 840fb3f020a90bd39db09fbc4b663198b4ed0a4e
        findShapes[currentShape].SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if(collider.tag == "Hand")
        {
            clickAudio.Play();
            if (currentShape < findShapes.Length - 1)
            {
                currentShape++;
                Debug.Log(findShapes.Length);

                foreach (GameObject item in findShapes)
                {
                    if(item != null)
                    {
                        item.SetActive(false);
                    }
                    
                }
                Debug.Log(currentShape);
                if(findShapes[currentShape] != null)
                {
                    findShapes[currentShape].SetActive(true);
                }
            }
            else
            {
                currentShape = 0;
                foreach (GameObject item in findShapes)
                {
                    if(item != null)
                    {
                        item.SetActive(false);
                    }
                    
                }
                if(findShapes[currentShape] != null)
                {
                    findShapes[currentShape].SetActive(true);
                }
               
            }
        }
        
    }
}
