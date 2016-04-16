using UnityEngine;
using System.Collections;

[System.Serializable]
public class MovementParameters {
	public float speedMultiplier;
	public int jumpsAvailable;
}

public class PlayerMovement : MonoBehaviour {

	public float baseSpeed = 5.0f;
	public float jumpForce = 5.0f;
	public MovementParameters movementParameters;

	private bool isJumping;
	private Rigidbody2D rigidBody;
	private int jumpsDone;

	// Use this for initialization
	void Start () {
		isJumping = true;
		rigidBody = GetComponent<Rigidbody2D> ();
		jumpsDone = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		bool isJumpingPressed = Input.GetButtonDown ("Jump");

		RaycastHit2D jumpingRaycast = Physics2D.Raycast (transform.position, -Vector2.up, 50, 1 << LayerMask.NameToLayer("Floor"));
		if (jumpingRaycast.collider != null) {
			if (jumpingRaycast.distance < 0.1) {
				isJumping = false;
				jumpsDone = 0;
			} else {
				if (!isJumping) {
					jumpsDone = 1;
				}
			}
		}

		rigidBody.velocity = new Vector2 (horizontalAxis * baseSpeed * movementParameters.speedMultiplier, rigidBody.velocity.y);
		if (isJumpingPressed && jumpsDone < movementParameters.jumpsAvailable) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
			isJumping = true;
			jumpsDone++;
		}
	}
}
