using Assets.Scripts.UnityEvents;
using UnityEngine;

public class EnemyDestructionByContact : MonoBehaviour {

    [SerializeField]
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
            onEnemyDestruction.Invoke(gameObject.tag);
        }
    }

    private static bool killedByBolt(Collider other)
    {
        return other.tag == "Bolt";
    }
}
