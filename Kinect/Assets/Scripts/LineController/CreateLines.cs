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

        Vector2 handPos = new Vector2(GameObject.FindGameObjectWithTag("Hand").transform.position.x, GameObject.FindGameObjectWithTag("Hand").transform.position.y);

        if (GameObject.FindGameObjectWithTag("Hand") != null) 
        {
            GameObject lineGo = Instantiate(linePrefab);
            activeLine = lineGo.GetComponent<LineGame>();
            
        }

        if (GameObject.FindGameObjectsWithTag("Hand") == null)
        {
            activeLine = null;
            StartCoroutine(WaitForDoubleCheck());
            Debug.Log("double check");
        }


        if (activeLine != null)
        {
            //Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
            Vector2 mousePos = Camera.main.WorldToScreenPoint(handPos);
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
