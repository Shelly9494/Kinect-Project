using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationTrigger : MonoBehaviour
{
    public ObjectRotator objRotate;
    public Animator anim;
    public GameObject onBoardCanvas;
    public GameObject canvas;
    public GameObject btn;

    IconAnimationController iconAC;

    int count;

    void Start()
    {
        count = 0;
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Hand")
        {
            Destroy(onBoardCanvas);

            objRotate.StartRotation();
            count++;

            if(count == 4)
            {
                canvas.SetActive(true);
                anim.SetBool("showLeaveBtn", true);
                btn.SetActive(true);
            }

            //Debug.Log("Touch");
        }       
    }
}
