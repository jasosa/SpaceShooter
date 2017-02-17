using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormwardRandomSpeedMover : MonoBehaviour {

    public float maxSpeed;
    public float minSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(minSpeed, maxSpeed);
    }   
}
