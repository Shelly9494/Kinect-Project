using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconAnimationController : MonoBehaviour {

    public Animator anim;
    public GameObject canvas;
    bool addCollider;

	// Use this for initialization
	void Start () {
        addCollider = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (addCollider == false && canvas != null)
        {
            canvas.SetActive(true);
            anim.SetBool("isUserInScene", true);
        }
	}

    public void SetCanvasToF()
    {
        canvas.SetActive(false);
        addCollider = true;    

        Debug.Log("add collider");
        
    }
}
