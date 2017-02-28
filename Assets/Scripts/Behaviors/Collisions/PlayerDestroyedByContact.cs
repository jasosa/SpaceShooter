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
        if (other.tag == "Boundary" || other.tag == "Bolt" || other.tag == "Bomb")
        {
            return;
        }

        Destroy(gameObject);
        onPlayerDestroyed.Invoke();
    }
}