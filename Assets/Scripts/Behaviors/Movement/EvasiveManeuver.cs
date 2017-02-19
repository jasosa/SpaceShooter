using System.Collections;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    [SerializeField]
    private float dodge;
    [SerializeField]
    private float smoothing;
    [SerializeField]
    private Vector2 startWait;
    [SerializeField]
    private Vector2 maneuverTime;
    [SerializeField]
    private Vector2 maneuverWait;

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rb;    
	
	void Start () {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            // to avoid the ship go away the screen
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
	
	// Update is called once per frame
	void Update () {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);        
	}
}
