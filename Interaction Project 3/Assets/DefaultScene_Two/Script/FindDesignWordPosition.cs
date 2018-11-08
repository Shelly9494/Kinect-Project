using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDesignWordPosition : MonoBehaviour {

    GameObject target;

    float speed = 2f;

    GameObject checkCubes;

    // Use this for initialization
    void Start () {

        checkCubes = GameObject.Find("CheckCubes");

        if (this.name == "DCube")
        {
            target = GameObject.Find("Design_D_Pos");
            this.transform.parent = checkCubes.transform;
        }

        else if (this.name == "ECube")
        {
            target = GameObject.Find("Design_E_Pos");
            this.transform.parent = checkCubes.transform;
        }

        else if (this.name == "SCube")
        {
            target = GameObject.Find("Design_S_Pos");
            this.transform.parent = checkCubes.transform;
        }

        else if (this.name == "ICube")
        {
            target = GameObject.Find("Design_I_Pos");
            this.transform.parent = checkCubes.transform;
        }

        else if (this.name == "GCube")
        {
            target = GameObject.Find("Design_G_Pos");
            this.transform.parent = checkCubes.transform;
        }

        else if (this.name == "NCube")
        {
            target = GameObject.Find("Design_N_Pos");
            this.transform.parent = checkCubes.transform;
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
