using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float tiledSizeZ;

    private Vector3 startPosition;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tiledSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
