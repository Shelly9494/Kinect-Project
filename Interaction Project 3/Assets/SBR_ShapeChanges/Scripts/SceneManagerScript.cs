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
        count_down = 240 ;

        Invoke("CheckBrushes", 0f);
    }

    public void SwitchScene()
    {
        if(currentScene.name == "Scn_RTBG_Brush")
        {
            Debug.Log("Switch Scene");
            SceneManager.LoadScene("Scn_RTBG_SpellingGame", LoadSceneMode.Single);
        }
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

    }

    public void CheckBrushes()
    {
            Invoke("SwitchScene", count_down);
            InvokeRepeating("CreateTimer", 0f, 1f);
            Debug.Log("Check Users");
    }

    public void CancelInvokeFun()
    {

    }
}
