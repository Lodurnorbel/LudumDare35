using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SideDetectorPlayer : MonoBehaviour {

	private List<GameObject> inRange;

	// Use this for initialization
	void Start () {
		inRange = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			foreach (GameObject enemy in inRange) {
				Debug.Log ("Enemy: " + enemy.GetInstanceID());
				enemy.GetComponent<EnemyHealth> ().ChangeHealthBy(-50);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Enemy")) {
			inRange.Add (coll.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.CompareTag ("Enemy")) {
			inRange.Remove (coll.gameObject);
		}
	}
}
