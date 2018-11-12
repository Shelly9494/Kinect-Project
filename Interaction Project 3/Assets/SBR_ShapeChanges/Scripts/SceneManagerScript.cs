using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    Scene currentScene;
    

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.name);
    }

    public void SwitchScene()
    {
        if(currentScene.name == "Scn_RTBG_BrushOriginal")
        {
            Debug.Log("Switch Scene");
            SceneManager.LoadScene("Scn_RTBG_SpellingGame", LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brush")
            CancelInvoke();
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Brush")
            Invoke("SwitchScene", 5f);

        Debug.Log("Leave");
    }
}
