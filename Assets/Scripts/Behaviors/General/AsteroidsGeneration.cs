using Assets.Scripts.UnityEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidsGeneration : MonoBehaviour {
    private const string CURRENTLEVEL = "1";
    private bool continueGenerating = true;

    public GameObject[] levelOneHazards;
    public GameObject[] levelTwoHazards;
    public GameObject[] finalLevelHazards;

    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
        
	[SerializeField]
	public AsteroidDestructionEvent onAsteroidKilled = new AsteroidDestructionEvent();

    private Dictionary<string, GameObject[]> allLevelsHazard;

    public AsteroidsGeneration()
    {        
    }

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (continueGenerating)
        {
            for (int i = 0; i < 10; i++)
            {
                var hazard = levelOneHazards[Random.Range(0, levelOneHazards.Length)];
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

                yield return new WaitForSeconds(startWait);
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
