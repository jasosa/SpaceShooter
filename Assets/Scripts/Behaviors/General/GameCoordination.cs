using Assets.Scripts.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.PlainEntities;

public class GameCoordination : MonoBehaviour {

	private bool gameOver = false;    

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    void Start()
	{
        gameOver = false;
        restartText.text = string.Empty;
        gameOverText.text = string.Empty;
        ScoreFactory.GetScore().Reset();
    }

	public void GameEnds()
	{
        Debug.Log("Game ends");
		gameOver = true;             
        gameOverText.text = "Game Over!";
        restartText.text = "Press 'R' for restart";
    }

	public void AddScore(string enemyType){
        Debug.Log("Enemy destryoed: " + enemyType);
        ScoreFactory.GetScore ().AddScore (DestroyedEnemiesInfoList.GetInfo(enemyType).Points);
	}

	private void Update()
	{
        if (gameOver)
        {
            CheckRestart();
        }
        else
        {
            UpdateScoreText();
        }
	}

    private void CheckRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreFactory.GetScore().GetPoints();
    }
}

