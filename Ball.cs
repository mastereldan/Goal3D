using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


	public Transform ballTransform;
	private Rigidbody _rb;
	public GameObject player;
	public bool hasBall = false;
	public float shotPower = 100f;
	public bool right;
	public bool left;

	void Start ()

	{

		_rb = GetComponent<Rigidbody> ();



	}
	
	// Update is called once per frame
	void Update () 

	{
		


		Shot ();

		if (hasBall && right) 
		{
			transform.position = new Vector3 (player.transform.position.x + 1.053f, player.transform.position.y - 0.697f, player.transform.position.z );

		}

		if (hasBall && left)
		{

			transform.position = new Vector3 (player.transform.position.x - 1.053f, player.transform.position.y - 0.697f, player.transform.position.z );

		}





	}


	private void OnCollisionEnter (Collision collision)
	{


		if (collision.gameObject.name == "Player") {
			//Debug.Log ("Collision: " + collision.gameObject.name + ".");
			Debug.Log ("Player has ball.");

			hasBall = true;
		}
	}


	public void Shot()
	{


		if(Input.GetButtonDown("Fire1") && hasBall && right)
		{
			hasBall = false;
			_rb.AddForce (shotPower, shotPower / 3, 0);
		}


		if(Input.GetButtonDown("Fire1") && hasBall && left)
		{
			hasBall = false;

			_rb.AddForce (-shotPower, shotPower/3, 0);
		}




	}
}
