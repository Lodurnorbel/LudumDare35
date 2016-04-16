using UnityEngine;
using System.Collections;

public class StompController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			GetComponentInParent<EnemyController> ().Die ();
		}
	}
}
