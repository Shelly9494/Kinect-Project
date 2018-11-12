using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectRotator : MonoBehaviour
{
    //Public variables
    public GameObject descriptionCanvas;
    public GameObject imageCube;
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject SwitchSceneCanvas;

    //Private variables
    private bool rotating;
    public bool toggle;

    UIFader fadeDescription;

    public void StartRotation()
    {
        if (!rotating)
        {
            StartCoroutine(RotateDescription(new Vector3(0, -90, 0), 1));
            StartCoroutine(RotateImageCube(new Vector3(0, 90, 0), 1));
        }

        /*if ()
        {
            SwitchSceneCanvas.SetActive(true);
        }
        */
    }

    private IEnumerator RotateDescription(Vector3 angles, float duration)
    {
        //FADER
        foreach (Transform item in Canvas1.transform)
        {
            if (item.GetComponent<GeneralShowOne>())
            {
                Destroy(item.GetComponent<GeneralShowOne>());
                item.gameObject.AddComponent<GeneralDisappearOne>();
            }
            else
            {
                Destroy(item.GetComponent<GeneralDisappearOne>());
                item.gameObject.AddComponent<GeneralShowOne>();
            }

        }

        foreach (Transform item in Canvas2.transform)
        {
            if (item.GetComponent<GeneralDisappearOne>())
            {
                Destroy(item.GetComponent<GeneralDisappearOne>());
                item.gameObject.AddComponent<GeneralShowOne>();
            }
            else
            {
                Destroy(item.GetComponent<GeneralShowOne>());
                item.gameObject.AddComponent<GeneralDisappearOne>();
            }

        }

        //END OF FADER

        //UI ROTATION
        rotating = true;
        toggle = true;
        Quaternion startRotation = descriptionCanvas.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            descriptionCanvas.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        descriptionCanvas.transform.rotation = endRotation;
        
        rotating = false;

        //END OF UI ROTATION
    }

    private IEnumerator RotateImageCube(Vector3 angles, float duration)
    {
        //IMAGECUBE ROTATION

        rotating = true;
        Quaternion startRotation = imageCube.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            imageCube.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        imageCube.transform.rotation = endRotation;
        rotating = false;

        //END OF IMAGECUBE ROTATION
    }
}
