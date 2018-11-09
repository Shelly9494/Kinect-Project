using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralShowOne : MonoBehaviour
{

    float tempTime;
    void Start()
    {
        tempTime = 0;

        this.GetComponent<Image>().color = new Color(
           this.GetComponent<Image>().color.r,
           this.GetComponent<Image>().color.g,
           this.GetComponent<Image>().color.b,
           //需要改的就是这个属性：Alpha值
           this.GetComponent<Image>().color.a);

        //Debug.Log(this.GetComponent<Image>().color);
    }
    void Update()
    {
        if (tempTime < 1)
        {
            tempTime = tempTime + Time.deltaTime * 5f;
        }
        if (this.GetComponent<Image>().color.a <=1)
        {
            this.GetComponent<Image>().color = new Color(
            this.GetComponent<Image>().color.r,
            this.GetComponent<Image>().color.g,
            this.GetComponent<Image>().color.b,
            //需要改的就是这个属性：Alpha值
            this.GetComponent<Image>().color.a + tempTime / 50);

            //Debug.Log("Show" + this.GetComponent<Image>().color.a);
        }
    }
}
