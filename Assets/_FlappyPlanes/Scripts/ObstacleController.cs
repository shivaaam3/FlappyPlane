using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] Transform poolPosition, spawnPosition;
	[SerializeField] int maxY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameController.instance.CurrentState != GameStates.play)
			return;

		if(transform.position.x <= poolPosition.position.x)
			transform.position = new Vector2(spawnPosition.position.x, Random.Range(-maxY,maxY));
		
		transform.Translate(Vector2.left*speed*Time.deltaTime);
	}
}
