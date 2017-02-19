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

        if (killedByBolt(other))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            onEnemyDestruction.Invoke(gameObject.tag);
        }
    }

    private static bool killedByBolt(Collider other)
    {
        return other.tag == "Bolt";
    }
}
