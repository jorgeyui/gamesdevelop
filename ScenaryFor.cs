using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryFor : MonoBehaviour {

	private BoxCollider2D scenarioCollider;
	private float longitudScene;
	private void Awake()
	{
		scenarioCollider = GetComponent<BoxCollider2D> ();
	}

	// Use this for initialization
	void Start () 
	{
		longitudScene = scenarioCollider.size.x;	
	}

	private void RepetirFondo()
	{
		transform.Translate (Vector2.right * longitudScene * 2);
	}
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < -longitudScene) 
		{
			RepetirFondo ();
		}	
	}
}
