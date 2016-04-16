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

		RaycastHit2D jumpingRaycast = Physics2D.Raycast (transform.position, -Vector2.up, 50, 1 << LayerMask.NameToLayer("Floor"));
		if (jumpingRaycast.collider != null) {
			if (jumpingRaycast.distance < 0.1) {
				isJumping = false;
			} else {
				isJumping = true;
			}
		}

		rigidBody.velocity = new Vector2 (horizontalAxis * speed, rigidBody.velocity.y);
		if (isJumpingPressed && !isJumping) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
			//isJumping = true;
		}
	}
}
