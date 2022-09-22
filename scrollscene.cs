using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollscene : MonoBehaviour {

	private Rigidbody2D Rb2d;


	private void Awake()
	{
		Rb2d = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () 
	{
		Rb2d.velocity = new Vector2 (GameController.instance.speed, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameController.instance.gameOver) 
		{
			Rb2d.velocity = Vector2.zero;
		}	
	}
}
