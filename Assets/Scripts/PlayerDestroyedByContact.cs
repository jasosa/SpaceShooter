using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDestroyedByContact : MonoBehaviour
{
	[SerializeField]
	public UnityEvent onPlayerDestroyed;

	public PlayerDestroyedByContact()
	{
		onPlayerDestroyed = new UnityEvent ();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {   
            Destroy(gameObject);
			onPlayerDestroyed.Invoke ();
		}
    }
}