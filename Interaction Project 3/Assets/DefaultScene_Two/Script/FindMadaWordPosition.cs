using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMadaWordPosition : MonoBehaviour {

    GameObject target;

    float speed = 2f;

	// Use this for initialization
	void Start () {

        Debug.Log(this.name);

        if (this.name == "MCube")
        {
            target = GameObject.Find("Mada_M_Pos");
            Debug.Log(target);
        }
        else if (this.name == "DCube")
        {
            target = GameObject.Find("Mada_D_Pos");
            Debug.Log(target);
        }
        else if (this.name == "ACube_One")
        {
            target = GameObject.Find("Mada_AOne_Pos");
            Debug.Log(target);
        }
        else if (this.name == "ACube_Two")
        {
            target = GameObject.Find("Mada_ATwo_Pos");
            Debug.Log(target);
        }
        else
        {
            Destroy(GetComponent<FindMadaWordPosition>());
            gameObject.AddComponent<FloatingTwo>();
        }


    }
	
	// Update is called once per frame
	void Update () {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
