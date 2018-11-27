using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrushController : MonoBehaviour {

    SceneManagerScript sms;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "DrawArea")
        {
            sms.CancelInvokeFun();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "DrawArea")
        {
            sms.CheckBrushes();
        }
    }
}
