using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour {

    public Animator anim;
    public GameObject hand;
    public GameObject canvas;

	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator>();
        //hand = GameObject.FindGameObjectWithTag("Hand");
        //Debug.Log(hand);
        //canvas = GameObject.Find("GuideCanvas");
	}
	
	// Update is called once per frame
	void Update () {

        if (hand.activeInHierarchy == true)
        {
            Debug.Log("true");
            anim.SetBool("isUserInScene", true);
            canvas.SetActive(true);
        }

	}
}
