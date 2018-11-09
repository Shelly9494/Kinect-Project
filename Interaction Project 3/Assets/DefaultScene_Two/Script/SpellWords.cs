using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWords : MonoBehaviour {

    public GameObject madaWordPosition;
    public GameObject artWordPosition;
    public GameObject designWordPosition;

    int randomA;
    int randomD;

    bool spellMada;

    void Start()
    {
        spellMada = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ACube")
        {
            randomA = Random.Range(0, 2);
            if (randomA == 0)
            {
                madaWordPosition.SetActive(true);
                other.transform.position = madaWordPosition.transform.Find("MadaWordPosition/A").position;
                spellMada = true;
            }
        }
    }
	
	
}
