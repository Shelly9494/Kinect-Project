using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTwo : MonoBehaviour {

    float radian;
    float perRadian = 0.03f;
    //float rangeFolat = 3f;
    float radius = 0.8f;
    Vector3 oldPos;

    bool setArtPosition;
    bool setMadaPosition;
    int randomNum = 0;

    GameObject mainPosition;
    GameObject madaPosition;
    GameObject artPosition;
    GameObject designPosition;

	// Use this for initialization
	void Start () {

        oldPos = transform.position;

        radian = Random.Range(0, 10f);

        mainPosition = GameObject.Find("Position");

        madaPosition = mainPosition.transform.Find("MadaPosition").gameObject;
        artPosition = mainPosition.transform.Find("ArtPosition").gameObject;
        designPosition = mainPosition.transform.Find("DesignPosition").gameObject;
    }

    // Update is called once per frame
    void Update () {

        radian += perRadian;
        float dy = Mathf.Cos(radian);
        transform.position = oldPos + new Vector3(0, dy, 0);

        if (madaPosition.activeInHierarchy || artPosition.activeInHierarchy || designPosition.activeInHierarchy)
            randomNum = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            if ((this.name == "ACube_One" || this.name == "ACube_Two") && randomNum == 0)
            {

                if (GameObject.FindGameObjectWithTag("Position") == true)
                    GameObject.FindGameObjectWithTag("Position").SetActive(false);

                int aWordNum = Random.Range(0, 2);

                if (aWordNum == 0)
                {
                    madaPosition.SetActive(true);
                }

                if (aWordNum == 1)
                {
                    artPosition.SetActive(true);
                }
            }

            if (this.name == "DCube" && randomNum == 0)
            {
                if (GameObject.FindGameObjectWithTag("Position") == true)
                    GameObject.FindGameObjectWithTag("Position").SetActive(false);

                int dWordNum = Random.Range(0, 2);

                if (dWordNum == 0)
                {
                    madaPosition.SetActive(true);
                }

                if (dWordNum == 1)
                {
                    designPosition.SetActive(true);
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

            if ((this.name == "ECube" || this.name == "SCube" || this.name == "ICube" || this.name == "GCube" || this.name == "NCube") && randomNum == 0)
            {
                designPosition.SetActive(true);
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

            if (GetComponent<FloatingTwo>() && designPosition.activeInHierarchy == true)
            {
                Destroy(GetComponent<FloatingTwo>());
                gameObject.AddComponent<FindDesignWordPosition>();
            }
        }
    }
}
