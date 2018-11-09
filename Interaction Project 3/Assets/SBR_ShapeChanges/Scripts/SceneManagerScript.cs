using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "Scn_RTBG_Brush")
        Invoke("SwitchScene", 60);
    }


    public void SwitchScene()
    {
        Debug.Log("Switch Scene");
        SceneManager.LoadScene("Scn_RTBG_Shapes", LoadSceneMode.Single);
    }
}
