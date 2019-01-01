using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{


	[SerializeField]
	private float jumpForce = 100f;
	[SerializeField]
	private float doubleJumpForce;
	[SerializeField]
	private bool canjump = true;
	[SerializeField]
	private bool canDoubleJump = false;
	public bool moveRight = true;
	public bool moveLeft = false;




	private Rigidbody rb;

	

	public float moveSpeed = 5f;
	private float moveHorizontal;
	private float moveVertical;
	private float jump;


	Ball scriptBall;
	GameObject ballObject;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		ballObject = GameObject.Find ("Ball");
		scriptBall = ballObject.GetComponent<Ball>();

	}


	void Update ()
	{
		
	}

	void FixedUpdate()
	{
		MovePlayer();
		TurnPlayer ();


	}

	// LateUpdate is called after all Update functions have been called
	void LateUpdate()
	{

	}



	void MovePlayer()
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		jump = Input.GetAxis("Jump");

		if (moveRight)
		{
			transform.Translate (Vector3.right * moveHorizontal * moveSpeed * Time.deltaTime);
			transform.Translate (Vector3.forward * moveVertical * moveSpeed * Time.deltaTime);
		}


		if (moveLeft) 
		{
			transform.Translate (-Vector3.right * moveHorizontal * moveSpeed * Time.deltaTime);
			transform.Translate (Vector3.back * moveVertical * moveSpeed * Time.deltaTime);

		}





		if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
		{
			rb.velocity = new Vector3(0, jumpForce, 0);
			canDoubleJump = false;


		}

		if (Input.GetKeyDown(KeyCode.Space) && canjump)
		{
			rb.velocity = new Vector3(0, jumpForce, 0);


			canjump = false;
			canDoubleJump = true;
		}








	}
	private void OnCollisionEnter (Collision collision)
	{
		

		if (collision.gameObject.name == "Teren") {
			//Debug.Log ("Collision: " + collision.gameObject.name + ".");
			Debug.Log ("Player on ground.");

			canjump = true;
			canDoubleJump = false;
		}
	}

	private void TurnPlayer()
	{


		if (Input.GetKey (KeyCode.A) && moveRight) 
		{
			Quaternion turnRotation = Quaternion.Euler (0f, 180f , 0f );
			rb.MoveRotation (rb.rotation * turnRotation);
			//moveLeft = true;
			//scriptBall.left = true;
			//moveRight = false;
			//scriptBall.right = false;

			SetLeftRight (true, false);

		}
		if (Input.GetKey (KeyCode.D) && moveLeft)
		{
		
			Quaternion turnRotation = Quaternion.Euler (0f, 180f , 0f );
			rb.MoveRotation (rb.rotation * turnRotation);

			SetLeftRight (false, true);

		}
			
	}

	void SetLeftRight (bool l, bool r)
	{
		moveLeft = l;
		scriptBall.left = l;
		moveRight = r;
		scriptBall.right = r;
	}



}
