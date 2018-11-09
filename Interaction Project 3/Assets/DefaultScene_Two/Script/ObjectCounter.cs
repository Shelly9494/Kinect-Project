using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCounter : MonoBehaviour
{

    int count;

    public GameObject canvasPrefab;
    public TMPro.TextMeshProUGUI counter;
    Transform textSpawner;

    GameObject[] canvas;

	// Use this for initialization
	void Start () {
        count = 50;
        counter.text = count.ToString();
        textSpawner = GameObject.Find("TextSpawner").transform;
        Instantiate(canvasPrefab, textSpawner.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Hand")
        {
            count--;
            counter.text = count.ToString();
            canvas = GameObject.FindGameObjectsWithTag("Canvas");

            if (canvas.Length != 0)
            {
                foreach(GameObject item in canvas)
                {
                    Destroy(item);
                }
            }
            Instantiate(canvasPrefab, textSpawner.position, Quaternion.identity);

            if(count == 0)
            {
                Debug.Log("Change Scene");
                SceneManager.LoadScene("Scn_RTBG_BrushOriginal", LoadSceneMode.Single);
            }
        }
    }
}
