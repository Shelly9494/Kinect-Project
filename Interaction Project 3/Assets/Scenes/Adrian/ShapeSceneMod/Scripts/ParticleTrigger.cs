using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    //Public variables
    public GameObject FireworksAll;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {

            Explode();
        }
    }
    void Explode()
    {
        //GameObject firework = Instantiate(FireworksAll, position, Quaternion.identity);
        //firework.GetComponent<ParticleSystem>().Play();
    }
}
