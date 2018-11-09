using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchObjectsAndExplode : MonoBehaviour
{

    public GameObject[] findShapes;
    //public AudioSource clickAudio;

    private int currentShape;
    private int count;

    //SceneManagerScript sceneManager;

    // Use this for initialization
	void Start () {


        //clickAudio = GetComponent<AudioSource>();

        currentShape = Random.Range(0, findShapes.Length - 1);
        count = 0;
        

        findShapes[currentShape].SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if(collider.tag == "Hand")
        {
            
            if (currentShape < findShapes.Length - 2)
            {
                currentShape++;
                //Debug.Log(findShapes.Length);

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
                            if(item.tag == "Particle")
                            {
                                item.SetActive(true);
                                Destroy(item.transform.parent.gameObject.GetComponent<Rigidbody2D>());
                                Destroy(item.transform.parent.gameObject, 2);
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

            //count++;
            Debug.Log(count);

            //if (count > 30)
            //{
            //    SceneManager.LoadScene("Scn_RTBG_Brush", LoadSceneMode.Single);
            //}
            
        }
        
     }
}

