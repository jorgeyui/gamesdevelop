using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			GameController.instance.Score ();
		}
	}
}
