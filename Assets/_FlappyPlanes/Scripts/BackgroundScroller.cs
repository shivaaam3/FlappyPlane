using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] Transform rightBoundry, leftBoundry;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameController.instance.CurrentState != GameStates.play)
			return;

		if(transform.position.x <= leftBoundry.position.x)
			transform.position = rightBoundry.position;

		transform.Translate(speed*Vector3.left*Time.deltaTime);
	}
}
