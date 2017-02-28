using Assets.Scripts.PlainEntities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using UnityEngine.Events;

public class LevelManagement : MonoBehaviour {

    public UnityEvent onLevelUp;

    [Inject]
    public IScoreUpdater ScoreUpdater { get; set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ScoreUpdater.GetScore() > 100)
        {
            GoToNextLevel();
        }
    }

    private void GoToNextLevel()
    {
        onLevelUp.Invoke();
    }
}
