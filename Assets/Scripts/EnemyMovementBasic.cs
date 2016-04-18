using UnityEngine;
using System.Collections;

public class EnemyMovementBasic : MonoBehaviour {

	public float speed = 5.0f;

	private Rigidbody2D rigidBody;
	private int sense;
    private SpriteRenderer s;
    private bool flip;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		sense = -1;
        s = GetComponent<SpriteRenderer>();
        flip = false;
	}

	void FixedUpdate () {
		Vector2 newVelocity = rigidBody.velocity;
		newVelocity.x = sense*speed;
		rigidBody.velocity = newVelocity;
	}

	public void ChangeSense() {
		sense *= -1;
        flip = !flip;
        s.flipX = flip;
	}
}
