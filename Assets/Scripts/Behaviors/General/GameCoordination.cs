using Assets.Scripts.Entities;
using UnityEngine;

public class GameCoordination : MonoBehaviour {

	private bool gameOver = false;
    private bool restart = false;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    void Start()
	{
        restartText.text = string.Empty;
        gameOverText.text = string.Empty;        
    }

	public void GameEnds()
	{
        Debug.Log("Game ends");
		gameOver = true;
        restart = true;
        gameOverText.text = "Game Over!";
        restartText.text = "Press 'R' for restart";        
    }

	public void AddScore(){
		Debug.Log ("Score added");
		ScoreFactory.GetScore ().AddScore ();
	}

	private void Update()
	{
		UpdateScoreText();
	}

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreFactory.GetScore().GetPoints();
    }
}

