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
	public MovementParameters[] movementParameters;
	public int initialCharacter = 0;

	private bool isJumping;
	private Rigidbody2D rigidBody;
	private int jumpsDone;
	private PlayerController playerController;
    private SpriteRenderer sprite;
    private bool viewRight;

	// Use this for initialization
	void Start () {
		isJumping = true;
		rigidBody = GetComponent<Rigidbody2D> ();
		jumpsDone = 0;
		playerController = GetComponent<PlayerController> ();
        sprite = GetComponentInChildren<SpriteRenderer>();
        viewRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		bool isJumpingPressed = Input.GetButtonDown ("Jump");

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !viewRight) {
			flip ();
        }
        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && viewRight){
			flip ();
        }

        if (Input.GetKeyDown("1")) GetComponent<Animator>().Play("Zombie"); 
        if (Input.GetKeyDown("2")) GetComponent<Animator>().Play("HombreLobo");
        if (Input.GetKeyDown("3")) GetComponent<Animator>().Play("Vampire");

        RaycastHit2D jumpingRaycast = Physics2D.Raycast (transform.position, -Vector2.up, 50, 1 << LayerMask.NameToLayer("Floor"));
		if (jumpingRaycast.collider != null) {
			if (jumpingRaycast.distance < 2) {
				isJumping = false;
				jumpsDone = 0;
			} else {
				if (!isJumping) {
					jumpsDone = 1;
				}
			}
		}

		rigidBody.velocity = new Vector2 (horizontalAxis * baseSpeed * movementParameters[playerController.getCharacter()].speedMultiplier, rigidBody.velocity.y);
		if (isJumpingPressed && jumpsDone < movementParameters[playerController.getCharacter()].jumpsAvailable) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
			isJumping = true;
			jumpsDone++;
		}
	}

	void flip() {
		viewRight = !viewRight;
		sprite.flipX = !sprite.flipX;
		GetComponentInChildren<SideDetectorPlayer> ().flip();
	}

	public void setCriature(string c) {
        GetComponent<Animator>().Play(c);
	}

}
