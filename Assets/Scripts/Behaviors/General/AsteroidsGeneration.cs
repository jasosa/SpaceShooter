using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidsGeneration : MonoBehaviour {

    private bool continueGenerating = true;

    public GameObject hazard;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
        
	[SerializeField]
	public UnityEvent onAsteroidKilled = new UnityEvent();

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (continueGenerating)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            var myHazard = Instantiate(hazard, spawnPosition, spawnRotation);
			var enemyScript = myHazard.GetComponent("ItemDestructionByContact") as ItemDestructionByContact;
			enemyScript.onItemDestruction.AddListener (new UnityAction(ThrowAsteroidKilledEvent));
            yield return new WaitForSeconds(spawnWait);
        }
    }

	private void ThrowAsteroidKilledEvent()
	{
		Debug.Log ("Asteroid killed");
		onAsteroidKilled.Invoke ();
	}

    public void StopsGeneration()
    {
        continueGenerating = false;
    }
}
