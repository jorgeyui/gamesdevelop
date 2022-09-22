using UnityEngine;
using System.Collections;

public class DestroyerTrigger : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject PlayerExplosion;
	private int ScoreValue=10;
	private GameController GC;

	void Start()
	{
		GameObject gameController = GameObject.FindWithTag ("GameController");
		if (gameController != null) {
			GC = gameController.GetComponent<GameController> ();
		} 
		else 
		{
			Debug.Log ("No se pudo inizilaizar el juego, Porque no existe el gamecontroller script");
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		//funcion para depurar el objeto collider en este caso es other
		//Debug.Log (other.name);
		if (other.tag == "Boundary") 
		{
			return;
		}
		//lo instanciara en la misma posicion y rotacion que el asteroide ya que toma sus coordenadas de transform como parametro
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") 
		{
			Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation);
			ScoreValue = 0;
			GC.AddScore (ScoreValue);
			GC.GameOver ();
		}
		//agrega 10 puntos por cada asteroide destruido 
		GC.AddScore (ScoreValue);
		Destroy(other.gameObject);
		Destroy (gameObject);

	}
}
