using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube")
        {
            StartCoroutine(Wait());
            Debug.Log(Wait());
            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene("Scn_RTBG_2DBubble", LoadSceneMode.Single);
    }
}
