using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour {

	private int score = 0;
	private GameStates currentState = GameStates.over;
	public static GameController instance;
	public static Action gameStarted;
	public PlaneController planeController;
	public UIManager uimanager;
	public int currentColor = 0;

	public GameStates CurrentState
	{
		get{return currentState;}
	}

	public int Score
	{
		set {score = value;}
		get{return score;}
	}

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(this);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}

	public void GamePlay()
	{
		currentState = GameStates.play;
		gameStarted();
	}

	public void GameOver()
	{
		currentState = GameStates.pause;
		ResetGame();
	}
		
}
