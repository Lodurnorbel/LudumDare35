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
			mustDie = false;
			Destroy (gameObject, 3.0f);
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<InterfaceManagement>().drink();

        }
	
	}

	public void Die() {
		mustDie = true;
		GetComponent<AudioSource> ().Play ();
		foreach (Collider2D coll in GetComponentsInChildren<Collider2D>()) {
			coll.enabled = false;
		}
		GameObject.FindGameObjectWithTag ("ScoreSystem").GetComponent<ScoreSystem> ().changeScoreBy (100);
	}
}
