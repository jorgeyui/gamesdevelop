using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour 
{
	public float RotacionAsteroide;
	void Start()
	{
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * RotacionAsteroide;
	}

}
