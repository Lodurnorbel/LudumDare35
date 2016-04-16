using UnityEngine;
using System.Collections;

public class EnemyMovementBasic : MonoBehaviour {

	public float speed = 5.0f;

	private Rigidbody2D rigidBody;
	private int sense;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		sense = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidBody.velocity.x == 0) {
			sense *= -1;
		}
		Vector2 newVelocity = rigidBody.velocity;
		newVelocity.x = sense*speed;
		rigidBody.velocity = newVelocity;
	}
}
