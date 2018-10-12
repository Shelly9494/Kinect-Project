using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        Destroy(other.gameObject, 3);
    }
}
