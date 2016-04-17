using UnityEngine;
using System.Collections;

public class EnemyMovementBasic : MonoBehaviour {

	public float speed = 5.0f;

	private Rigidbody2D rigidBody;
	private int sense;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		sense = -1;
	}

	void FixedUpdate () {
		Vector2 newVelocity = rigidBody.velocity;
		newVelocity.x = sense*speed;
		rigidBody.velocity = newVelocity;
	}

	public void ChangeSense() {
		sense *= -1;
	}
}
