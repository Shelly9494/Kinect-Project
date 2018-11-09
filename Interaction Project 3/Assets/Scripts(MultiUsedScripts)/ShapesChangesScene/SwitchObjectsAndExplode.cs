using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjectsAndExplode : MonoBehaviour
{

    public GameObject[] findShapes;
    //public AudioSource clickAudio;

    private int currentShape;

    //SceneManagerScript sceneManager;

    // Use this for initialization
	void Start ()
    {
        //clickAudio = GetComponent<AudioSource>();

        currentShape = Random.Range(0, findShapes.Length - 2);

        findShapes[currentShape].SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if(collider.tag == "Hand")
        {

            Destroy(findShapes[currentShape].transform.parent.gameObject.GetComponent<Rigidbody2D>());

            if (currentShape < findShapes.Length - 2)
            {
                currentShape++;

                foreach (GameObject item in findShapes)
                {
                    if(item != null)
                    {
                        item.SetActive(false);
                    }
                    
                }
                //Debug.Log(currentShape);
                if(findShapes[currentShape] != null)
                {

                    
                    if (findShapes[currentShape].tag == "Explode")
                    {
                        findShapes[currentShape].SetActive(false);

                        foreach(GameObject item in findShapes)
                        {
                            Debug.Log(item.transform.parent.gameObject);
                            if (item.tag == "Particle")
                            {
                                item.SetActive(true);
                                Destroy(item.transform.parent.gameObject.GetComponent<BoxCollider2D>());
                                Destroy(item.transform.parent.gameObject, 3.5f);
                            }
                        }
                    }
                        //findShapes[findShapes.Length - 1].SetActive(true);
                        

                        //if time is too long 
                        
                    else
                    {
                        findShapes[currentShape].SetActive(true);

                    }

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
                if (findShapes[currentShape] != null)
                {
                    findShapes[currentShape].SetActive(true);
                }
            }
            //clickAudio.Play();
            
        }
        
     }
}

