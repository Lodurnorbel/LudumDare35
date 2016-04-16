using UnityEngine;
using System.Collections;

public class EnemyMovementBasic : MonoBehaviour {

	public float speed = 5.0f;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newVelocity = rigidBody.velocity;
		newVelocity.x = -speed;
		rigidBody.velocity = newVelocity;
	}
}
