using UnityEngine;
using UnityEngine.Events;

public class EnemyDestroyByContact : MonoBehaviour
{
	[SerializeField]
	public UnityEvent onEnemyDestroyed;

	public EnemyDestroyByContact()
	{
		onEnemyDestroyed = new UnityEvent ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Boundary")
		{   
			Destroy(gameObject);

			if (other.tag == "Bolt") {
				onEnemyDestroyed.Invoke ();
				//ScoreFactory.GetScore().AddScore();
			}
		}
	}
}