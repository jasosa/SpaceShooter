﻿using Assets.Scripts.UnityEvents;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidDestructionByContact : MonoBehaviour
{
    [SerializeField]
    public AsteroidDestructionEvent onItemDestruction;

    public AsteroidDestructionByContact()
    {
        onItemDestruction = new AsteroidDestructionEvent();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Destroy(gameObject);

            if (other.tag == "Bolt")
            {
                onItemDestruction.Invoke(gameObject.tag);
            }
        }
    }
}