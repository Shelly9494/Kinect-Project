using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    Scene currentScene;
    public GameObject createdCanvas;
    public TMPro.TextMeshProUGUI counter;
    int count_down;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        //Debug.Log(currentScene.name);
        count_down = 180;
    }

    public void SwitchScene()
    {
        if(currentScene.name == "Scn_RTBG_Brush")
        {
            //Debug.Log("Switch Scene");
            SceneManager.LoadScene("Scn_RTBG_SpellingGame", LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brush")
            CancelInvoke();

        if (createdCanvas.activeInHierarchy == true)
        {
            createdCanvas.SetActive(false);
        }
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Brush")
        {
            Invoke("SwitchScene", count_down);
            InvokeRepeating("CreateTimer", 0f, 1f);
        }   
            
        Debug.Log("Leave");
    }

    void CreateTimer()
    {

        if(count_down > 0)
        {
            count_down--;
            counter.text = count_down.ToString();
        }
        else
        {
            CancelInvoke();
        }
        if (createdCanvas.activeInHierarchy == false && count_down < 10)
        {
            createdCanvas.SetActive(true);
        }
    }
}
