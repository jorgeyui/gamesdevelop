using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

	public static SoundSystem instance;

	public AudioSource audioclipCoin;
	public AudioSource auidoclipFlap;
	public AudioSource auidoclipHit;
	public AudioSource audioclipDie;
	public AudioSource auidosource;

	public void Awake()
	{
		if (SoundSystem.instance == null)
		{
			SoundSystem.instance = this;
		}
		else 
		{
			Destroy (gameObject);
		}
	}

	public void PlayCoin()
	{
		audioclipCoin.Play ();
	}

	public void PlayFlap()
	{
		auidoclipFlap.Play ();
	}

	public void PlayHit()
	{
		auidoclipHit.Play();
	}

	public void PlayDie()
	{
		audioclipDie.PlayDelayed (1f);
	}
	private void OnDestroy()
	{
		if (SoundSystem.instance == this) 
		{
			SoundSystem.instance = null;
		}
	}
}
