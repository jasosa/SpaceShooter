using Assets.Scripts.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.PlainEntities;
using System;
using UnityEngine.Events;

public class GameCoordination : MonoBehaviour {

	private bool gameOver = false;    
    private BombLevelController bombLevel = new BombLevelController();

    public UnityEvent onBombActivated;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText bombText;

    public GameCoordination()
    {
        bombLevel.onBombActivated += BombLevel_onBombActivated;   
    }   

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

        if (ScoreFactory.GetScore().GetPoints() > 500)
        {

        }
	}

    public void DeactivateBomb()
    {
        bombLevel.DeactivateBomb();
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
            UpdateBombText();
        }
	}

    private void UpdateBombText()
    {       
        bombText.text = String.Format("Bomb level: {0}%", bombLevel.BombLevel); 
    }

    private void CheckRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void BombLevel_onBombActivated(object sender, EventArgs e)
    {
       Action a = new Action(() => onBombActivated.Invoke());
       a.Invoke();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreFactory.GetScore().GetPoints();
    }
}

