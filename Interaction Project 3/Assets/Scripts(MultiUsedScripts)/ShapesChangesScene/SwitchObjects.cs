using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchObjects : MonoBehaviour
{

    public GameObject[] findShapes;
    //public AudioSource clickAudio;

    private int currentShape;
    private int count;

    //SceneManagerScript sceneManager;

    // Use this for initialization
	void Start () {


        //clickAudio = GetComponent<AudioSource>();

        currentShape = Random.Range(0, findShapes.Length);
        count = 0;
        

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
                    findShapes[currentShape].SetActive(true);
                    //findShapes[currentShape].transform.localScale = new Vector3(Random.Range(0, 100) * 0.1f, Random.Range(0,100) * 0.1f,0);
               
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

            count++;
            Debug.Log(count);

            if (count > 30)
            {
                SceneManager.LoadScene("Scn_RTBG_Brush", LoadSceneMode.Single);
            }
           
        }
        
     }
}

