using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	//variable que indica que objeto tedra una aparicion con transform aleatoreo
	public GameObject hazard; 
	public GameObject Enemy;
	public GameObject Boss;
	public bool StartBoos;
	public int NoEnemy;
	public int NoAsteroids;
	public Vector3 spawnValues;
	//con esta variable tendra tiempo para que los asteroides se despleguen antes de aparecer y no exploten
	public float spawnWait;
	//con esta variable el player tendra el tiempo que se le defina antes de poderse mover
	public float StartWait;
	//con esta variable damos tiempo para el ciclo de reaparicion de asteroides 
	public float justWait;
	public GUIText Points;
	private int ScoreCounter;
	public GUIText Restart;
	public GUIText GameOverText;

	private bool RestartFlag;
	private bool GameOverFlag;

	// Use this for initialization
	void Start () 
	{
		Boss.SetActive (false);
		RestartFlag = false;
		GameOverFlag = false;
		Restart.text = "";
		GameOverText.text = "";
		ScoreCounter = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		/*UpdateScore ();
		if (ScoreCounter == 100) 
		{
			Vector3 spawnBossPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 10f);
			Instantiate (Boss, spawnBossPosition, transform.rotation);
		}*/

		UpdateScore ();
		if (ScoreCounter == 100) 
		{
			StartBoos = true;
			Boss.SetActive (true);
		}
		if (RestartFlag) 
		{
			if(Input.GetKeyDown(KeyCode.R)) //puede hacerse de esa forma o con Input.GetKeyDown("R")
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
		}
	}

	//con esta funcion randorizamos el lugar donde aparecera nuestro asteroide
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (StartWait);
		while (true)
		{ 

			for (int k = 0; k <= NoEnemy; k++) 
			{
				//con un objecto vector podemos darle valor a esa posicion en este caso dimos valor random al eje x porque neesitamos que el asteroide aparesca de arriba hacia abajo
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y,spawnValues.z);
				//con quaternion podemos obtener numeros aleatoreos que le den valor a la rotacion en los 3 ejes x y z
				Instantiate (Enemy, spawnPosition, transform.rotation);
				yield return new WaitForSeconds (spawnWait);
			}
	     	for(int i=0; i<= NoAsteroids; i++)
		    {
		      //con un objecto vector podemos darle valor a esa posicion en este caso dimos valor random al eje x porque neesitamos que el asteroide aparesca de arriba hacia abajo
		      Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y,spawnValues.z);
		      //con quaternion podemos obtener numeros aleatoreos que le den valor a la rotacion en los 3 ejes x y z
		      Quaternion spawnRotation = Quaternion.identity;
		     Instantiate (hazard, spawnPosition, spawnRotation);
			 yield return new WaitForSeconds (spawnWait); 
		    }
			yield return new WaitForSeconds (justWait);


			if (GameOverFlag) 
			{
				Restart.text="Presiona R para Reinizar";
				RestartFlag = true;
				break;
			}
		}
	}
	//con esta funcion se agregan los puntos cada vez que se destruye u
	public void AddScore(int ScoreValue)
	{
		ScoreCounter += ScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		Points.text = "Points: " + ScoreCounter;
	}

	public void GameOver()
	{
		GameOverText.text ="Game Over :c Created By Gamer";
		GameOverFlag = true;
	}
}
