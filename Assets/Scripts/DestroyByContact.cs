using Assets.Scripts.MessageBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {   
            Destroy(gameObject);

            if (other.tag == "Bolt")
            {
				MessageBus.Instance.SendMessage (new EnemyDestroyedMessage ());
            }         
        }
    }
}
