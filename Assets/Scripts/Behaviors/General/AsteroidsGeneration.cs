using Assets.Scripts.Entities;
using Assets.Scripts.UnityEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidsGeneration : MonoBehaviour {

    private bool continueGenerating = true;

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
        
	[SerializeField]
	public AsteroidDestructionEvent onAsteroidKilled = new AsteroidDestructionEvent();

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (continueGenerating)
        {
            var hazard = hazards[Random.Range(0, hazards.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            var myHazard = Instantiate(hazard, spawnPosition, spawnRotation);
			var enemyScript = myHazard.GetComponent("ItemDestructionByContact") as ItemDestructionByContact;
			enemyScript.onItemDestruction.AddListener (new UnityAction<string>(ThrowAsteroidKilledEvent));
            yield return new WaitForSeconds(spawnWait);
        }
    }

	private void ThrowAsteroidKilledEvent(string asteroidType)
	{
		Debug.Log ("Asteroid killed");
		onAsteroidKilled.Invoke (asteroidType);
	}

    public void StopsGeneration()
    {
        continueGenerating = false;
    }
}
