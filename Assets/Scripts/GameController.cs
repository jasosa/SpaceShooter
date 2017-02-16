using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private bool gameOver = false;
    public GameObject hazard;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;

    public GUIText scoreText;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        UpdateScore();
    }    

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            var myHazard = Instantiate(hazard, spawnPosition, spawnRotation);
			var enemyScript = myHazard.GetComponent("EnemyDestroyByContact") as EnemyDestroyByContact;
			enemyScript.onEnemyDestroyed.AddListener (new UnityEngine.Events.UnityAction(AddScore));
            yield return new WaitForSeconds(spawnWait);
        }
    }

	private void AddScore()
	{
		ScoreFactory.GetScore ().AddScore ();
	}

	public void GameEnds()
	{
		gameOver = true;
	}

    void UpdateScore()
    {
		if (gameOver) {
			scoreText.text = "Game Over";
		} else {
			scoreText.text = "Score: " + ScoreFactory.GetScore ().GetPoints ();
		}
    }
}
