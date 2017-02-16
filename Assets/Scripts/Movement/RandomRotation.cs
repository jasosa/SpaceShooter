using UnityEngine;

public class RandomRotation : MonoBehaviour {

    public float tumble;

    private void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
