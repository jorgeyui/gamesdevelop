using UnityEngine;
using System.Collections;

public class DestructorDisparosBoundary : MonoBehaviour 
{
	void OnTriggerExit(Collider disparo)
	{
	  //destruye todos los gameobjects que salgan de los limites de escala del colliderobject instanciado
		Destroy(disparo.gameObject);
	}

}
