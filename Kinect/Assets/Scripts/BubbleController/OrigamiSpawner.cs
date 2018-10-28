using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiSpawner : MonoBehaviour {

    public GameObject[] storeBubbles;
    public Vector3 bubbleValue;
    public float bubbleWait;
    public float bubbleMostWait;
    public float bubbleLeastWait;
    public int startWait;

    GameObject[] shapeArrary;
    int randBubble;
	// Use this for initialization
	void Start () {
        StartCoroutine(waitBubble());
	}
	
	// Update is called once per frame
	void Update () {
        bubbleWait = Random.Range(bubbleLeastWait, bubbleMostWait);

        shapeArrary = GameObject.FindGameObjectsWithTag("Shape");

        if(shapeArrary.Length > 20)
        {
            Destroy(shapeArrary[shapeArrary.Length - (shapeArrary.Length - 1)]);
        }
	}

    IEnumerator waitBubble()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            randBubble = Random.Range(0, storeBubbles.Length);

            Vector3 bubblePosition = new Vector3(Random.Range(-bubbleValue.x, bubbleValue.x), -1, 0);
            Instantiate(storeBubbles[randBubble], bubblePosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(bubbleWait);
        }
    }
}
