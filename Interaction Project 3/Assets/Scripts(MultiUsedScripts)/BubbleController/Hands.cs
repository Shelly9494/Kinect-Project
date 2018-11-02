using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

    public Transform mHandMesh;

    //public AudioSource clickAudio;
	
	// Update is called once per frame
	public void Update () {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
  
	}

    public void Start()
    {
        //clickAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Bubble"))
            return;

        //clickAudio.Play();

        //for making the bubble disapper
        //collision.gameObject.SetActive(false);
        Destroy(GameObject.FindWithTag("Bubble"));
    }
}
