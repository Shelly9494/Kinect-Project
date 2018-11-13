using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconChangeScene : MonoBehaviour {

    Scene currentScene;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "Scn_RTBG_Icons")
                Invoke("ChangeToScene", 1);
        }
    }

    void ChangeToScene()
    {
        SceneManager.LoadScene("Scn_RTBG_Brush", LoadSceneMode.Single);
    }
}
