using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private int planeColorIndex = 0;
	public GameObject menuPlane;
	public GameObject gamePlane;

	public Text scoreText;
	public Text highScoreText;

	void OnEnable()
	{
		GameController.gameStarted += OnGameStarted;		
	}

	void OnDisable() 
	{
		GameController.gameStarted -= OnGameStarted;		
	}

	public void ChangeColor()
	{
		planeColorIndex = 1-planeColorIndex;					//switch between 0 and 1
		GameController.instance.planeController.ChangeColor(planeColorIndex);
		GameController.instance.currentColor = planeColorIndex;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
			if(this.gameObject.name == "Canvas" && GameController.instance.CurrentState == GameStates.over)
			{
				GameController.instance.GamePlay();
				return;
			}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void UpdateScoreText(int score)
	{
		scoreText.text = "Score: " + score.ToString();
	}

	public void UpdateHighScoreText(int score)
	{
		highScoreText.text = "Best: " + score.ToString();
	}

	void OnGameStarted()
	{
		menuPlane.SetActive(false);
		UpdateScoreText(0);
		UpdateHighScoreText(PrefsManager.HighScore);
		gamePlane.SetActive(true);
	}
}
