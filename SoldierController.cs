using UnityEngine;
using System.Collections;

public class SoldierController : MonoBehaviour 
{
	public float speed;
	CharacterController Move;
	public bool NewAngle;

	void Start()
	{
		NewAngle = false;
		Move = GetComponent<CharacterController> ();
	}
	void Update()
	{
		Vector3 Direcction = Vector3.zero;
		float DesiredAngle = transform.rotation.eulerAngles.y;	

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			NewAngle = true;
			DesiredAngle = 90.0f;
			Direcction.x = 1.0f;
		} 
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		 {
			NewAngle = true;
			DesiredAngle = -90.0f;
			Direcction.x = -1.0f;	
						
		 }
		else if (Input.GetKey (KeyCode.UpArrow)) 
		{
			if (NewAngle) 
			{
				if (DesiredAngle == 90.0f)
				    DesiredAngle = 45.0f;
				if (DesiredAngle == -90.0f) 
					DesiredAngle = -45.0f;
				
			} 
			else 
			{
				DesiredAngle = 0.0f;
			}
			Direcction.z = 1.0f; 
		} 
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			if (NewAngle) 
			{
				if (DesiredAngle == -90.0f) 
					DesiredAngle = 225.0f;
				if (DesiredAngle == 90.0f) 
					DesiredAngle = 135.0f;
			} 
			else 
			{
				DesiredAngle = 180.0f;
			}
			Direcction.z = -1.0f;

		}

		Direcction.Normalize ();
		Vector3 movemement = Direcction * speed * Time.deltaTime;
		Move.Move (movemement);
		transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler (0.0f, DesiredAngle, 0.0f), Mathf.Min(1.0f, Time.deltaTime/0.3f));
	}

}
