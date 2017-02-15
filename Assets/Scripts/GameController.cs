using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

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
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + ScoreFactory.GetScore().GetPoints();
    }
}
