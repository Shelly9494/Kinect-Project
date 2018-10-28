using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLines : MonoBehaviour {

    public GameObject linePrefab;
    private Material lineMaterial;
    public GameObject hands;

    LineGame activeLine;
    

	// Update is called once per frame
	void Update () {
        if (hands.activeInHierarchy)
        {
            GameObject lineGo = Instantiate(linePrefab);
            activeLine = lineGo.GetComponent<LineGame>();
            
        }

        if (!hands.activeInHierarchy)
        {
            activeLine = null;
            StartCoroutine(WaitForDoubleCheck());
            Debug.Log("double check");
        }


        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
            Debug.Log("Draw Line");
        }
	}

    void Release()
    {
        GameObject[] completedLine = GameObject.FindGameObjectsWithTag("Brush");

        foreach (GameObject item in completedLine)
        {
            item.AddComponent<GeneralDisappear>();
            Destroy(item, 10);
        } 
    }

    IEnumerator WaitForDoubleCheck()
    {
       
        yield return new WaitForSeconds(10);
        
        DoubleCheck();

        Debug.Log("Wait");
    }

    void DoubleCheck()
    {
        if (activeLine == null)
        {
            Release();
            Debug.Log("Call function");
        }
    }
}
