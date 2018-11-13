using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{

    public Animator anim;
    public GameObject canvas;
    GameObject[] hands;

    bool addCollider;

	// Use this for initialization
	void Start ()
    {
        addCollider = false;
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "PreHand")
        {
            canvas.SetActive(true);
            anim.SetBool("isUserInScene", true);
            
            Invoke("AddCollider", 11f);
        }
    }

    void AddCollider()
    {
        if (GameObject.FindGameObjectWithTag("Hand") == null)
        {
            hands = GameObject.FindGameObjectsWithTag("PreHand");
            foreach (GameObject item in hands)
            {
                if (item.tag == "PreHand" && item != null)
                {
                    item.tag = "Hand";

                    Debug.Log("add collider");
                }
            }
        }
    }
}
