using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;
	public float jumpForce = 5.0f;

	private bool isJumping;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		isJumping = true;
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		bool isJumpingPressed = Input.GetButton ("Jump");
		Debug.Log ("Y Velocity = " + rigidBody.velocity.y);
		if (rigidBody.velocity.y == 0) {
			Debug.Log ("SETTING TO NOT JUMPING");
			isJumping = false;
		}

		rigidBody.velocity = new Vector2 (horizontalAxis * speed, rigidBody.velocity.y);
		if (isJumpingPressed && !isJumping) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
			isJumping = true;
		}
	}
}
