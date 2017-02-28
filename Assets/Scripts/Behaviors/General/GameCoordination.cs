using Assets.Scripts.PlainEntities;
using Assets.Scripts.PlainEntities.Dispatcher;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameCoordination : MonoBehaviour {

    private bool gameOver = false;    

    public UnityEvent onBombActivated;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText bombText;
    public GameObject bombStatus;

    public GameCoordination()
    {
        //Debug.Log("Game coordination instantiated");               
    }

    [Inject]
    public IDispatcher Dispatcher {get;set;}

    [Inject]
    public IBombLevel BombLevel { get; set; }

    [Inject]
    public IScoreUpdater ScoreUpdater { get; set; }    

    public void GameEnds()
    {
        Debug.Log("Game ends");
        gameOver = true;
        gameOverText.text = "Game Over!";
        restartText.text = "Press 'R' for restart";        
    }

    public void AddScore(string enemyType)
    {
        ScoreUpdater.AddScore(DestroyedEnemiesInfoList.GetInfo(enemyType).Points);        
    }

    public void DeactivateBomb()
    {
        BombLevel.DeactivateBomb();
        bombStatus.SetActive(false);
    }

    void Start()
	{
        gameOver = false;
        restartText.text = string.Empty;
        gameOverText.text = string.Empty;
        ScoreUpdater.Reset();
        BombLevel.onBombActivated += BombLevel_onBombActivated;
    }	

	void Update()
	{
        if (gameOver)
        {
            CheckRestart();
        }        
        else
        {
            UpdateScoreText();
            UpdateBombText();
            Dispatcher.InvokeAll();
        }       
    }    

    private void CheckRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateBombText()
    {       
        bombText.text = String.Format("{0}%", BombLevel.BombLevel); 
    }   

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreUpdater.GetScore();
    }

    private void BombLevel_onBombActivated(object sender, EventArgs e)
    {
        Dispatcher.Enqueue(() => bombStatus.SetActive(true));
        Dispatcher.Enqueue(() => onBombActivated.Invoke());
    }
}

