using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

	private bool gameOver = false;

	public GUIText scoreText;

	void Start()
	{
		//var generator = GetComponent ("AsteroidsGenerator") as AsteroidsGenerator;
		//generator.onAsteroidKilled.AddListener (new UnityEngine.Events.UnityAction (AddScore));
	}

	public void GameEnds()
	{
		gameOver = true;
	}

	public void AddScore(){
		Debug.Log ("Score added");
		ScoreFactory.GetScore ().AddScore ();
	}

	private void Update()
	{
		UpdateScore();
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

