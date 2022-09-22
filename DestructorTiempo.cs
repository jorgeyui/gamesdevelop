using UnityEngine;
using System.Collections;

public class DestructorTiempo : MonoBehaviour 
{
	//con este codigo los asteroides se destruiran automaticamente en un tiempo definido con esto no quedaran duplicados los objetos dentro deñ arbol de jerarquia y asi no cuasara mayor espacio en render
	public float lifetime;
	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, lifetime);
	
	}

}
