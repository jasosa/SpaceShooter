using Assets.Scripts.Entities;
using UnityEngine;

public class PositionByBoundaryController : MonoBehaviour {

    public Boundary boundary;
	
	// Update is called once per frame
	void FixedUpdate () {
        setPosition(GetComponent<Rigidbody>());
    }

    private void setPosition(Rigidbody rigidbody)
    {
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax)
            , 0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax));
    }
}
