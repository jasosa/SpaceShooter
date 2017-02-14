using System;
using Assets.Scripts.Helpers;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var rigidbody = GetComponent<Rigidbody>();

        setVelocity(moveHorizontal, moveVertical, rigidbody);
        setPosition(rigidbody);
        setRotation(rigidbody);
    }

    private void setRotation(Rigidbody rigidbody)
    {
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }

    private void setPosition(Rigidbody rigidbody)
    {
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax)
            , 0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax));
    }

    private void setVelocity(float moveHorizontal, float moveVertical, Rigidbody rigidbody)
    {
        rigidbody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
    }
}
