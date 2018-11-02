using UnityEngine;


public class DrawLines : MonoBehaviour {

    public GameObject targetObject;
    public GameObject brush;

    private Vector3 lastPoint;
    private GameObject newShapes;

    // Use this for initialization
    void Start ()
    {
        lastPoint = targetObject.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(targetObject.transform.position);

        if (targetObject.activeInHierarchy == true && targetObject.transform.position != lastPoint)
        {
            Instantiate(brush, targetObject.transform.position, Quaternion.identity);
        }

        if (targetObject.activeInHierarchy == false)
        {
            Invoke("StorePath",1);
            
        }

        lastPoint = targetObject.transform.position;
    }

    void StorePath()
    {
        GameObject[] shapes = GameObject.FindGameObjectsWithTag("Brush");

        foreach(GameObject item in shapes)
        {
            if (!item.GetComponent<FloatLetter>())
            {
                item.AddComponent<FloatLetter>();
            }

            Destroy(item, 30);
        }
        

    }
}
