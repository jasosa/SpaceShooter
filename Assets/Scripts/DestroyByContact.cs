using Assets.Scripts.Entities;
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
                ScoreFactory.GetScore().AddScore();
            }         
        }
    }
}