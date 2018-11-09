using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMadaWordPosition : MonoBehaviour {

    GameObject target;

    float speed = 2f;

    GameObject checkCubes;

	// Use this for initialization
	void Start () {

        checkCubes = GameObject.Find("CheckCubes");

        Debug.Log(this.name);

        if (this.name == "MCube")
        {
            target = GameObject.Find("Mada_M_Pos");
            this.transform.parent = checkCubes.transform;
            Debug.Log(target);
        }
        else if (this.name == "DCube")
        {
            target = GameObject.Find("Mada_D_Pos");
            this.transform.parent = checkCubes.transform;
            Debug.Log(target);
        }
        else if (this.name == "ACube_One")
        {
            target = GameObject.Find("Mada_AOne_Pos");
            this.transform.parent = checkCubes.transform;
            Debug.Log(target);
        }
        else if (this.name == "ACube_Two")
        {
            target = GameObject.Find("Mada_ATwo_Pos");
            this.transform.parent = checkCubes.transform;
            Debug.Log(target);
        }
        else
        {
            if (GetComponent<FindMadaWordPosition>())
            {
                Destroy(GetComponent<FindMadaWordPosition>());
                gameObject.AddComponent<FloatingTwo>();
            }

            if (GetComponent<FindArtWordPosition>())
            {
                Destroy(GetComponent<FindArtWordPosition>());
                gameObject.AddComponent<FloatingTwo>();
            }

            if (GetComponent<FindDesignWordPosition>())
            {
                Destroy(GetComponent<FindDesignWordPosition>());
                gameObject.AddComponent<FloatingTwo>();
            }

        }

    }
	
	// Update is called once per frame
	void Update () {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        
    }
}
