using UnityEngine;
using UnityEngine.Events;

public class  ItemDestroyedByContact : MonoBehaviour
{
	[SerializeField]
	public UnityEvent onItemDestroyed;

	public ItemDestroyedByContact()
	{
		onItemDestroyed = new UnityEvent ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Boundary")
		{   
			Destroy(gameObject);

			if (other.tag == "Bolt") {
				onItemDestroyed.Invoke ();
				//ScoreFactory.GetScore().AddScore();
			}
		}
	}
}