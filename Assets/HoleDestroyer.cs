using UnityEngine;
using System.Collections;

public class HoleDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Player")) {
			coll.GetComponentInParent<PlayerController> ().Die ();
		} else {
			Destroy (coll.gameObject);
		}
	}
}
