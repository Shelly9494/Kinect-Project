using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] storeBubbles;
    public Vector3 bubbleValue;
    public float bubbleWait;
    public float bubbleMostWait;
    public float bubbleLeastWait;
    public int startWait;

    int randBubble;
	// Use this for initialization
	void Start () {
        StartCoroutine(waitBubble());
	}
	
	// Update is called once per frame
	void Update () {
        bubbleWait = Random.Range(bubbleLeastWait, bubbleMostWait);
	}

    IEnumerator waitBubble()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            randBubble = Random.Range(0, 2);

            Vector3 bubblePosition = new Vector3(Random.Range(-bubbleValue.x, bubbleValue.x), -1, 0);
            Instantiate(storeBubbles[randBubble], bubblePosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(bubbleWait);
        }
    }
}
