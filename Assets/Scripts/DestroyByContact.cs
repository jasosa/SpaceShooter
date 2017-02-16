using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyByContact : MonoBehaviour
{
	[SerializeField]
	public UnityEvent onPlayerDestroyed;

	public DestroyByContact()
	{
		onPlayerDestroyed = new UnityEvent ();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {   
			Debug.Log ("Destroyed object");
            Destroy(gameObject);
			onPlayerDestroyed.Invoke ();
        }
    }
}