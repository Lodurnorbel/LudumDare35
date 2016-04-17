using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int initialCharacter = 0;

	private int currentCharacter;

	// Use this for initialization
	void Start () {
		currentCharacter = initialCharacter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getCharacter() {
		return currentCharacter;
	}

	public void changeCharacter(int character) {
		currentCharacter = character;
		GetComponent<PlayerMovement> ().setCriature (character);
	}

	public void Die() {
		foreach (Collider2D coll in GetComponentsInChildren<Collider2D>()) {
			coll.enabled = false;
		}
		GetComponent<PlayerMovement> ().enabled = false;
		Destroy (this, 3.0f);
	}
}
