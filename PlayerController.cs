using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour 
{
	public float speed; 
	public Boundary boundary;
	public float tilt;
	public GameObject shoot;
	public Transform shotspwan;
	public float fireRate;
	public float nextFire;
	public bool cheat = false;

	void Update () 
	{ 
		if (Input.GetKeyDown ("c")) 
		{
			cheat = true;
		} 
		else if (Input.GetKeyDown ("n")) 
		{
			cheat = false; 	
		}

		if (Input.GetKeyDown ("s") && Time.time > nextFire && cheat == false) 
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			//instantiate crea una nueva instancia del objeto que se le haga referencia en este caso es el shot la fucion requiere como parametros minimos: el objeto,su posision y su rotacion
			Instantiate (shoot, shotspwan.position, shotspwan.rotation);
			GetComponent<AudioSource> ().Play ();
		} 
		else if (Input.anyKeyDown && Time.time > nextFire && cheat == true) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shoot, shotspwan.position, shotspwan.rotation);
			GetComponent<AudioSource>().Play();
		}
		//acceder al audio source


		//Instantiate(shoot,shotspwan.position,shotspwan.rotation);
	}
	void FixedUpdate()
	{
		//movimiento en eje X
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//movimiento en eje y
		float moveVertical = Input.GetAxis ("Vertical");
		//objeto tipo vector que actualiza el transform del player
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//getcomponent<rigidboy> manipula las caracteristicas de movimiento del player como velocidad y posicion
		GetComponent<Rigidbody> ().velocity = movement * speed;
		//se creo un vector3 que mantenga el player dentro de los limites del background usando encapsulamiento de variables en una clase nueva llamada baundary
		GetComponent<Rigidbody> ().position = new Vector3 
			(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin, boundary.xMax),
			 0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax)
			);
		//con la funcion euler se puede manipular la rotacion al mismo tiempo que se mueve el plaer 
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}


}
