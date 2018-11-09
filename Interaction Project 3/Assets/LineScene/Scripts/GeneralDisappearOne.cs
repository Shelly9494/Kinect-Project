using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralDisappearOne : MonoBehaviour
{

    float tempTime;
    void Start()
    {
        tempTime = 0;

        //RGB
        this.GetComponent<Image>().color = new Color(
        this.GetComponent<Image>().color.r,
        this.GetComponent<Image>().color.g,
        this.GetComponent<Image>().color.b,
        //Alpha
        this.GetComponent<Image>().color.a);

    }
    void Update()
    {
        if (tempTime < 1)
        {
            tempTime = tempTime + Time.deltaTime * 10f;
        }
        if (this.GetComponent<Image>().color.a >= 0)
        {
            this.GetComponent<Image>().color = new Color(
            this.GetComponent<Image>().color.r,
            this.GetComponent<Image>().color.g,
            this.GetComponent<Image>().color.b,
            
            //Alpha
            this.GetComponent<Image>().color.a - tempTime/50);

            //Debug.Log("Disappear" + this.GetComponent<Image>().color.a);
        }


    }
}
