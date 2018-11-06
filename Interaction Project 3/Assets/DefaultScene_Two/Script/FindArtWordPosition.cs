using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindArtWordPosition : MonoBehaviour {

    GameObject target;

    float speed = 2f;

    // Use this for initialization
    void Start () {

        Debug.Log(this.name);

        if (this.name == "RCube")
        {
            target = GameObject.Find("Art_R_Pos");
            Debug.Log(target);
        }
        else if (this.name == "TCube")
        {
            target = GameObject.Find("Art_T_Pos");
            Debug.Log(target);
        }
        else if (this.name == "ACube_One")
        {
            target = GameObject.Find("Art_A_Pos");
            Debug.Log(target);
        }
        else if (this.name == "ACube_Two")
        {
            target = GameObject.Find("Art_A_Pos");
            Debug.Log(target);
        }
        else
        {
            Destroy(GetComponent<FindArtWordPosition>());
            gameObject.AddComponent<FloatingTwo>();
        }


    }

    // Update is called once per frame
    void Update () {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
