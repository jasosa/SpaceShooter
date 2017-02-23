using System;
using Assets.Scripts.UnityEvents;
using UnityEngine;

public class EnemyDestructionByContact : MonoBehaviour {

    //non serializable. Event for asteroid prefabs
    public EnemyDestructionEvent onEnemyDestruction = new EnemyDestructionEvent();

    // Use this for initialization
    void Start () {        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (killedByBolt(other) || killedByBomb(other))
        {
            Destroy(gameObject);            
            onEnemyDestruction.Invoke(gameObject.tag);

            if (killedByBolt(other))
            {
                Destroy(other.gameObject);
            }
        }
    }

    private bool killedByBomb(Collider other)
    {
        return other.tag == "Bomb";
    }

    private static bool killedByBolt(Collider other)
    {
        return other.tag == "Bolt";
    }
}
