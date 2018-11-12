using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour {

    int count;
    int lastCount;
    public GameObject canvasPrefab;
    public TMPro.TextMeshProUGUI counter;
    Transform textSpawner;
    Scene currentScene;

    GameObject[] canvas;

    // Use this for initialization
    void Start () {
        count = 100;
        lastCount = 100;
        counter.text = count.ToString();
        textSpawner = GameObject.Find("TextSpawner").transform;
        Instantiate(canvasPrefab, textSpawner.position, Quaternion.identity);
        currentScene = SceneManager.GetActiveScene();

        InvokeRepeating("DoubleCheck", 10f, 20f);
    }

    void Update()
    {

    }

    public void CreateCanvas()
    {
        count--;
        counter.text = count.ToString();
        canvas = GameObject.FindGameObjectsWithTag("Canvas");

        if (canvas.Length != 0)
        {
            foreach (GameObject item in canvas)
            {
                Destroy(item);
            }
        }

        Instantiate(canvasPrefab, textSpawner.position, Quaternion.identity);

        if (count == 0)
        {
            Debug.Log("Change Scene");
            SceneManager.LoadScene("Scn_RTBG_BrushOriginal", LoadSceneMode.Single);
        }
        
    }


    void CompareNumber()
    {
        lastCount = count;
    }

    void DoubleCheck()
    {
        if(count == lastCount && currentScene.name == "Scn_SBG_Shapes")
            SceneManager.LoadScene("Scn_RTBG_SpellingGame", LoadSceneMode.Single);
        else
        {
            CompareNumber();
        }
        Debug.Log("Double Check");
    }
}
