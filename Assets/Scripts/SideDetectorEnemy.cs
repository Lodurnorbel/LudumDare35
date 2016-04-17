using UnityEngine;
using System.Collections;

public class SideDetectorEnemy : MonoBehaviour {

	private BoxCollider2D detector;

	// Use this for initialization
	void Start () {
		detector = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Player")) {
			coll.GetComponent<PlayerHealth> ().ChangeHealthBy (-10);
		} else if (coll.CompareTag ("Floor")) {
			GetComponentInParent<EnemyMovementBasic> ().ChangeSense ();
			Vector2 newOffset = detector.offset;
			newOffset.x *= -1;
			detector.offset = newOffset;
		}
	}
}
