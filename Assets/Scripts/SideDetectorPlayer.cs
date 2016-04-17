using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SideDetectorPlayer : MonoBehaviour {

	private List<GameObject> inRange;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		inRange = new List<GameObject> ();
		playerController = GetComponentInParent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			inRange.RemoveAll (item => item == null);
			foreach (GameObject enemy in inRange) {
				if (enemy != null) {
					Debug.Log ("Enemy: " + enemy.GetInstanceID ());
					int damage = playerController.getCharacter() == 1 ? -100 : -50; // -100 if werewolf, -50 otherwise
					enemy.GetComponent<EnemyHealth> ().ChangeHealthBy (damage);
				}
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

	public void flip() {
		Vector2 newOffset = GetComponent<BoxCollider2D> ().offset;
		newOffset.x *= -1;
		GetComponent<BoxCollider2D> ().offset = newOffset;
	}
}
