using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject player; 
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//con esto se obtiene una diferencia entre la posicion de la camara con el objeto al que se apunta, 
		//lo cual hara que no rote la camara en todas direcciones
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
