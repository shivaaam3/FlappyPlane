using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == Constants.PLANE_TAG)
		{
			Debug.Log("Game Over!!");
			GameController.instance.GameOver();
		}
	}
}
