using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTwo : MonoBehaviour {

    float radian = 0;
    float perRadian = 0.03f;
    //float rangeFolat = 3f;
    float radius = 0.8f;
    Vector3 oldPos;

    bool setArtPosition;
    bool setMadaPosition;
    int randomNum = 0;


    public GameObject madaPosition;
    public GameObject artPosition;
    public GameObject designPosition;

	// Use this for initialization
	void Start () {
        oldPos = transform.position;

        setMadaPosition = true;
        setArtPosition = true;
	}
	
	// Update is called once per frame
	void Update () {
        radian += perRadian;
        float dy = Mathf.Cos(radian);
        transform.position = oldPos + new Vector3(0, dy, 0);

        if (madaPosition.activeInHierarchy == true || artPosition.activeInHierarchy == true)
            randomNum = 1;

        Debug.Log(randomNum);
    }

    private void OnTriggerEnter(Collider other)
    {
        if((this.name == "ACube_One" || this.name == "ACube_Two") && randomNum == 0)
        {
           
            if (GameObject.FindGameObjectWithTag("Position") == true)
            GameObject.FindGameObjectWithTag("Position").SetActive(false);

            int wordNum = Random.Range(0, 2);
            Debug.Log(wordNum);

            if(wordNum == 0)
            {
                madaPosition.SetActive(true);
            }

            if (wordNum == 1)
            {
                artPosition.SetActive(true);
            }

        }

        if ((this.name == "RCube" || this.name == "TCube") && randomNum == 0)
        {
            artPosition.SetActive(true);

        }

        if ((this.name == "MCube" || this.name == "DCube") && randomNum == 0)
        {
            madaPosition.SetActive(true);

        }

        if (GetComponent<FloatingTwo>() && madaPosition.activeInHierarchy == true)
        {
            Destroy(GetComponent<FloatingTwo>());
            gameObject.AddComponent<FindMadaWordPosition>();
        }

        if (GetComponent<FloatingTwo>() && artPosition.activeInHierarchy == true)
        {
            Destroy(GetComponent<FloatingTwo>());
            gameObject.AddComponent<FindArtWordPosition>();
        }

    }


    void SetIfRandomTrue()
    {
        
    }

    void SetIfRandomFalse()
    {
       
    }
}
