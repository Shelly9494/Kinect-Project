using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class UIFader : MonoBehaviour
{
    public CanvasGroup uiElement;

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1)
                break;

            yield return new WaitForEndOfFrame();
        }

        //Debug.Log("Done");
    }

    /*float tempTime;

    void Start()
    {
        tempTime = 0;
                
        this.GetComponent<Renderer>().material.color = new Color(
        this.GetComponent<Renderer>().material.color.r,
        this.GetComponent<Renderer>().material.color.g,
        this.GetComponent<Renderer>().material.color.b,
        
        this.GetComponent<Renderer>().material.color.a);
    }

    public void hideAlpha()
    {
        if (tempTime < 1)
        {
            tempTime = tempTime + Time.deltaTime * 0.1f;
        }

        if (this.GetComponent<Renderer>().material.color.a <= 1)
        {
            this.GetComponent<Renderer>().material.color = new Color(
            this.GetComponent<Renderer>().material.color.r,
            this.GetComponent<Renderer>().material.color.g,
            this.GetComponent<Renderer>().material.color.b,

            gameObject.GetComponent<Renderer>().material.color.a - tempTime / 100);
        }
    }*/
    
}
