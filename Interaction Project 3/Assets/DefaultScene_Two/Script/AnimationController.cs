using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{

    public Animator anim;
    public GameObject canvas;
    public GameObject hand;
    bool addCollider;

	// Use this for initialization
	void Start ()
    {
        addCollider = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (hand.activeInHierarchy && addCollider == false)
        {
            canvas.SetActive(true);
            anim.SetBool("isUserInScene", true);
            Destroy(hand.GetComponent<BoxCollider>());
            Invoke("AddCollider", 10f);
            addCollider = true;
        }
	}

    void AddCollider()
    {
        if (hand.GetComponent<BoxCollider>() == false && addCollider == true)
        {
            hand.AddComponent<BoxCollider>();
            
            Debug.Log("add collider");
        }
    }
}
