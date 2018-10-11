using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

    public Transform mHandMesh;
	
	// Update is called once per frame
	public void Update () {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
  
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bubble"))
            return;

        //for making the bubble disapper
        //collision.gameObject.SetActive(false);
        Destroy(GameObject.FindWithTag("Bubble"));
    }
}
