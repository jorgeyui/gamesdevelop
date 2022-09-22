using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColumCreator : MonoBehaviour {

	public int columnCount = 5;
	public GameObject columPrefab;
	private GameObject[] columns;
	private Vector2 ColumnsPositionIni= new Vector2(-14,0);
	private float timeSceneLastSpawn;
	public float spawnRate;
	public GameObject title;

	public float columMin = -2.9f;
	public float columMax = 1.4f;

	private float spawnXposition= 10f;
	private int currentColumn; 
	void Start()
	{
		columns = new GameObject[columnCount];
		for (int i = 0; i < columnCount; i++) 
		{
			columns [i] = Instantiate (columPrefab, ColumnsPositionIni, Quaternion.identity);
			Debug.Log ("columna creada");
	    }
	}

	void Update()
	{
		timeSceneLastSpawn += Time.deltaTime;
		if (!GameController.instance.gameOver && timeSceneLastSpawn >= spawnRate) 
		{
			timeSceneLastSpawn = 0; 
			float spawnYposition = Random.Range (columMin, columMax);
			columns [currentColumn].transform.position = new Vector2 (spawnXposition, spawnYposition);
			currentColumn++;
			if (currentColumn == 1)
			{
				title.SetActive (false);
			}
			if (currentColumn >= columnCount) 
			{
				currentColumn = 0;
			}
		}
	}
}
