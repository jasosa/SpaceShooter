using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
