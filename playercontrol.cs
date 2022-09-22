using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int marcador;
	public Text txt;
	public Text win;
	void FixedUpdate()
	{
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		Vector3 movimiento = new Vector3 (moveH, 0.0f, moveV);

		rb.AddForce (movimiento *  speed);
	}
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		marcador = 0;
	    SetMarcador();
		win.text = "";
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Box")) 
		{
			other.gameObject.SetActive (false);
			marcador = marcador + 1;
		    SetMarcador();
		}

	}
	void SetMarcador()
	{
		txt.text = "POINTS: " + marcador.ToString ();
		if (marcador.ToString() == "9") 
		{
			win.text="You Win!!!";
		}
	}
}
