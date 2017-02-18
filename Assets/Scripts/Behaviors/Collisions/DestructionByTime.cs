using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionByTime : MonoBehaviour {

    [SerializeField]
    private int lifetime;
	
	void Start () {
        Destroy(gameObject, lifetime);
	}	
}
