using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour {

    public AnimationCurve curve;
    public Vector3 distance;
    public float speed;

    public Vector3 startPos, toPos;
    private float timeStart;

    void randomToPos()
    {
        toPos = startPos;
        toPos.x += 1 * distance.x;
        toPos.y += 1 * distance.y;
        toPos.z += -1 * distance.z;
        timeStart = Time.time;
    }

    //Animator anim;

	// Use this for initialization
	void Start () {

        startPos = transform.position;
        randomToPos();

        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float d = (Time.time - timeStart) / speed, m = curve.Evaluate(d);
        if (d > 1)
        {
            randomToPos();
        } else if (d < 0.5)
        {
            transform.position = Vector3.Lerp(startPos, toPos, m * 2.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(toPos, startPos, (m - 0.5f) * 2.0f);
        }
		
	}
}
