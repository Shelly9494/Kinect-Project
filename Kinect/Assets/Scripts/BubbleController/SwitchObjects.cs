using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjects : MonoBehaviour {

    public GameObject[] findShapes;

    private int currentShape;

    // Use this for initialization
	void Start () {

       
        currentShape = Random.Range(0, findShapes.Length);
        
        findShapes[currentShape].SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if(collider.tag == "Hand")
        {
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
