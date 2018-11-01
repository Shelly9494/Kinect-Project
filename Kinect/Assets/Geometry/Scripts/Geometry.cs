using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry : MonoBehaviour {

    float fallSpeed = 2;
    float rotateSpeed = 30;

    Rigidbody rb;

    float pieceSize = 0.1f;
    int pieceInRow = 5;

    float piecePivotDistance;
    Vector3 piecePivot;

    float explosionRadius = 4f;
    float explosionForce = 30f;
    float explosionUpward = 0.4f;
    GameObject[] geoObjects;
    int geoLength;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;

        piecePivotDistance = pieceSize * pieceInRow / 2;
        piecePivot = new Vector3(piecePivotDistance, piecePivotDistance, piecePivotDistance);
    }

    // Update is called once per frame
    void Update () {

        CountObjects();


    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0.1f, 1, 0.1f));
        rb.AddForce(new Vector3(), ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane")){
            Explode();
        }
    }

    void CountObjects()
    {
        geoObjects = GameObject.FindGameObjectsWithTag("cube");
        geoLength = GameObject.FindGameObjectsWithTag("cube").Length;
        if (geoLength > 15)
        {
            Destroy(geoObjects[geoLength-(geoLength-2)]);
        }
    }

    void Explode()
    {
        Destroy(gameObject);
        
        for(int x = 0; x < pieceInRow; x++)
        {
            for(int y = 0; y < pieceInRow; y++)
            {
                for(int z = 0; z < pieceInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody pieceRB = hit.GetComponent<Rigidbody>();
            if (pieceRB != null)
            {
                pieceRB.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(pieceSize * x, pieceSize * y, pieceSize * z) - piecePivot;
        piece.transform.localScale = new Vector3(pieceSize, pieceSize, pieceSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = pieceSize;

    }

}
