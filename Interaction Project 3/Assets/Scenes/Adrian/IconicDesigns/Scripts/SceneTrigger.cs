using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Hand")
        {
            Debug.Log("Switch Scene");
            SceneManager.LoadScene("Scn_SBG_Shapes", LoadSceneMode.Single);
        }
    }
}
