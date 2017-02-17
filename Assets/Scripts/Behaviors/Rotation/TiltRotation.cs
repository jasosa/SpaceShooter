using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltRotation : MonoBehaviour {

    public float tilt;

    void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}