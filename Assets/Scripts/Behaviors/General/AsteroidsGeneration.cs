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
	public EnemyDestructionEvent onEnemyKilled = new EnemyDestructionEvent();

    private GameObject[] allLevelsHazard;

    public AsteroidsGeneration()
    {
       
    }

    void Start()
    {
        allLevelsHazard = (GameObject[]) levelOneHazards.Clone();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (continueGenerating)
        {
            for (int i = 0; i < 10; i++)
            {
                var hazard = allLevelsHazard[Random.Range(0, allLevelsHazard.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                var myHazard = Instantiate(hazard, spawnPosition, spawnRotation);
                var enemyScript = myHazard.GetComponent("EnemyDestructionByContact") as EnemyDestructionByContact;
                enemyScript.onEnemyDestruction.AddListener(new UnityAction<string>(ThrowAsteroidKilledEvent));
                yield return new WaitForSeconds(startWait);
            }

            yield return new WaitForSeconds(spawnWait);
        }
    }

    private void ThrowAsteroidKilledEvent(string asteroidType)
    {        
        onEnemyKilled.Invoke(asteroidType);
    }

    public void StopsGeneration()
    {
        continueGenerating = false;
    }

    public void ChangeEnemies()
    {
        continueGenerating = false;
        allLevelsHazard = (GameObject[]) levelTwoHazards.Clone();
        continueGenerating = true;
    }
}
