using Assets.Scripts.UnityEvents;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidDestructionByContact : MonoBehaviour
{
    //non serializable. Event for asteroid prefabs
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
            Destroy(other.gameObject);

            if (other.tag == "Bolt")
            {
                onItemDestruction.Invoke(gameObject.tag);
            }
        }
    }
}