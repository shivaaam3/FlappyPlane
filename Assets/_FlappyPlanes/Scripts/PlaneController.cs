using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

	[SerializeField] float flapSpeed;
	[SerializeField] Rigidbody2D rb;
	public SpriteRenderer spriteRenderer;
	public Animator animator;
	public Sprite[] colorSprites;

	private bool tap;

	void OnEnable()
	{
		GameController.gameStarted += OnGameStarted;		
	}

	void OnDisable() 
	{
		GameController.gameStarted -= OnGameStarted;		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameController.instance.CurrentState == GameStates.play && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ))
		{
			tap = true;
		}
	}

	void FixedUpdate()
	{
		if(GameController.instance.CurrentState != GameStates.play)
			return;


		if(tap)
		{
			rb.velocity = Vector2.up * flapSpeed;
			tap = false;
		}

		if(rb.velocity.y > 0) 
		{
			float angle = Mathf.Lerp (0, 45, (rb.velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		else 
		{
			float angle = Mathf.Lerp (0, -90, (-rb.velocity.y / 7f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == Constants.OBSTACLE_TAG)
		{
			Debug.Log("Game Over!!");
			GameController.instance.GameOver();
		}

		else if(coll.tag == Constants.SCORE_TAG)
		{
			GameController.instance.uimanager.UpdateScoreText(++GameController.instance.Score);
			if(GameController.instance.Score > PrefsManager.HighScore)
			{
				PrefsManager.HighScore = GameController.instance.Score;
				GameController.instance.uimanager.UpdateHighScoreText(GameController.instance.Score);
			}
		}
	}

	public void ChangeColor(int c)
	{
		spriteRenderer.sprite = colorSprites[c];
	}

	void OnGameStarted()
	{
		animator.enabled = true;
		rb.simulated = true;

		if(GameController.instance.currentColor == 0)
		{
			animator.Play(Constants.GREEN_ANIMATION_STATE);
		}
		else
		{
			animator.Play(Constants.RED_ANIMATION_STATE);
		}
	}
}
