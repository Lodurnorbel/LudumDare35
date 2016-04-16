using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private EnemyMovementBasic movement;
	private bool mustDie;
	private Rigidbody2D rb;
	private Collider2D mainCollider;

	// Use this for initialization
	void Start () {
		movement = GetComponent<EnemyMovementBasic> ();
		rb = GetComponent<Rigidbody2D> ();
		mainCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mustDie) {
			movement.speed = 1f;
			mainCollider.enabled = false;
		}
	
	}

	public void Die() {
		mustDie = true;
	}
}
