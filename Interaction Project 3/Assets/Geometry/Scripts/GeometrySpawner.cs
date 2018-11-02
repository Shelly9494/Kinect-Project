using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometrySpawner : MonoBehaviour {

    public GameObject[] storeGeo;
    public Vector3 geometryValue;
    public float geometryWait;
    public float geoMostWait;
    public float geoLeastWait;
    public int startWait;

    int randGeo;
	// Use this for initialization
	void Start () {
        StartCoroutine(waitGeo());
	}
	
	// Update is called once per frame
	void Update () {
        geometryWait = Random.Range(geoLeastWait, geoMostWait);
	}

    IEnumerator waitGeo()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            randGeo = Random.Range(0, 1);

            Vector3 geoPosition = new Vector3(Random.Range(-geometryValue.x, geometryValue.x), 0, 0);
            Instantiate(storeGeo[randGeo], geoPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(geometryWait);
        }
    }
}
