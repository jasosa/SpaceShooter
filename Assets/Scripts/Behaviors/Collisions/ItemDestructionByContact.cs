using Assets.Scripts.UnityEvents;
using UnityEngine;
using UnityEngine.Events;

public class  ItemDestructionByContact : MonoBehaviour
{
	[SerializeField]
	public AsteroidDestructionEvent onItemDestruction;

	public ItemDestructionByContact()
	{
		onItemDestruction = new AsteroidDestructionEvent ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Boundary")
		{   
			Destroy(gameObject);

			if (other.tag == "Bolt") {
                onItemDestruction.Invoke(gameObject.tag);
				//ScoreFactory.GetScore().AddScore();
			}
		}
	}
}