using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnCollision : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
