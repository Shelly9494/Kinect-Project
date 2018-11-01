using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    private Vector3 mMovementDirection = Vector3.zero;
    private Coroutine mCurrentChanger = null;


    private void OnEnable()
    {
        mCurrentChanger = StartCoroutine(DirectionChanger());
    }
//
    private void OnDisable()
    {
        StopCoroutine(mCurrentChanger);
    }

   
    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }

    private void Update()
    {
        transform.position += mMovementDirection * Time.deltaTime * 0.5f;

        transform.Rotate(0, 0, Time.deltaTime * 20, Space.World);
    }


    private IEnumerator DirectionChanger()
    {
        while (gameObject.activeSelf)
        {
            mMovementDirection = new Vector2(Random.Range(0, 100) * 0.01f, Random.Range(0, 100) * 0.01f);
            yield return new WaitForSeconds(5.0f);
        }
       
    }
}
