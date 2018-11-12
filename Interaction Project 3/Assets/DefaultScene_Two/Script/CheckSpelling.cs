using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSpelling : MonoBehaviour {

    int cubeNumbers;
    
    GameObject mainPosition;
    GameObject madaPosition;
    GameObject artPosition;
    GameObject designPosition;

    // Use this for initialization
    void Start () {
        mainPosition = GameObject.Find("Position");

        madaPosition = mainPosition.transform.Find("MadaPosition").gameObject;
        artPosition = mainPosition.transform.Find("ArtPosition").gameObject;
        designPosition = mainPosition.transform.Find("DesignPosition").gameObject;

	}

    void Update()
    {
        cubeNumbers = transform.childCount;

        if (madaPosition.activeInHierarchy)
        {
            if(cubeNumbers == 4)
            {
                Debug.Log(cubeNumbers);

                StartCoroutine(WaitToChangeScene());
            }
            else
            {
                StartCoroutine(WaitForDoubleCheck());
            }
        }

        if (artPosition.activeInHierarchy)
        {
            if(cubeNumbers == 3)
            {
                StartCoroutine(WaitToChangeScene());
            }
            else
            {
                StartCoroutine(WaitForDoubleCheck());
            }
        }

        if (designPosition.activeInHierarchy)
        {
            if(cubeNumbers == 6)
            {
                StartCoroutine(WaitToChangeScene());
            }
            else
            {
                StartCoroutine(WaitForDoubleCheck());
            }
        }
    }

    IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(5);

        ChangeScene();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scn_RTBG_Icons", LoadSceneMode.Single);
    }

    IEnumerator WaitForDoubleCheck()
    {
        yield return new WaitForSeconds(30);

        if(madaPosition.activeInHierarchy)
            MadaDoubleCheck();

        if (artPosition.activeInHierarchy)
            ArtDoubleCheck();

        if (designPosition.activeInHierarchy)
            DesignDoubleCheck();
    }

    void MadaDoubleCheck()
    {
        if(cubeNumbers == 4)
        {
            SceneManager.LoadScene("Scn_RTBG_2DBubble", LoadSceneMode.Single);
        }
        else
        {
            foreach(Transform item in gameObject.transform)
            {
                if (item.gameObject.GetComponent<FindMadaWordPosition>())
                {
                    Destroy(item.gameObject.GetComponent<FindMadaWordPosition>());
                    item.gameObject.AddComponent<FloatingTwo>();
                    SceneManager.LoadScene("SpellingGame", LoadSceneMode.Single);
                }
            }
            
        }
    }

    void ArtDoubleCheck()
    {
        if(cubeNumbers == 3)
        {
            SceneManager.LoadScene("Scn_RTBG_2DBubble", LoadSceneMode.Single);
        }
        else
        {
            foreach (Transform item in gameObject.transform)
            {
                if (item.gameObject.GetComponent<FindArtWordPosition>())
                {
                    Destroy(item.gameObject.GetComponent<FindArtWordPosition>());
                    item.gameObject.AddComponent<FloatingTwo>();
                    SceneManager.LoadScene("SpellingGame", LoadSceneMode.Single);
                }
            }
        }
    }

    void DesignDoubleCheck()
    {
        if(cubeNumbers == 6)
        {
            SceneManager.LoadScene("Scn_RTBG_2DBubble", LoadSceneMode.Single);
        }
        else
        {
            foreach (Transform item in gameObject.transform)
            {
                if (item.gameObject.GetComponent<FindDesignWordPosition>())
                {
                    Destroy(item.gameObject.GetComponent<FindDesignWordPosition>());
                    item.gameObject.AddComponent<FloatingTwo>();
                    SceneManager.LoadScene("SpellingGame", LoadSceneMode.Single);
                }
            }
        }
    }
}
