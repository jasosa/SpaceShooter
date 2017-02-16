using UnityEngine;
using UnityEngine.Events;

public class  ItemDestructionByContact : MonoBehaviour
{
	[SerializeField]
	public UnityEvent onItemDestruction;

	public ItemDestructionByContact()
	{
		onItemDestruction = new UnityEvent ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Boundary")
		{   
			Destroy(gameObject);

			if (other.tag == "Bolt") {
				onItemDestruction.Invoke ();
				//ScoreFactory.GetScore().AddScore();
			}
		}
	}
}