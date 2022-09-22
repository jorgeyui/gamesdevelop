using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BirdController : MonoBehaviour {


	private bool isDead;
	private Rigidbody2D rb2d;
	public float upForce = 200f;
	private Animator anime; 
	private bool restart;
	//public GameObject goTxt;
	//public GameController gc;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anime = GetComponent<Animator> ();
	
	}
	void Update()
	{
		if (isDead == false) 
		{
			if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, upForce));
				anime.SetTrigger ("flap");
				SoundSystem.instance.PlayFlap();
			}
		}

		if (restart && Input.GetKeyDown(KeyCode.KeypadEnter)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		isDead = true;
		anime.SetTrigger ("DieFlapy");
		//goTxt.SetActive (true);
		//gc.BirdDie();
		GameController.instance.BirdDie();
		restart = true;
		rb2d.velocity = Vector2.zero;
		SoundSystem.instance.PlayHit ();
		SoundSystem.instance.PlayDie ();
	}

}