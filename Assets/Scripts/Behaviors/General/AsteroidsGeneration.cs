using Assets.Scripts.UnityEvents;
using System.Collections;
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
            // Generate hazard
            var hazard = hazards[Random.Range(0, hazards.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            var myHazard = Instantiate(hazard, spawnPosition, spawnRotation);

            switch (hazard.tag)
            {
                case "asteroid01":
                case "asteroid02":
                case "asteroid03":
                    var asteroidScript = myHazard.GetComponent("AsteroidDestructionByContact") as AsteroidDestructionByContact;
                    asteroidScript.onItemDestruction.AddListener(new UnityAction<string>(ThrowAsteroidKilledEvent));
                    break;
                case "EnemyShip":
                    var enemyScript = myHazard.GetComponent("EnemyDestructionByContact") as EnemyDestructionByContact;
                    enemyScript.onEnemyDestruction.AddListener(new UnityAction<string>(ThrowAsteroidKilledEvent));
                    break;
            }
           
            
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private void ThrowAsteroidKilledEvent(string asteroidType)
    {
        Debug.Log("Enemy killed: " + asteroidType);
        onAsteroidKilled.Invoke(asteroidType);
    }

    public void StopsGeneration()
    {
        continueGenerating = false;
    }
}
